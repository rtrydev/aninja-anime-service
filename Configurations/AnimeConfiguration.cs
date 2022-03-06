using aninja_anime_service.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace aninja_anime_service.Configurations;

public class AnimeConfiguration : IEntityTypeConfiguration<Anime>
{
    public void Configure(EntityTypeBuilder<Anime> builder)
    {
        builder.ToTable("animes").HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Demographic)
            .HasColumnName("demographic")
            .IsRequired();

        builder.Property(x => x.OriginalTitle)
            .HasColumnName("original_title")
            .IsRequired();

        builder.Property(x => x.TranslatedTitle)
            .HasColumnName("translated_title")
            .IsRequired();

        builder.Property(x => x.Description)
            .HasColumnName("description")
            .IsRequired(false);

        builder.Property(x => x.ImgUrl)
            .HasColumnName("img_url")
            .IsRequired(false);

        builder.Property(x => x.StartDate)
            .HasColumnName("start_date")
            .IsRequired();

        builder.Property(x => x.EndDate)
            .HasColumnName("end_date")
            .IsRequired();

        builder.Property(x => x.EpisodeCount)
            .HasColumnName("episode_count");

        builder.Property(x => x.Status)
            .HasColumnName("status")
            .IsRequired();
        

    }
}