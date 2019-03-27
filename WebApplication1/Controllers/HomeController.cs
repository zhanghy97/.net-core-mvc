using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Model;
using WebApplication1.Services;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class HomeController:Controller
    {
        private readonly IRepository<Model.StudentCreateViewModel> _repository;
        public HomeController(IRepository<Model.StudentCreateViewModel> repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            var list = _repository.GetAll();

            var vms = list.Select(x => new StudentViewModel
            {
                Id = x.Id,
                Name = $"{x.FirstName} {x.LastName}",
                Age = DateTime.Now.Subtract(x.BirthDate).Days / 365
            });

            var vm = new HomeIndexViewModel
            {
                Students = vms
            };
            return View(vm);
        }
        public IActionResult Detail(int id)
        {
            var student = _repository.GetById(id);
            if (student == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(student);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ViewModels.StudentCreateViewModel student)
        {
            if (ModelState.IsValid)
            {
                var newStudent = new Model.StudentCreateViewModel
                {
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    BirthDate = student.BirthDate,
                    Gender = student.Gender
                };
                var newModel = _repository.Add(newStudent);
                return RedirectToAction(nameof(Detail), new { id = newModel.Id });
            }
            else
            {
                return View();
            }
        }
    }
}
