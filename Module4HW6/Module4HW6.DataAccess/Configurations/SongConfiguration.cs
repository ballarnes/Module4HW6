using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4HW6.DataAccess.Entities;

namespace Module4HW6.DataAccess.Configurations
{
    public class SongConfiguration : IEntityTypeConfiguration<Song>
    {
        public void Configure(EntityTypeBuilder<Song> builder)
        {
            builder.ToTable("Song").HasKey(s => s.Id);
            builder.Property(s => s.Title).IsRequired();
            builder.Property(s => s.Duration).IsRequired();
            builder.Property(s => s.ReleasedDate).IsRequired();

            builder.HasOne(s => s.Genre)
                .WithMany(g => g.Songs)
                .HasForeignKey(s => s.GenreId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);

            builder.HasData(
                new Song { Id = 1, Title = "Song1", Duration = 231, ReleasedDate = new DateTime(2007, 05, 05), GenreId = 5 },
                new Song { Id = 2, Title = "Song2", Duration = 161, ReleasedDate = new DateTime(2016, 07, 12), GenreId = 2 },
                new Song { Id = 3, Title = "Song3", Duration = 177, ReleasedDate = new DateTime(1950, 08, 24), GenreId = 4 },
                new Song { Id = 4, Title = "Song4", Duration = 190, ReleasedDate = new DateTime(1969, 10, 09) },
                new Song { Id = 5, Title = "Song5", Duration = 177, ReleasedDate = new DateTime(2017, 04, 07), GenreId = 3 },
                new Song { Id = 6, Title = "Song6", Duration = 180, ReleasedDate = new DateTime(2012, 08, 01), GenreId = 1 });
        }
    }
}
