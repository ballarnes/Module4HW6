using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4HW6.DataAccess.Entities;

namespace Module4HW6.DataAccess.Configurations
{
    public class ArtistSongConfiguration : IEntityTypeConfiguration<ArtistSong>
    {
        public void Configure(EntityTypeBuilder<ArtistSong> builder)
        {
            builder.ToTable("ArtistSong").HasKey(a => a.Id);
            builder.Property(a => a.ArtistId).IsRequired();
            builder.Property(a => a.SongId).IsRequired();

            builder.HasOne(a => a.Artist)
                .WithMany(p => p.ArtistSong)
                .HasForeignKey(a => a.ArtistId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(s => s.Song)
                .WithMany(p => p.ArtistSong)
                .HasForeignKey(s => s.SongId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
                new ArtistSong { Id = 1, ArtistId = 1, SongId = 1 },
                new ArtistSong { Id = 2, ArtistId = 6, SongId = 1 },
                new ArtistSong { Id = 3, ArtistId = 3, SongId = 2 },
                new ArtistSong { Id = 4, ArtistId = 4, SongId = 3 },
                new ArtistSong { Id = 5, ArtistId = 4, SongId = 4 },
                new ArtistSong { Id = 6, ArtistId = 2, SongId = 4 },
                new ArtistSong { Id = 7, ArtistId = 6, SongId = 5 },
                new ArtistSong { Id = 8, ArtistId = 5, SongId = 6 });
        }
    }
}
