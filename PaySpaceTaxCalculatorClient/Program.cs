using PaySpaceTaxCalculatorClient;
using PaySpaceTaxCalculatorClient.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddHttpClient();
builder.Services.AddHttpContextAccessor();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(43200);
    options.Cookie.HttpOnly = true;
    //options.Cookie.IsEssential = true;
});

builder.Services.AddMvc(options =>
{
    options.Filters.Add(new ClientErrorHandler());
});

var app = builder.Build();

app.InitializeApplicationSettings();

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
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=ApplicationUser}/{action=Home}/{id?}");

app.Run();

