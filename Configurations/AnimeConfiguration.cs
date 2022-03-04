using aninja_browse_service.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace aninja_browse_service.Configurations;

public class AnimeConfiguration : IEntityTypeConfiguration<Anime>
{
    public void Configure(EntityTypeBuilder<Anime> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();

    }
}