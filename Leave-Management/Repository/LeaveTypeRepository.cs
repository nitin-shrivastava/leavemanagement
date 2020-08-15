using Leave_Management.Contracts;
using Leave_Management.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Leave_Management.Repository
{
    public class LeaveTypeRepository : ILeaveTypeRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public LeaveTypeRepository(ApplicationDbContext db)
        {
            _dbContext = db;
        }
        public bool Create(LeaveType entity)
        {
            _dbContext.LeaveTypes.Add(entity);
            return Save();
        }

        public bool Delete(LeaveType entity)
        {
            _dbContext.LeaveTypes.Remove(entity);
            return Save();
        }

        public ICollection<LeaveType> FindAll()
        {
            return _dbContext.LeaveTypes.ToList();
        }

        public LeaveType FindById(int id)
        {
            return _dbContext.LeaveTypes.FirstOrDefault(x => x.Id == id);
        }

        public ICollection<LeaveType> GetEmployeeByLeaveType()
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            return _dbContext.SaveChanges() > 0 ? true : false ;
        }

        public bool Update(LeaveType entity)
        {
            _dbContext.LeaveTypes.Update(entity);
            return Save();
        }
    }
}
