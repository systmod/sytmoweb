﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using DataAccess.Models;
using DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace DataAccess.Repositories.Configurations
{
    public partial class CarritoConfiguration : IEntityTypeConfiguration<Carrito>
    {
        public void Configure(EntityTypeBuilder<Carrito> entity)
        {
            entity.Property(e => e.FechaIngreso)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(dateadd(hour,(-5),getdate()))");

            entity.Property(e => e.NoParte)
                .IsRequired()
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("No_Parte");

            entity.Property(e => e.PrecioT)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Precio_t");

            entity.Property(e => e.PrecioU)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Precio_u");

            entity.Property(e => e.Proforma)
                .HasMaxLength(10)
                .IsFixedLength();

            entity.Property(e => e.TipoPrecio)
                .IsRequired()
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Carrito> entity);
    }
}
