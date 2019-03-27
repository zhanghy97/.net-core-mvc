using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;
using WebApplication1.Model;

namespace WebApplication1.ViewComponents
{
    public class WelcomeViewComponents:ViewComponent
    {
        private readonly IRepository<StudentCreateViewModel> _repository;

        public WelcomeViewComponents(IRepository<StudentCreateViewModel> repository)
        {
            _repository = repository;
        }

        public IViewComponentResult Invoke()
        {
            var count = _repository.GetAll().Count().ToString();
            return View("Default",count);
        }
    }
}
