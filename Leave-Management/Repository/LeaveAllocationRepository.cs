using Leave_Management.Contracts;
using Leave_Management.Data;
using System.Collections.Generic;
using System.Linq;

namespace Leave_Management.Repository
{
    public class LeaveAllocationRepository : ILeaveAllocationRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public LeaveAllocationRepository(ApplicationDbContext db)
        {
            _dbContext = db;
        }
        public bool Create(LeaveAllocation entity)
        {
            _dbContext.LeaveAllocations.Add(entity);
            return Save();
        }

        public bool Delete(LeaveAllocation entity)
        {
            _dbContext.LeaveAllocations.Remove(entity);
            return Save();
        }

        public ICollection<LeaveAllocation> FindAll()
        {
            return _dbContext.LeaveAllocations.ToList();
        }

        public LeaveAllocation FindById(int id)
        {
            return _dbContext.LeaveAllocations.FirstOrDefault(x => x.Id == id);
        }

        public bool Save()
        {
            return _dbContext.SaveChanges() > 0 ? true : false;
        }

        public bool Update(LeaveAllocation entity)
        {
            _dbContext.LeaveAllocations.Update(entity);
            return Save();
        }
    }
}
