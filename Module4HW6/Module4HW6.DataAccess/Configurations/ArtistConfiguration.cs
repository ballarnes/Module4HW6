using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4HW6.DataAccess.Entities;

namespace Module4HW6.DataAccess.Configurations
{
    public class ArtistConfiguration : IEntityTypeConfiguration<Artist>
    {
        public void Configure(EntityTypeBuilder<Artist> builder)
        {
            builder.ToTable("Artist").HasKey(a => a.Id);
            builder.Property(a => a.Name).IsRequired();
            builder.Property(a => a.DateOfBirth).IsRequired();

            builder.HasData(
                new Artist { Id = 1, Name = "Artist1", DateOfBirth = new DateTime(1985, 02, 15), IsAlive = true, Phone = "+11111111111", Email = "artist1@email.com", InstagramURL = "https://www.instagram.com/artist1" },
                new Artist { Id = 2, Name = "Artist2", DateOfBirth = new DateTime(1942, 06, 03), IsAlive = false },
                new Artist { Id = 3, Name = "Artist3", DateOfBirth = new DateTime(1972, 01, 14), IsAlive = true, Phone = "+33333333333", Email = "artist3@email.com", InstagramURL = "https://www.instagram.com/artist3" },
                new Artist { Id = 4, Name = "Artist4", DateOfBirth = new DateTime(1934, 11, 01), IsAlive = false },
                new Artist { Id = 5, Name = "Artist5", DateOfBirth = new DateTime(1992, 03, 17), IsAlive = true, Phone = "+55555555555", Email = "artist5@email.com", InstagramURL = "https://www.instagram.com/artist5" },
                new Artist { Id = 6, Name = "Artist6", DateOfBirth = new DateTime(1990, 05, 11), IsAlive = true, Phone = "+66666666666", Email = "artist6@email.com", InstagramURL = "https://www.instagram.com/artist6" });
        }
    }
}
