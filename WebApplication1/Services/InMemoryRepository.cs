using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Model;

namespace WebApplication1.Services
{
    public class InMemoryRepository: IRepository<StudentCreateViewModel>
    {
        private readonly List<StudentCreateViewModel> _students;

        public InMemoryRepository()
        {
            _students = new List<StudentCreateViewModel>
            {
                new StudentCreateViewModel
                {
                    Id = 1,
                    FirstName = "Nick",
                    LastName = "Carter",
                    BirthDate = new DateTime(1997,5,22)
                },
                new StudentCreateViewModel
                {
                    Id = 2,
                    FirstName = "Peter",
                    LastName = "Tom",
                    BirthDate = new DateTime(1997,9,12)
                },
                new StudentCreateViewModel
                {
                    Id = 3,
                    FirstName = "Jack",
                    LastName = "Lee",
                    BirthDate = new DateTime(1997,6,22)
                }
            };
        }

        public StudentCreateViewModel Add(StudentCreateViewModel newModel)
        {
            var maxId = _students.Max(x => x.Id);
            newModel.Id = maxId + 1;
            _students.Add(newModel);
            return newModel;
        }

        public IEnumerable<StudentCreateViewModel> GetAll()
        {
            return _students;
        }

        public StudentCreateViewModel GetById(int id)
        {
            return _students.FirstOrDefault(x => x.Id == id);
        }
    }
}
