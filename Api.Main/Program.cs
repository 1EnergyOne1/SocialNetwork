var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
//builder.Services.AddControllersWithViews();
builder.Services.AddControllers();

builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
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
app.UseCors(builder => builder.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod());

app.MapControllers();

//app.MapGet("/", () => "Hello World!");

//app.MapPost("/data", async (HttpContext httpContext) =>
//{
//    using StreamReader reader = new StreamReader(httpContext.Request.Body);
//    string name = await reader.ReadToEndAsync();
//    return $"Получены данные: {name}";
//});

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Get}");


app.Run();
