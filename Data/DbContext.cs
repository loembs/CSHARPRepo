﻿using Microsoft.EntityFrameworkCore;

namespace WebApplication.Data
{
    public class DbContext
    {
        private DbContextOptions<ApplicationDbContext> options;

        public DbContext(DbContextOptions<ApplicationDbContext> options)
        {
            this.options = options;
        }
    }
}