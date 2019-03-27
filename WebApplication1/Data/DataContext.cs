﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Model;

namespace WebApplication1.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext>options)
            :base(options)
        {

        }
        public DbSet<StudentCreateViewModel> Students { get; set; }
    }
}
