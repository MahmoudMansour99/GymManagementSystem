using GymManagementBLL.Services.Interfaces;
using GymManagementBLL.ViewModels.AnalyticViewModels;
using GymManagementDAL.Entities;
using GymManagementDAL.Repostitories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementBLL.Services.Classes
{
    public class AnalyticService : IAnalyticService
    {
        private readonly IUnitOfWorks _unitOfWorks;

        public AnalyticService(IUnitOfWorks unitOfWorks)
        {
            _unitOfWorks = unitOfWorks;
        }
        public AnalyticViewModel GetAnalyticViewModel()
        {
            return new AnalyticViewModel()
            {
                ActiveMembers = _unitOfWorks.GetRepository<MemberShip>().GetAll().Count(X => X.Status == "Active"),
                TotalMembers = _unitOfWorks.GetRepository<MemberShip>().GetAll().Count(),
                TotalTrainers = _unitOfWorks.GetRepository<Trainer>().GetAll().Count(),
                UpComingSessions = _unitOfWorks.GetRepository<Session>().GetAll().Count(X => X.StartDate > DateTime.Now),
                OnGoingSessions = _unitOfWorks.GetRepository<Session>().GetAll().Count(X => X.StartDate <= DateTime.Now && X.EndDate > DateTime.Now),
                CompletedSessions = _unitOfWorks.GetRepository<Session>().GetAll().Count(X => X.EndDate <= DateTime.Now)
            };
        }
    }
}
