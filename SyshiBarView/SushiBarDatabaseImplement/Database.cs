using Microsoft.EntityFrameworkCore;
using DatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseImplement
{
    public class Database : DbContext
 {
 protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-G18CFSK\SQLEXPRESS;Initial Catalog=ЭкзаменDatabase;Integrated Security=True;MultipleActiveResultSets=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }
 public virtual DbSet<Статья> Статьи { set; get; }
        public virtual DbSet<Автор> Авторы { set; get; }
        public virtual DbSet<АвторСтатья> AvtorStatias { set; get; }

    }
}