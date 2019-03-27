using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Model;
using WebApplication1.Data;

namespace WebApplication1.Services
{
    public class EfCoreRepository : IRepository<StudentCreateViewModel>
    {
        private readonly DataContext _context;
        public EfCoreRepository(DataContext context)
        {
            _context = context;
        }

        public StudentCreateViewModel Add(StudentCreateViewModel newModel)
        {
            _context.Students.Add(newModel);
            _context.SaveChanges();
            return newModel;
        }

        public IEnumerable<StudentCreateViewModel> GetAll()
        {
            return _context.Students.ToList();
        }

        public StudentCreateViewModel GetById(int id)
        {
            return _context.Students.Find(id);
        }
    }
}
