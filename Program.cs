using Microsoft.EntityFrameworkCore;
using ProductApi.Data;             // <- aquí garantizarás que AppDbContext se resuelva

var builder = WebApplication.CreateBuilder(args);

// 1) CORS para permitir llamadas desde Angular
builder.Services.AddCors(o => o.AddPolicy("AllowAngularDev", p =>
    p.WithOrigins("http://localhost:4200")
     .AllowAnyMethod()
     .AllowAnyHeader()
));

// 2) Registrar EF Core + SQL Server
builder.Services.AddDbContext<AppDbContext>(opts =>
    opts.UseSqlServer(builder.Configuration.GetConnectionString("Default"))
);

// 3) Registro de servicios MVC / Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 4) Usar CORS antes de MapControllers
app.UseCors("AllowAngularDev");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
