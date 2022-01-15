using MVCJWTTokenDemo.DAL;
using MVCJWTTokenDemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCJWTTokenDemo.Repository
{
    public class EmployeeRepository:IEmployeeRepository
    {
        private readonly DBContext _context;
        public EmployeeRepository(DBContext context)
        {
            _context = context;
        }
        public void Create(MEmployee item)
        {
            _context.Emp.Add(item);
            _context.SaveChanges();
        }
        public MEmployee GetById(int Id)
        {
            return _context.Emp.FirstOrDefault(t => t.EmpID == Id);
        }
        public List<MEmployee> GetAll()
        {
            return _context.Emp.ToList();
        }
        public void Update(int id, MEmployee item)
        {
            var entity = _context.Emp.Find(id);
            if (entity == null)
            {
                return;
            }
            _context.Entry(entity).CurrentValues.SetValues(item);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var entity = _context.Emp.Find(id);
            if (entity == null)
            {
                return;
            }
            _context.Emp.Remove(entity);
            _context.SaveChanges();
        }
    }
}
