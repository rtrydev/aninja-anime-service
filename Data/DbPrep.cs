using aninja_browse_service.Enums;
using aninja_browse_service.Models;

namespace aninja_browse_service.Data;

public class DbPrep
{
    public static void PrepData(IApplicationBuilder app)
    {
        using (var serviceScope = app.ApplicationServices.CreateScope())
        {
            SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());    
        }
    }

    private static void SeedData(AppDbContext context)
    {
        context.Animes.AddRange(
            new Anime() {Id = Guid.NewGuid(), OriginalTitle = "とらドラ！", TranslatedTitle = "Toradora!", Categories = new [] {Category.Drama, Category.Romance, Category.SliceOfLife}, Demographic = Demographic.Seinen, Description = "Some description", Status = Status.FinishedAiring, EpisodeCount = 25, StartDate = new DateOnly(2008, 10, 2), EndDate = new DateOnly(2009, 3, 26)},
            new Anime() {Id = Guid.NewGuid(), OriginalTitle = "うみねこのなく頃に", TranslatedTitle = "Umineko no naku koro ni", Categories = new [] {Category.Horror, Category.Mystery, Category.Supernatural}, Demographic = Demographic.Seinen, Description = "Some description", Status = Status.FinishedAiring, EpisodeCount = 26, StartDate = new DateOnly(2006, 4, 5), EndDate = new DateOnly(2009, 12, 24)},
            new Anime() {Id = Guid.NewGuid(), OriginalTitle = "ひぐらしのなく頃に", TranslatedTitle = "Higurashi no naku koro ni", Categories = new [] {Category.Horror, Category.Mystery, Category.Supernatural}, Demographic = Demographic.Seinen, Description = "Some description", Status = Status.FinishedAiring, EpisodeCount = 25, StartDate = new DateOnly(2008, 10, 2), EndDate = new DateOnly(2006, 9, 27)}
        );
        context.SaveChanges();
    }
}