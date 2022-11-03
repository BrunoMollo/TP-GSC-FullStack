using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using TP_GSC_BackEnd.Data_Access;
using TP_GSC_BackEnd.Data_Access.CategoryData;
using TP_GSC_BackEnd.Data_Access.PersonData;
using TP_GSC_BackEnd.Data_Access.Uow;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

//builder.Services.AddControllers()
//    .AddJsonOptions(x =>
//    {
//        x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
//        x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
//    }
//);
builder.Services.AddDbContext<LoanDBContext>(
    options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LoansContextConnection"))
);



builder.Services.AddRazorPages();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();




if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();


app.UseAuthorization();

app.MapRazorPages();

app.UseEndpoints(endpoints =>
{
    //endpoints.MapControllers();
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

//app.MapControllerRoute(
//       name: "default",
//       pattern: "{controller}/{action=Index}/{id?}");



app.Run();
