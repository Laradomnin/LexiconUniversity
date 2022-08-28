﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using LexiconUniversity.Data;
using AutoMapper;
using LexiconUniversity.Web.AutoMapper;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<LexiconUniversityContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LexiconUniversityContext") ?? throw new InvalidOperationException("Connection string 'LexiconUniversityContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(typeof(MapperProfile));

var app = builder.Build();

//Seeddata
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<LexiconUniversityContext>();
    //db.Database.EnsureDeleted();
    //db.Database.Migrate();
    try
    {
        await SeedData.InitAsync(db);
    }
    catch(Exception e)
    {
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
        logger.LogError(string.Join(" ", e.Message));
    }
}
    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Students}/{action=Index}/{id?}");

app.Run();
