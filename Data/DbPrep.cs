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
        
        context.SaveChanges();

        context.Animes.AddRange(
            new Anime() {Id = 1, OriginalTitle = "とらドラ！", TranslatedTitle = "Toradora!", Demographic = Demographic.Seinen, Description = "Some description", Status = Status.FinishedAiring, EpisodeCount = 25, StartDate = new DateTime(2008, 10, 2), EndDate = new DateTime(2009, 3, 26)},
            new Anime() {Id = 2, OriginalTitle = "うみねこのなく頃に", TranslatedTitle = "Umineko no naku koro ni", Demographic = Demographic.Seinen, Description = "Some description", Status = Status.FinishedAiring, EpisodeCount = 26, StartDate = new DateTime(2009, 7, 2), EndDate = new DateTime(2009, 12, 24)},
            new Anime() {Id = 3, OriginalTitle = "ひぐらしのなく頃に", TranslatedTitle = "Higurashi no naku koro ni", Demographic = Demographic.Seinen, Description = "Some description", Status = Status.FinishedAiring, EpisodeCount = 25, StartDate = new DateTime(2006, 4, 5), EndDate = new DateTime(2006, 9, 27)}
        );
        
        
        context.SaveChanges();
    }
}