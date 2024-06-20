using LocadoraVeiculosApi.Data;
using LocadoraVeiculosApi.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Adiciona o serviço de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

// Adiciona outros serviços...
builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Adiciona serviços do aplicativo (services)
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "VehicleRentalSystem", Version = "v1" });
});
builder.Services.AddScoped<VeiculoService>();
builder.Services.AddScoped<ClienteService>();
builder.Services.AddScoped<LocacaoService>();

// Adiciona Swagger
builder.Services.AddSwaggerGen();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "VehicleRentalSystem v1"));
}

app.UseHttpsRedirection();

app.UseRouting();

// Habilita o middleware de CORS
app.UseCors("AllowAll   ins");

app.UseAuthorization();

app.MapControllers();

app.Run();
