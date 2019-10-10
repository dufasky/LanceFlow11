using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models.Entities;

namespace WebApplication3.Models
{
    public class DcContext : DbContext
    {
        public DbSet<Pechi> Pechi { get; set; } //добавляем Таблицы для БД и в дальнейшем во вкладке каждой проводим операцию миграции(в файлах с нужными таблицами).

        public DbSet<ProcessOfTechnology> ProcessOfTechnology { get; set; }//добавляем Таблицы для БД и в дальнейшем во вкладке каждой проводим операцию миграции.

        public DbSet<Variants> Variants { get; set; }//добавляем Таблицы для БД и в дальнейшем во вкладке каждой проводим операцию миграции.

        public DbSet<DanniePoFurmam> DanniePoFurmam { get; set; }//добавляем Таблицы для БД и в дальнейшем во вкладке каждой проводим операцию миграции.



        public DcContext(DbContextOptions<DcContext> options) : base(options)
        {
            Database.EnsureCreated();
    
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ProcessOfTechnology>().HasKey(u => new { u.PechId, u.VariantId});//составной ключ для таблицы ProcessOfTechnology
            builder.Entity<DanniePoFurmam>().HasKey(u => new { u.VariantId, u.NFurm });//составной ключ для таблицы DanniePoFurmam

            base.OnModelCreating(builder);
        }
    }
}
