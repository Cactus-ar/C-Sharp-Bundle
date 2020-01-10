using Clientes.Core.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clientes.Data.Configuracion
{
    public class ComprasConfig : IEntityTypeConfiguration<Compra>
    {
        public void Configure(EntityTypeBuilder<Compra> constructor)
        {
            constructor
                .HasKey(m => m.Id);

            constructor
                .Property(m => m.Id)
                .UseIdentityColumn();

            constructor
                .Property(m => m.Descripcion)
                .IsRequired()
                .HasMaxLength(100);

            constructor
                .HasOne(m => m.Cliente)
                .WithMany(a => a.Compras)
                .HasForeignKey(m => m.ClienteId);

            constructor
                .ToTable("Compras");
        }
    }
}
