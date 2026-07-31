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
            OptionsBuilder.UseNpgsql("Host=aws-1-us-west-2.pooler.supabase.com;Database=postgres;Username=postgres.sgjmqzepxflngbbqvyyk;Password=1oWpEbUkkPxHDEY4;SSL Mode=Require;Trust Server Certificate=true");
            // OptionsBuilder.UseSqlServer("Host=db.uyszflnpgbfwnmpklhkf.supabase.co;Database=postgres;Username=postgres;Password=1oWpEbUkkPxHDEY4;SSL Mode=Require;Trust Server Certificate=true");
        }
    }
}
