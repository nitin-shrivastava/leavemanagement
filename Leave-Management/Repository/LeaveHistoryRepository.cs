using Leave_Management.Contracts;
using Leave_Management.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Leave_Management.Repository
{
    public class LeaveHistoryRepository : ILeaveHistoryRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public LeaveHistoryRepository(ApplicationDbContext db)
        {
            _dbContext = db;
        }
        public bool Create(LeaveHistory entity)
        {
            _dbContext.LeaveHistories.Add(entity);
            return Save();
        }

        public bool Delete(LeaveHistory entity)
        {
            _dbContext.LeaveHistories.Remove(entity);
            return Save();
        }

        public ICollection<LeaveHistory> FindAll()
        {
            return _dbContext.LeaveHistories.ToList();
        }

        public LeaveHistory FindById(int id)
        {
            return _dbContext.LeaveHistories.FirstOrDefault(x => x.Id == id);
        }

        public bool Save()
        {
            return _dbContext.SaveChanges() > 0 ? true : false;
        }

        public bool Update(LeaveHistory entity)
        {
            _dbContext.LeaveHistories.Update(entity);
            return Save();
        }
    }
}
