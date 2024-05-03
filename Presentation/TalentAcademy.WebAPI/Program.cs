using Microsoft.EntityFrameworkCore;
using TalentAcademy.Application;
using TalentAcademy.Application.Features.Queries.Students.GetAllStudent;
using TalentAcademy.Application.Features.Queries.Students.GetByIdStudent;
using TalentAcademy.Application.Repositories;
using TalentAcademy.Persistence.Context;
using TalentAcademy.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TalentAcademyDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
builder.Services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));

builder.Services.AddScoped<GetAllStudentsQueryHandler>();
builder.Services.AddScoped<GetStudentByIdQueryHandler>();



builder.Services.AddApplicationServices();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
