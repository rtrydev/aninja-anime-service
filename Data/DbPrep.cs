using aninja_anime_service.Enums;
using aninja_anime_service.Models;
using Microsoft.EntityFrameworkCore;

namespace aninja_anime_service.Data;

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
        context.Database.Migrate();
    }
}