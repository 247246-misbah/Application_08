using Microsoft.EntityFrameworkCore;
using ToDoListApp.Data;
using ToDoListApp.Components; // اگر آپ کے پاس Components کا فولڈر ہے تو یہ نیم اسپیس لازمی ہوگی

var builder = WebApplication.CreateBuilder(args);

// 1. یہاں مائی ایس کیو ایل (MySQL) کا ڈیٹا بیس کانٹیکسٹ رجسٹر ہو رہا ہے
builder.Services.AddDbContext<AppDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    // یہ فنکشن خود بخود phpMyAdmin سے آپ کا MySQL ورژن ڈیٹیکٹ کر لے گا
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

// بلازر سرور کی سروسز ایڈ کریں
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// 2. ایچ ٹی ٹی پی (HTTP) ریکویسٹ پائپ لائن کی کنفیگریشن
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();
app.UseAntiforgery();
app.MapStaticAssets();

// بلازر کے روٹس اور رینڈر موڈ کی میپنگ
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();