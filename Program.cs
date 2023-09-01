using Microsoft.EntityFrameworkCore;
using ApiHexagon.Db;
using ApiHexagon.Services;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddRazorPages();

// Configuração do DbContext
builder.Services.AddDbContext<MeuDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MeuBancoConnection"));
});

// configuração para o serviço PessoaService
builder.Services.AddScoped<PessoaService>(); 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.MapControllers(); 

app.Run();
