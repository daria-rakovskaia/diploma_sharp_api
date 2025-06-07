using diploma_sharp_api.Models;
using diploma_sharp_api.Services.AnalysisService;
using diploma_sharp_api.Services.ExamTaskService;
using diploma_sharp_api.Services.GroupService;
using diploma_sharp_api.Services.PDFService;
using diploma_sharp_api.Services.ResultService;
using diploma_sharp_api.Services.StudentService;
using diploma_sharp_api.Services.TeacherService;
using diploma_sharp_api.Services.VariantService;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<HseExamProgContext>();

builder.Services.AddScoped<IAnalysisService, AnalysisService>();
builder.Services.AddScoped<ITeacherService, TeacherService>();
builder.Services.AddScoped<IGroupService, GroupService>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IVariantService, VariantService>();
builder.Services.AddScoped<IExamTaskService, ExamTaskService>();
builder.Services.AddScoped<IResultService, ResultService>();
builder.Services.AddScoped<IPDFService, PDFService>();

var app = builder.Build();

app.UseCors();
app.UseCors(builder =>
{
    builder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.MapControllers();

app.Run();
