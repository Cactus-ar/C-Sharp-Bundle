using Clientes.Core.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clientes.Data.Configuracion
{
    public class ClientesConfig : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> constructor)
        {
            constructor
                .HasKey(cl => cl.Id);

            constructor
                .Property(cl => cl.Id)
                .UseIdentityColumn();

            constructor
                .Property(cl => cl.Nombre)
                .IsRequired()
                .HasMaxLength(50);

            constructor
                .ToTable("Clientes");
        }
    }
}
