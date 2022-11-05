using Microsoft.EntityFrameworkCore;
using TP_GSC_BackEnd.Configuration;
using TP_GSC_BackEnd.Data_Access;
using TP_GSC_BackEnd.Data_Access.Uow;
using TP_GSC_BackEnd.Dto;
using TP_GSC_BackEnd.Extension_Methods;
using TP_GSC_BackEnd.Handlers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<LoanDBContext>(
    options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LoansContextConnection"))
);
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddAutoMapper(typeof(DtoMapperProfile));

builder.Services.AddRazorPages();


builder.AddAuthenticationJwt();
builder.Services.AddAuthorization();
builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("JWT"));
builder.Services.AddScoped<IJwtHandler, JwtHandler>();

var app = builder.Build();




if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapRazorPages();

app.MapControllerRoute(
       name: "default",
       pattern: "{controller}/{action=Index}/{id?}");



app.Run();
