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
    public partial class Dp03a110Configuration : IEntityTypeConfiguration<Dp03a110>
    {
        public void Configure(EntityTypeBuilder<Dp03a110> entity)
        {
            entity.Property(e => e.Aplica)
                .HasMaxLength(70)
                .IsUnicode(false);

            entity.Property(e => e.Clase)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength();

            entity.Property(e => e.Codigo)
                .IsRequired()
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.Property(e => e.CodigoBarra)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.CodigoInterno)
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.Property(e => e.Color)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();

            entity.Property(e => e.Comentario)
                .HasMaxLength(150)
                .IsUnicode(false);

            entity.Property(e => e.Cuenta)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.Cuenta2)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.Cuenta3)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.Factor)
                .HasColumnType("decimal(6, 0)")
                .HasDefaultValueSql("((1))");

            entity.Property(e => e.FechaIngreso).HasColumnType("datetime");

            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

            entity.Property(e => e.FechaUltimaCompra).HasColumnType("datetime");

            entity.Property(e => e.FechaUltimaVenta).HasColumnType("datetime");

            entity.Property(e => e.Imagen)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.Property(e => e.IpIngreso)
                .IsRequired()
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.Property(e => e.IpModificacion)
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.Property(e => e.IvaSn)
                .IsRequired()
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("IvaSN")
                .HasDefaultValueSql("('S')")
                .IsFixedLength();

            entity.Property(e => e.Marca)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.Modelo)
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(70)
                .IsUnicode(false);

            entity.Property(e => e.Origen)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.PideSerie).HasDefaultValueSql("((0))");

            entity.Property(e => e.PorcentajeDescuento).HasColumnType("decimal(6, 2)");

            entity.Property(e => e.Presentacion)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.PvpA).HasColumnType("decimal(16, 4)");

            entity.Property(e => e.PvpB).HasColumnType("decimal(16, 4)");

            entity.Property(e => e.PvpC).HasColumnType("decimal(16, 4)");

            entity.Property(e => e.PvpD).HasColumnType("decimal(16, 4)");

            entity.Property(e => e.PvpE).HasColumnType("decimal(16, 4)");

            entity.Property(e => e.SubClase)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength();

            entity.Property(e => e.Talla)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();

            entity.Property(e => e.Tipo)
                .IsRequired()
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("('N')")
                .IsFixedLength();

            entity.Property(e => e.Ubica)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();

            entity.Property(e => e.Unidad)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();

            entity.Property(e => e.UsuarioIngreso)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.ValidaStock)
                .IsRequired()
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("('S')")
                .IsFixedLength();

            entity.Property(e => e.ValorUltimaCompra).HasColumnType("decimal(16, 2)");

            entity.Property(e => e.ValorUltimaVenta).HasColumnType("decimal(16, 2)");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Dp03a110> entity);
    }
}
