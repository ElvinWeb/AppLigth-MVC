﻿using AppLight.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLight.Data.DAL
{
    public class ProjectDbContext : IdentityDbContext
    {
        public ProjectDbContext(DbContextOptions<ProjectDbContext> options) : base(options)
        {

        }

        public DbSet<Worker> Workers { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
