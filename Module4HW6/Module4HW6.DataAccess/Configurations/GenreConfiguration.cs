using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4HW6.DataAccess.Entities;

namespace Module4HW6.DataAccess.Configurations
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.ToTable("Genre").HasKey(g => g.Id);
            builder.Property(g => g.Title).IsRequired();

            builder.HasData(
                new Genre { Id = 1, Title = "Rock" },
                new Genre { Id = 2, Title = "Pop" },
                new Genre { Id = 3, Title = "Rap" },
                new Genre { Id = 4, Title = "Blues" },
                new Genre { Id = 5, Title = "Dance" });
        }
    }
}
