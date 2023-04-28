﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using DataAccess.Models;
using DataAccess.Repositories.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
#nullable disable

namespace DataAccess.Repositories
{
    public partial class benderbrauContext : DbContext
    {
        public benderbrauContext()
        {
        }

        public benderbrauContext(DbContextOptions<benderbrauContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Alptabla> Alptabla { get; set; }
        public virtual DbSet<Carrito> Carrito { get; set; }
        public virtual DbSet<Ciudad> Ciudad { get; set; }
        public virtual DbSet<Dp03a110> Dp03a110 { get; set; }
        public virtual DbSet<Dp03acom> Dp03acom { get; set; }
        public virtual DbSet<Dp03amov> Dp03amov { get; set; }
        public virtual DbSet<Dp05a120> Dp05a120 { get; set; }
        public virtual DbSet<Dp05a130> Dp05a130 { get; set; }
        public virtual DbSet<Dp05acab> Dp05acab { get; set; }
        public virtual DbSet<Dpinvcab> Dpinvcab { get; set; }
        public virtual DbSet<Entidad> Entidad { get; set; }
        public virtual DbSet<Pais> Pais { get; set; }
        public virtual DbSet<Parroquia> Parroquia { get; set; }
        public virtual DbSet<Provincia> Provincia { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("Modern_Spanish_CI_AS");

            modelBuilder.ApplyConfiguration(new Configurations.AlptablaConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.CarritoConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.CiudadConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.Dp03a110Configuration());
            modelBuilder.ApplyConfiguration(new Configurations.Dp03acomConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.Dp03amovConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.Dp05a120Configuration());
            modelBuilder.ApplyConfiguration(new Configurations.Dp05a130Configuration());
            modelBuilder.ApplyConfiguration(new Configurations.Dp05acabConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.DpinvcabConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.EntidadConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.PaisConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.ParroquiaConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.ProvinciaConfiguration());
            OnModelCreatingGeneratedProcedures(modelBuilder);
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
