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
    public partial class DpinvcabConfiguration : IEntityTypeConfiguration<Dpinvcab>
    {
        public void Configure(EntityTypeBuilder<Dpinvcab> entity)
        {
            entity.HasIndex(e => e.Fecha, "fecha_tra");

            entity.HasIndex(e => e.IdEntidad, "prov_cli");

            entity.Property(e => e.Asiento)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.Property(e => e.Base0).HasColumnType("decimal(16, 2)");

            entity.Property(e => e.BaseIva).HasColumnType("decimal(16, 2)");

            entity.Property(e => e.Bodega)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();

            entity.Property(e => e.BodegaDestino)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();

            entity.Property(e => e.CodigoEgreso)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();

            entity.Property(e => e.CodigoIngreso)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();

            entity.Property(e => e.Comentario)
                .HasMaxLength(250)
                .IsUnicode(false);

            entity.Property(e => e.FacturaProveedor)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.Fecha).HasColumnType("datetime");

            entity.Property(e => e.FechaIngreso).HasColumnType("datetime");

            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

            entity.Property(e => e.FechaVencimiento).HasColumnType("datetime");

            entity.Property(e => e.Grupo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();

            entity.Property(e => e.GuiaRemision)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.IpIngreso)
                .IsRequired()
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.Property(e => e.IpModificacion)
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.Property(e => e.Numero)
                .IsRequired()
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength();

            entity.Property(e => e.NumeroB)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            entity.Property(e => e.OrdenCompra)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.PorcentajeDescuento)
                .HasColumnType("decimal(6, 2)")
                .HasDefaultValueSql("((0))");

            entity.Property(e => e.PorcentajeIva)
                .HasColumnType("decimal(6, 2)")
                .HasDefaultValueSql("((0))");

            entity.Property(e => e.Referencia)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Subtotal).HasColumnType("decimal(16, 2)");

            entity.Property(e => e.Tipo)
                .IsRequired()
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();

            entity.Property(e => e.TipoPrecio)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();

            entity.Property(e => e.TipoT)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Tipo_t")
                .IsFixedLength();

            entity.Property(e => e.Total).HasColumnType("decimal(16, 2)");

            entity.Property(e => e.TotalDescuento)
                .HasColumnType("decimal(16, 2)")
                .HasDefaultValueSql("((0))");

            entity.Property(e => e.TotalIva)
                .HasColumnType("decimal(16, 2)")
                .HasDefaultValueSql("((0))");

            entity.Property(e => e.UsuarioIngreso)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Vendedor)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.IdEntidadNavigation)
                .WithMany(p => p.Dpinvcab)
                .HasForeignKey(d => d.IdEntidad)
                .HasConstraintName("FK_Dpinvcab_Entidad");

            entity.HasOne(d => d.TipoNavigation)
                .WithMany(p => p.Dpinvcab)
                .HasForeignKey(d => d.Tipo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Dpinvcab_Dp03acom");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Dpinvcab> entity);
    }
}