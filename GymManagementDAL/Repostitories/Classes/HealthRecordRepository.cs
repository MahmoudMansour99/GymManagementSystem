using GymManagementDAL.Data.DbContexts;
using GymManagementDAL.Entities;
using GymManagementDAL.Repostitories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementDAL.Repostitories.Classes
{
    public class HealthRecordRepository : IHealthRecordRepository
    {
        private readonly GymDbContext _dbContext;
        public HealthRecordRepository(GymDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int AddHealthRecord(HealthRecord healthRecord)
        {
            _dbContext.HealthRecords.Add(healthRecord);
            return _dbContext.SaveChanges();
        }

        public int Delete(HealthRecord healthRecor)
        {
            _dbContext.HealthRecords.Remove(healthRecor);
            return _dbContext.SaveChanges();
        }

        public IEnumerable<HealthRecord> GetAll() => _dbContext.HealthRecords.ToList();

        public HealthRecord GetById(int id) => _dbContext.HealthRecords.Find(id);

        public int Update(HealthRecord healthRecord)
        {
            _dbContext.HealthRecords.Update(healthRecord);
            return _dbContext.SaveChanges();
        }
    }
}
