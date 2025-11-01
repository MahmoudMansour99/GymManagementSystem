using GymManagementBLL.Services.Interfaces;
using GymManagementBLL.ViewModels.MemberViewModel;
using GymManagementBLL.ViewModels.TrainerViewModels;
using GymManagementDAL.Entities;
using GymManagementDAL.Repostitories.Classes;
using GymManagementDAL.Repostitories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementBLL.Services.Classes
{
    public class TrainerService : ITrainerService
    {
        private readonly UnitOfWorks _unitOfWorks;

        public TrainerService(UnitOfWorks unitOfWorks)
        {
            _unitOfWorks = unitOfWorks;
        }


        public IEnumerable<TrainerViewModel> GetAllTrainers()
        {
            var Trainers = _unitOfWorks.GetRepository<Trainer>().GetAll();
            if (Trainers == null || !Trainers.Any()) return [];

            var TrainerViewModels = Trainers.Select(X => new TrainerViewModel()
            {

                Name = X.Name,
                Email = X.Email,
                Phone = X.Phone,
                Specialities = X.Specialties.ToString()
            });

            return TrainerViewModels;

        }


        public bool CreateTrainer(CreateTrainerViewModel CreateTrainer)
        {
            try
            {
                if (IsEmailExist(CreateTrainer.Email) || IsPhoneExist(CreateTrainer.Phone)) return false;

                var Trainer = new Trainer()
                {
                    Name = CreateTrainer.Name,
                    Email = CreateTrainer.Email,
                    Phone = CreateTrainer.Phone,
                    Gender = CreateTrainer.Gender,
                    DateOfBirth = CreateTrainer.DateOfBirth,
                    Address = new Address()
                    {
                        BuildingNumber = CreateTrainer.BuildingNumber,
                        Street = CreateTrainer.Street,
                        City = CreateTrainer.City
                    }
                };
                _unitOfWorks.GetRepository<Trainer>().Add(Trainer);
                return _unitOfWorks.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }

        public TrainerViewModel? GetTrainerDetails(int TrainerId)
        {
            var trainer = _unitOfWorks.GetRepository<Trainer>().GetById(TrainerId);
            if (trainer == null) return null;

            var trainerViewModel = new TrainerViewModel()
            {
                Name = trainer.Name,
                Email = trainer.Email,
                Phone = trainer.Phone,
                Specialities = trainer.Specialties.ToString()
            };
            return trainerViewModel;
        }

        public UpdateTrainerViewModel? GetTrainerToUpdate(int TrainerId)
        {
            var trainer = _unitOfWorks.GetRepository<Trainer>().GetById(TrainerId);
            if (trainer is null) return null;

            return new UpdateTrainerViewModel()
            {
                Email = trainer.Email,
                Phone = trainer.Phone,
                Specialization = trainer.Specialties,
                BuildingNumber = trainer.Address.BuildingNumber,
                Street = trainer.Address.Street,
                City = trainer.Address.City,
            };
        }

        public bool UpdateTrainerDetails(int TrainerId, UpdateTrainerViewModel TrainerToUpdate)
        {
            try
            {
                if (IsEmailExist(TrainerToUpdate.Email) || IsPhoneExist(TrainerToUpdate.Phone)) return false;

                var TrainerRepo = _unitOfWorks.GetRepository<Trainer>();
                var trainer = TrainerRepo.GetById(TrainerId);
                if (trainer == null) return false;

                trainer.Email = TrainerToUpdate.Email;
                trainer.Phone = TrainerToUpdate.Phone;
                trainer.Address.BuildingNumber = TrainerToUpdate.BuildingNumber;
                trainer.Address.Street = TrainerToUpdate.Street;
                trainer.Address.City = TrainerToUpdate.City;
                trainer.UpdatedAt = DateTime.Now;

                TrainerRepo.Update(trainer);
                return _unitOfWorks.SaveChanges() > 0;

            }
            catch
            {
                return false;
            }
        }

        public bool RemoveTrainer(int TrainerId)
        {
            try
            {
                var trainer = _unitOfWorks.GetRepository<Trainer>().GetById(TrainerId);
                if (trainer == null) return false;

                var HasActiveMemberSession = _unitOfWorks.GetRepository<MemberSession>().GetAll(X => X.MemberId == TrainerId && X.Session.StartDate > DateTime.Now).Any();
                if (HasActiveMemberSession) return false;

                var memberShipRepo = _unitOfWorks.GetRepository<MemberShip>();
                var memberShips = memberShipRepo.GetAll(X => X.MemberId == TrainerId);

                if (memberShips.Any())
                {
                    foreach (var memberShip in memberShips)
                    {
                        memberShipRepo.Delete(memberShip);
                    }
                }

                _unitOfWorks.GetRepository<Trainer>().Delete(trainer);
                return _unitOfWorks.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }

        #region Helper Methods
        private bool IsEmailExist(string email)
        {
            return _unitOfWorks.GetRepository<Trainer>().GetAll(X => X.Email == email).Any();
        }

        private bool IsPhoneExist(string phone)
        {
            return _unitOfWorks.GetRepository<Trainer>().GetAll(X => X.Phone == phone).Any();
        }


        #endregion
    }
}
