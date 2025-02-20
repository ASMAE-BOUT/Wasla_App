using Microsoft.EntityFrameworkCore;
using Wasla_App.Data;
using Wasla_App.Models;

var builder = WebApplication.CreateBuilder(args);

// Configurer la journalisation
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// Ajouter les services au conteneur.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ContexteBaseDonnees>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configurer le pipeline de requêtes HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler(errorApp =>
    {
        errorApp.Run(async context =>
        {
            context.Response.StatusCode = 500;
            context.Response.ContentType = "text/html";

            var errorModel = new ErrorModel
            {
                RequestId = context.TraceIdentifier
            };

            // Render the error view
            await context.Response.WriteAsync("<html lang=\"en\"><head><title>Error</title></head><body>");
            await context.Response.WriteAsync($"<h1>An error occurred</h1><p>Request ID: {errorModel.RequestId}</p>");
            await context.Response.WriteAsync("</body></html>");
        });
    });
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Configurer les routes par défaut
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
