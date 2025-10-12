using GymManagementBLL.ViewModels.TrainerViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementBLL.Services.Interfaces
{
    public interface ITrainerService
    {
        IEnumerable<TrainerViewModel> GetAllTrainers();
        bool CreateTrainer(CreateTrainerViewModel CreateTrainer);

        TrainerViewModel? GetTrainerDetails(int TrainerId);

        UpdateTrainerViewModel? GetTrainerToUpdate(int TrainerId);

        bool UpdateTrainerDetails(int TrainerId, UpdateTrainerViewModel TrainerToUpdate);

        bool RemoveTrainer(int TrainerId);
    }
}