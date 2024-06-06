using Microsoft.EntityFrameworkCore;
using WebApi.Contest;
using WebApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AplicationDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConection")));
builder.Services.AddTransient<IUsuarioService, UsuarioService>();
builder.Services.AddTransient<IAutorService, AutorService>();
builder.Services.AddTransient<ILibroService, LibroService>();
builder.Services.AddTransient<ITransferService, TransferService>();
builder.Services.AddCors(options => options.AddPolicy("AllowWebApp", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));
var app = builder.Build();
app.UseCors("AllowWebApp");
//Agregando el corsPolicy
//builder.Services.AddCors(policyBuilder =>
//policyBuilder.AddDefaultPolicy(policy =>
//policy.WithOrigins("*").AllowAnyHeader().AllowAnyMethod())
//);
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
