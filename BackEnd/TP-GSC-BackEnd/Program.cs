using Microsoft.EntityFrameworkCore;
using TP_GSC_BackEnd.Data_Access;
using TP_GSC_BackEnd.Data_Access.Uow;
using TP_GSC_BackEnd.Dto;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<LoanDBContext>(
    options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LoansContextConnection"))
);

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddAutoMapper(typeof(DtoMapperProfile));

builder.Services.AddRazorPages();



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

app.MapControllerRoute(
       name: "default",
       pattern: "{controller}/{action=Index}/{id?}");



app.Run();
