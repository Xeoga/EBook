using Microsoft.EntityFrameworkCore;
using EBook.Domain;
using EBook.BussinesLogic.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<IPublishingHouse, PublishingHouseService>();
builder.Services.AddScoped<ICategorieService, CategorieService>();

//DB
var connectionString = builder.Configuration.GetConnectionString("DbConnection");
builder.Services.AddDbContext<EBookAppContext>(options => options.UseSqlServer(connectionString));

var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
