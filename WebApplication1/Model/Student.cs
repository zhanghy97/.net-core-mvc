﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Model
{
    public class StudentCreateViewModel
    {
        
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }


        public DateTime BirthDate { get; set; }

        public Gender Gender { get; set; }
    }
}
