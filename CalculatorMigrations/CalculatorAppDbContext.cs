using CalculatorModel.Enitiy;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorMigrations
{
    public class CalculatorAppDbContex:DbContext
    {
        public DbSet<CalculatorHistory> Calculator { get; set; }
        protected override void OnConfiguring (DbContextOptionsBuilder OptionsBuilder)
        {
            OptionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=CalculatorAppDb;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
