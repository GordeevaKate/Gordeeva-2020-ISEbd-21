using Microsoft.EntityFrameworkCore;
using SushiBarDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SushiBarDatabaseImplement
{
    public class SushiBarDatabase : DbContext
 {
 protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-G18CFSK\SQLEXPRESS;Initial Catalog=AbstractShopDatabase;Integrated Security=True;MultipleActiveResultSets=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }
 public virtual DbSet<Seafood> Seafoods { set; get; }
        public virtual DbSet<Sushi> Sushis { set; get; }
        public virtual DbSet<SushiSeafood> SushiSeafoods { set; get; }
        public virtual DbSet<Order> Orders { set; get; }
    }
}