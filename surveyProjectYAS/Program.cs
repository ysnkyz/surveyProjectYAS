using Microsoft.EntityFrameworkCore;
using surveyProjectYAS.Models; 

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<SurveyContext>(options =>
    options.UseSqlite("Data Source=Data/survey.db"));

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Survey}/{action=Index}/{id?}");

app.Run();
