using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LanceFlow.Models.Entities;

namespace LanceFlow.Models
{
    public class DcContext : DbContext
    {
        //добавляем Таблицы для БД и в дальнейшем во вкладке каждой проводим операцию миграции(в файлах с нужными таблицами).
        public DbSet<Pechi> Pechi { get; set; } 

        public DbSet<ProcessOfTechnology> ProcessOfTechnology { get; set; }

        public DbSet<Variants> Variants { get; set; }

        public DbSet<DanniePoFurmam> DanniePoFurmam { get; set; }
        public DbSet<ProcessOfTechnologyDate> ProcessOfTechnologyDate { get; set; }


        public DbSet<DanniePoFurmamDate> DanniePoFurmamDate { get; set; }

        public DcContext(DbContextOptions<DcContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ProcessOfTechnology>().HasKey(u => new { u.PechId, u.VariantId});//составной ключ для таблицы ProcessOfTechnology
            builder.Entity<DanniePoFurmam>().HasKey(u => new { u.VariantId, u.NFurm });//составной ключ для таблицы DanniePoFurmam

            builder.Entity<ProcessOfTechnologyDate>().HasKey(u => new { u.PechId, u.DateId });//составной ключ для таблицы ProcessOfTechnologyDate
            builder.Entity<DanniePoFurmamDate>().HasKey(u => new { u.DateId, u.NFurm, u.PechId });//составной ключ для таблицы DanniePoFurmamDate

            base.OnModelCreating(builder);
        }
    }
}
