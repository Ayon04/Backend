using FluentValidation;
using FluentValidation.AspNetCore;
using HanaHRM.DataAccess.Models;
using HanaHRM.DTO;
using HanaHRM.Validation;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<HRMContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddControllers().AddFluentValidation(fv =>
{
    fv.RegisterValidatorsFromAssemblyContaining<EmployeeDTOValidator>();
    fv.RegisterValidatorsFromAssemblyContaining<EmployeeDocumentDTOValidator>();
    fv.RegisterValidatorsFromAssemblyContaining<EmployeeEducationInfoDTOValidator>();
    fv.RegisterValidatorsFromAssemblyContaining<EmployeeProfessionalCertificationDTOValidator>();
});
/*

builder.Services.AddScoped<IValidator<EmployeeDTO>, EmployeeDTOValidator>();
builder.Services.AddScoped<IValidator<EmployeeDocumentDTO>, EmployeeDocumentDTOValidator>();
builder.Services.AddScoped<IValidator<EmployeeEducationInfoDTO>, EmployeeEducationInfoDTOValidator>();
builder.Services.AddScoped<IValidator<EmployeeProfessionalCertificationDTO>, EmployeeProfessionalCertificationDTOValidator>();
builder.Services.AddAuthorization(); 

*/

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "HANA HRM System APIs", Version = "v1" });
});
builder.Services.AddCors(options =>

{

    options.AddPolicy("AllowAngularDev",

        builder => builder.WithOrigins("http://localhost:4200")

                          .AllowAnyMethod()

                          .AllowAnyHeader());

});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    c.RoutePrefix = "";
});
app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseCors("AllowAngularDev");
app.UseAuthorization();

app.MapControllers();

app.Run();
