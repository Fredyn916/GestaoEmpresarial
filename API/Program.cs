using Core.Entity;
using Core.Interface;
using Core.Interface.Repository;
using Core.Interface.Repository.Generic;
using Core.Interface.Service;
using Core.Interface.Service.Generic;
using Core.Repository;
using Core.Repository.Generic;
using Core.Service;
using Core.Service.Generic;
using Entidades.DTO;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("MyDbContextConnection")));

DependencyInjections.DIs(builder.Services);

builder.Services.AddAutoMapper(typeof(MappingProfile));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
