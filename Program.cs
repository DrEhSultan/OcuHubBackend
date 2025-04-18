using Microsoft.EntityFrameworkCore;
using OcuHubBackend.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ✅ نضيف الكونكشن من الإنفايرومنت
builder.Services.AddDbContext<OcuHubDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// ✅ نعمل الميجريشن أوتوماتيك لما السيرفر يشتغل
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<OcuHubDbContext>();
    db.Database.Migrate(); // يعمل ميجريشن أوتوماتيك
    DbInitializer.SeedData(db); // لو عندك بيانات Seed
}

// Enable Swagger
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "OcuHub API V1");
    c.RoutePrefix = "swagger";
});

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.MapGet("/health", () => Results.Ok("Healthy"));

app.Run();