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
        context.Genres.AddRange(
            new []
            {
                new Genre() {Id = 1, Name = "Action"},
                new Genre() {Id = 2, Name = "Adventure"},
                new Genre() {Id = 3, Name = "Comedy"},
                new Genre() {Id = 4, Name = "Drama"},
                new Genre() {Id = 5, Name = "Fantasy"},
                new Genre() {Id = 6, Name = "Horror"},
                new Genre() {Id = 7, Name = "Mystery"},
                new Genre() {Id = 8, Name = "Romance"},
                new Genre() {Id = 9, Name = "SciFi"},
                new Genre() {Id = 10, Name = "SliceOfLife"},
                new Genre() {Id = 11, Name = "Sports"},
                new Genre() {Id = 12, Name = "Supernatural"},
                
            }
        );

        context.SaveChanges();

        context.Animes.AddRange(
            new Anime() {Id = 1, OriginalTitle = "とらドラ！", TranslatedTitle = "Toradora!", Genres = context.Genres.Where(x => x.Id == 3 || x.Id == 8 || x.Id == 10).ToList(), Demographic = Demographic.Seinen, Description = "Some description", Status = Status.FinishedAiring, EpisodeCount = 25, StartDate = new DateTime(2008, 10, 2), EndDate = new DateTime(2009, 3, 26)},
            new Anime() {Id = 2, OriginalTitle = "うみねこのなく頃に", TranslatedTitle = "Umineko no naku koro ni", Genres = context.Genres.Where(x => x.Id == 6 || x.Id == 7 || x.Id == 12).ToList(), Demographic = Demographic.Seinen, Description = "Some description", Status = Status.FinishedAiring, EpisodeCount = 26, StartDate = new DateTime(2009, 7, 2), EndDate = new DateTime(2009, 12, 24)},
            new Anime() {Id = 3, OriginalTitle = "ひぐらしのなく頃に", TranslatedTitle = "Higurashi no naku koro ni", Genres = context.Genres.Where(x => x.Id == 6 || x.Id == 7 || x.Id == 12).ToList(), Demographic = Demographic.Seinen, Description = "Some description", Status = Status.FinishedAiring, EpisodeCount = 25, StartDate = new DateTime(2006, 4, 5), EndDate = new DateTime(2006, 9, 27)}
        );
        
        
        context.SaveChanges();
    }
}