using GymManagementBLL.Services.Interfaces;
using GymManagementBLL.ViewModels.MemberViewModel;
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
    public class MemberService : IMemberService
    {
        private readonly IUnitOfWorks _unitOfWorks;

        public MemberService(IUnitOfWorks unitOfWorks)
        {
            _unitOfWorks = unitOfWorks;
        }

        public IEnumerable<MemberViewModel> GetAllMembers()
        {
            var Members = _unitOfWorks.GetRepository<Member>().GetAll();
            if (Members == null || !Members.Any()) return [];


            var MemberViewModels = Members.Select(X => new MemberViewModel()
            {
                Id = X.Id,
                Name = X.Name,
                photo = X.Photo,
                Email = X.Email,
                Phone = X.Phone,
                Gender = X.Gender.ToString()
            });
            return MemberViewModels;
        }

        public bool CreateMember(CreateMemberViewModel createMember)
        {
            try
            {
                

                if (IsEmailExist(createMember.Email) || IsPhoneExist(createMember.Phone)) return false;

                var member = new Member()
                {
                    Name = createMember.Name,
                    Email = createMember.Email,
                    Phone = createMember.Phone,
                    Gender = createMember.Gender,
                    DateOfBirth = createMember.DateOfBirth,
                    Address = new Address()
                    {
                        BuildingNumber = createMember.BuildingNumber,
                        Street = createMember.Street,
                        City = createMember.City
                    },
                    HealthRecord = new HealthRecord()
                    {
                        Weight = createMember.HealthRecordViewModel.Weight,
                        Height = createMember.HealthRecordViewModel.Height,
                        BloodType = createMember.HealthRecordViewModel.BloodType,
                        Note = createMember.HealthRecordViewModel.Note
                    },

                };
                _unitOfWorks.GetRepository<Member>().Add(member);
                return _unitOfWorks.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }

        public MemberViewModel? GetMemberDetails(int MemberId)
        {
            var member = _unitOfWorks.GetRepository<Member>().GetById(MemberId);
            if (member == null) return null;

            var viewModel = new MemberViewModel()
            {
                Name = member.Name,
                photo = member.Photo,
                Email = member.Email,
                Phone = member.Phone,
                Gender = member.Gender.ToString(),
                DateOfBirth = member.DateOfBirth.ToShortDateString(),
                Address = $"{member.Address.BuildingNumber}, {member.Address.Street}, {member.Address.City}"
            };

            var ActiveMemberShip = _unitOfWorks.GetRepository<MemberShip>().GetAll(X => X.MemberId == MemberId && X.Status == "Active").FirstOrDefault();

            if (ActiveMemberShip is not null)
            {
                viewModel.MemberShipStartDate = ActiveMemberShip.CreateAt.ToShortDateString();
                viewModel.MemberShipEndDate = ActiveMemberShip.EndDate.ToShortDateString();
                var plan = _unitOfWorks.GetRepository<Plan>().GetById(ActiveMemberShip.PlanId);
                viewModel.PlanName = plan?.Name;
            }
            return viewModel;
        }

        public HealthRecordViewModel? GetMemberHealthRecord(int MemberId)
        {
            var memberHealthRecord = _unitOfWorks.GetRepository<HealthRecord>().GetById(MemberId);

            if (memberHealthRecord == null) return null;

            return new HealthRecordViewModel()
            {
                Weight = memberHealthRecord.Weight,
                Height = memberHealthRecord.Height,
                BloodType = memberHealthRecord.BloodType,
                Note = memberHealthRecord.Note
            };
        }

        public MemberToUpdateViewModel? GetMemberForUpdate(int MemberId)
        {
            var member = _unitOfWorks.GetRepository<Member>().GetById(MemberId);
            if (member == null) return null;

            return new MemberToUpdateViewModel()
            {
                Photo = member.Photo,
                Name = member.Name,
                Email = member.Email,
                BuildingNumber = member.Address.BuildingNumber,
                Street = member.Address.Street,
                City = member.Address.City,
                Phone = member.Phone
            };
        }

        public bool UpdateMemberDetails(int Id, MemberToUpdateViewModel memberToUpdate)
        {
            try
            {
                if (IsEmailExist(memberToUpdate.Email) || IsPhoneExist(memberToUpdate.Phone)) return false;

                var MemberRepo = _unitOfWorks.GetRepository<Member>();
                var member = MemberRepo.GetById(Id);
                if (member == null) return false;
                 
                member.Email = memberToUpdate.Email;
                member.Phone = memberToUpdate.Phone;
                member.Address.BuildingNumber = memberToUpdate.BuildingNumber;
                member.Address.Street = memberToUpdate.Street;
                member.Address.City = memberToUpdate.City;
                member.UpdatedAt = DateTime.Now;

                MemberRepo.Update(member);
                return _unitOfWorks.SaveChanges() > 0;

            }
            catch
            {
                return false;
            }

        }

        public bool RemoveMember(int MemberId)
        {
            try
            {
                var member = _unitOfWorks.GetRepository<Member>().GetById(MemberId);
                if (member == null) return false;

                var HasActiveMemberSession = _unitOfWorks.GetRepository<MemberSession>().GetAll(X => X.MemberId == MemberId && X.Session.StartDate > DateTime.Now).Any();
                if (HasActiveMemberSession) return false;

                var memberShipRepo = _unitOfWorks.GetRepository<MemberShip>();
                var memberShips = memberShipRepo.GetAll(X => X.MemberId == MemberId);

                if (memberShips.Any())
                {
                    foreach (var memberShip in memberShips)
                    {
                        memberShipRepo.Delete(memberShip);
                    }
                }

                _unitOfWorks.GetRepository<Member>().Delete(member);
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
            return _unitOfWorks.GetRepository<Member>().GetAll(X => X.Email == email).Any();
        }

        private bool IsPhoneExist(string phone)
        {
            return _unitOfWorks.GetRepository<Member>().GetAll(X => X.Phone == phone).Any();
        }
        #endregion
    }
}
