using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    // /About

    [Route("[controller]/[action]")]
    public class AboutController
    {
        public string Me()
        {
            return "Dave";
        }

        public string Company()
        {
            return "No Company";
        }
    }
}
