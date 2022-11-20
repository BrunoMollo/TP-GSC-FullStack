using Microsoft.EntityFrameworkCore;
using TP_GSC_BackEnd.Configuration;
using TP_GSC_BackEnd.Data_Access;
using TP_GSC_BackEnd.Data_Access.Uow;
using TP_GSC_BackEnd.Dto;
using TP_GSC_BackEnd.Extension_Methods;
using TP_GSC_BackEnd.Handlers;
using TP_GSC_BackEnd.Protos;
using TP_GSC_BackEnd.Services.Loans;

var builder = WebApplication.CreateBuilder(args);

builder.AddCorsLocalhost();

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

builder.Services.AddGrpc(opt => {
    opt.EnableDetailedErrors = true;
});
builder.Services.AddGrpcReflection();

builder.Services.AddScoped<ILoansService, LoansService>();



var app = builder.Build();





if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseStaticFiles();

if (app.Environment.IsDevelopment()) {
    app.UseCors();
    app.MapGrpcReflectionService();
} 
   

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapRazorPages();

app.MapControllerRoute(
       name: "default",
       pattern: "{controller}/{action=Index}/{id?}");


app.MapGrpcService<LoansGrpc>();



app.Run();
