using ContainersApp.Options;
using ContainersApp.Services.ProductService;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddRazorPages();

var globalSettings = new GlobalSettings();
builder.Configuration.GetSection(nameof(GlobalSettings)).Bind(globalSettings);
builder.Services.AddSingleton(globalSettings);

if (globalSettings.UseDataBase)
{
    builder.Services.AddTransient<IProductService, ProductService>();
}
else
{
    builder.Services.AddTransient<IProductService, LocalProductService>();
}


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

app.Run();
