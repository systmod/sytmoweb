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
    public partial class Dp05a120Configuration : IEntityTypeConfiguration<Dp05a120>
    {
        public void Configure(EntityTypeBuilder<Dp05a120> entity)
        {
            entity.Property(e => e.Cuenta)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Entidad)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();

            entity.Property(e => e.FechaIngreso).HasColumnType("datetime");

            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

            entity.Property(e => e.GeneraNc).HasColumnName("GeneraNC");

            entity.Property(e => e.GeneraNd).HasColumnName("GeneraND");

            entity.Property(e => e.IpIngreso)
                .IsRequired()
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.Property(e => e.IpModificacion)
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.Property(e => e.NombreCorto)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.TipoNc)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("TipoNC")
                .IsFixedLength();

            entity.Property(e => e.TipoNd)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("TipoND")
                .IsFixedLength();

            entity.Property(e => e.UsuarioIngreso)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .IsUnicode(false);

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Dp05a120> entity);
    }
}