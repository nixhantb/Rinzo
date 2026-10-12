using System.Text;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Rinzo.Core.Entities.Common.V1;
using Rinzo.Core.Entities.Companies.V1;
using Rinzo.Core.Entities.Employers.V1;
using Rinzo.Core.Entities.Identity;
using Rinzo.Core.Entities.Jobs.V1;
using Rinzo.Core.Entities.Seekers.V1;
using Rinzo.Core.Interfaces.Common.V1;
using Rinzo.Core.Interfaces.Companies.V1;
using Rinzo.Core.Interfaces.Employers.V1;
using Rinzo.Core.Interfaces.Jobs.V1;
using Rinzo.Core.Interfaces.Seekers.V1;
using Rinzo.Core.Validators;
using Rinzo.Core.Validators.Jobs;
using Rinzo.Core.Validators.Seekers;
using Rinzo.Infrastructure.Data.Contexts;
using Rinzo.Infrastructure.Data.Contexts.V1.Identity;
using Rinzo.Infrastructure.Extensions;
using Rinzo.Infrastructure.Repositories.Common.V1;
using Rinzo.Infrastructure.Repositories.Companies.V1;
using Rinzo.Infrastructure.Repositories.Employers.V1;
using Rinzo.Infrastructure.Repositories.Jobs.V1;
using Rinzo.Infrastructure.Repositories.Seekers.V1;
using Rinzo.WebApi.Middlewares.Exceptions;

var builder = WebApplication.CreateBuilder(args);

DotNetEnv.Env.Load();
builder.Configuration.AddEnvironmentVariables();

#region Register the repository services
// Add the required Configurations
// Register the Repository service
builder.Services.AddControllers();
builder.Services.AddScoped<DbContext, BaseDBContext>();

builder.Services.AddScoped<IEmaiTypeRepository, EmailTypeRepository>();
builder.Services.AddScoped<IValidator<Email>, EmailValidator>();

builder.Services.AddScoped<ISkillRepository, SkillRepository>();
builder.Services.AddScoped<IValidator<Skill>, SkillValidator>();

builder.Services.AddScoped<IPersonNameRepository, PersonNameRepository>();
builder.Services.AddScoped<IValidator<PersonName>, PersonNameValidator>();

builder.Services.AddScoped<IExperienceRepository, ExperienceRepository>();
builder.Services.AddScoped<IValidator<Experience>, ExperienceValidator>();

builder.Services.AddScoped<IQualificationTypeRepository, QualificationTypeRepository>();
builder.Services.AddScoped<IValidator<Qualification>, QualificationValidator>();

builder.Services.AddScoped<IPhoneRepository, PhoneRepository>();
builder.Services.AddScoped<IValidator<Phone>, PhoneValidator>();

builder.Services.AddScoped<IEducationRepository, EducationRepository>();
builder.Services.AddScoped<IValidator<Education>, EducationValidator>();

builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.AddScoped<IValidator<Address>, AddressValidator>();

builder.Services.AddScoped<IJobRepository, JobRepository>();
builder.Services.AddScoped<IValidator<JobEntity>, JobEntityValidator>();

builder.Services.AddScoped<ISeekerRepository, SeekersRepository>();
builder.Services.AddScoped<IValidator<Seeker>, SeekerValidator>();

builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<IValidator<Company>, CompanyValidator>();

builder.Services.AddScoped<IIndustryTypeRepository, IndustryTypeRepository>();

builder.Services.AddScoped<IEmployerRepository, EmployersRepository>();
builder.Services.AddScoped<IValidator<Employer>, EmployerValidator>();

builder.Services.AddScoped<IApplicationRepository, ApplicationRepository>();
builder.Services.AddScoped<IValidator<Application>, ApplicationValidator>();

builder
    .Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();

var key = Environment.GetEnvironmentVariable("JWT_KEY");

if (string.IsNullOrEmpty(key))
{
    throw new ArgumentNullException("Jwt:Key cannot be null or empty");
}

builder
    .Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Issuer"],
            ValidAudience = builder.Configuration["Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
        };
    });

#endregion

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;

    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;

    options.User.AllowedUserNameCharacters =
        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    options.User.RequireUniqueEmail = false;
});

#region Database configuration Services
builder.Services.AddDbContext<BaseDBContext>(options =>
    options.UseNpgsql(
        $"Host={Environment.GetEnvironmentVariable("DB_HOST")};"
            + $"Database={Environment.GetEnvironmentVariable("DB_NAME")};"
            + $"Username={Environment.GetEnvironmentVariable("DB_USER")};"
            + $"Password={Environment.GetEnvironmentVariable("DB_PASSWORD")};"
            + $"Port={Environment.GetEnvironmentVariable("DB_PORT")}"
    )
);
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(
        $"Host={Environment.GetEnvironmentVariable("DB_HOST")};"
            + $"Database={Environment.GetEnvironmentVariable("DB_NAME")};"
            + $"Username={Environment.GetEnvironmentVariable("DB_USER")};"
            + $"Password={Environment.GetEnvironmentVariable("DB_PASSWORD")};"
            + $"Port={Environment.GetEnvironmentVariable("DB_PORT")}"
    )
);

#endregion

builder.Services.AddCors(options =>
{
    options.AddPolicy(
        "AllowAll",
        policy =>
        {
            policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        }
    );
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();
app.UseStatusCodePages(async context =>
{
    context.HttpContext.Response.ContentType = "application/json";
    await context.HttpContext.Response.WriteAsync(
        $"{{\"message\":\"No resource found matching '{context.HttpContext.Request.Path}'.\"}}"
    );
});

#region Middleware Configurations
app.UseHsts();
app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("AllowAll");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

#endregion
app.CreateDataBaseTableIfNotPresent();
app.Run();
