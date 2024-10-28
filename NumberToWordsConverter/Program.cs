// Program.cs


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Set "Conversion" as the default controller and "Index" as the default action
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Conversion}/{action=Index}/{id?}");

app.Run();

