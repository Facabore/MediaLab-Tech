using MediaLab.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace MediaLab.Api.Extensions;

internal static class ApplicationBuilderExtensions
{
    public static void ApplyMigrations(this IApplicationBuilder app)
    {
        using IServiceScope scope = app.ApplicationServices.CreateScope();

        using ApplicationDbContext dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        
        try
        {
            dbContext.Database.Migrate();

        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}