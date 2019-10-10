﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication3.Models;

namespace WebApplication3.Migrations
{
    [DbContext(typeof(DcContext))]
    [Migration("20190802163812_23325478")]
    partial class _23325478
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApplication3.Models.Entities.DanniePoFurmam", b =>
                {
                    b.Property<int>("VariantId");

                    b.Property<int>("NFurm");

                    b.Property<double>("RashGazNaF");

                    b.Property<double>("RashVodiNaF");

                    b.Property<double>("Tperepad");

                    b.HasKey("VariantId", "NFurm");

                    b.ToTable("DanniePoFurmam");
                });

            modelBuilder.Entity("WebApplication3.Models.Entities.Pechi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("DiamFurm");

                    b.Property<int>("NFurm");

                    b.Property<string>("Name");

                    b.Property<double>("VisFurm");

                    b.Property<double>("Vpolez");

                    b.HasKey("Id");

                    b.ToTable("Pechi");
                });

            modelBuilder.Entity("WebApplication3.Models.Entities.ProcessOfTechnology", b =>
                {
                    b.Property<int>("PechId");

                    b.Property<int>("VariantId");

                    b.Property<int>("DavlDut");

                    b.Property<int>("NrabFurm");

                    b.Property<string>("Proizv");

                    b.Property<int>("RashDut");

                    b.Property<int>("RashPrirGaz");

                    b.Property<int>("SodKislorod");

                    b.Property<int>("TDut");

                    b.Property<int>("UdRashKoks");

                    b.Property<int>("VlazDut");

                    b.HasKey("PechId", "VariantId");

                    b.ToTable("ProcessOfTechnology");
                });

            modelBuilder.Entity("WebApplication3.Models.Entities.Variants", b =>
                {
                    b.Property<int>("VariantId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Name");

                    b.HasKey("VariantId");

                    b.ToTable("Variants");
                });
#pragma warning restore 612, 618
        }
    }
}
