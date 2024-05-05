using TalentAcademy.Application;
using TalentAcademy.Persistence;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddScoped<GetAllStudentsQueryHandler>();
//builder.Services.AddScoped<GetStudentByIdQueryHandler>();


builder.Services.AddApplicationServices();

builder.Services.AddPersistenceServices(builder.Configuration);




builder.Services.AddControllers().AddNewtonsoftJson(opt =>
{
    opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});
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
