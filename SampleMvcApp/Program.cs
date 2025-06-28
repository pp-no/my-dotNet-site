using Microsoft.EntityFrameworkCore;
using SampleMvcApp.Data;

var builder = WebApplication.CreateBuilder(args);

var dbPath = Path.Combine(AppContext.BaseDirectory, "app.db");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite($"Data Source={dbPath}").LogTo(Console.WriteLine));

// MVCコントローラ＋ビュー
builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
