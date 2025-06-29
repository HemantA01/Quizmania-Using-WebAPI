using QuizMania1.UI.Interface;
using QuizMania1.UI.Service;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    //options.Cookie.Name = "ephr";  
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = false;
    options.Cookie.IsEssential = false;
});
//builder.Services.AddRazorPages().AddRzorRuntimeCompilation();
// Add services to the container.
builder.Services.AddControllersWithViews();
//builder.Services.AddSession();
builder.Services.AddScoped<IUserLogin, UserLogin>();
builder.Services.AddScoped<ICountryMaster, CountryMaster>();
builder.Services.AddScoped<IStateMaster, StateMaster>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
//builder.Services.AddMemoryCache();

var app = builder.Build();
app.UseSession();
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
    pattern: "{controller=Login}/{action=Index}/{id?}");
    //pattern: "{controller=Home}/{action=Dashboard}/{id?}");
//pattern: "{controller=Master}/{action=GetAllCountries}/{id?}");

app.Run();
