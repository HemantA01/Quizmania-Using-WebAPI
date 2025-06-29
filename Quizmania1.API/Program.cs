using Asp.Versioning;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Quizmania1.API;
using Quizmania1.Data.DBContext;
using Quizmania1.Data.DBModel;
using Quizmania1.Service.Interface;
using Quizmania1.Service.Service;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    //options.Cookie.Name = "ephr";  
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = false;
    options.Cookie.IsEssential = false;
});
//********************* API Versioning Start ********************************//
/* Packages Installed:
Asp.Versioning.Mvc (v 6.0)      // As this application is in .Net 6
Asp.Versioning.Mvc.ApiExplorer (v 6.0)
*/
builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;
    options.ApiVersionReader = ApiVersionReader.Combine(
        new QueryStringApiVersionReader("api-version"),
        new HeaderApiVersionReader("x-api-version"),
        new MediaTypeApiVersionReader("api-version")
    );
})
.AddMvc()
.AddApiExplorer(options =>
{
    options.GroupNameFormat = "'v'V";
    options.SubstituteApiVersionInUrl = true;
});
//********************* API Versioning End ********************************//
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DbConn")));
builder.Services.AddScoped<ICountryMaster, CountryMaster>();
builder.Services.AddScoped<IEmploymentTypeMaster, EmploymentTypeMaster>();
builder.Services.AddScoped<IUserLogin, UserLogin>();
builder.Services.AddScoped<ISubjectMaster, SubjectMaster>();
builder.Services.AddScoped<IStateMaster, StateMaster>();
builder.Services.AddScoped<IUserRegistration, UserRegistration>();
builder.Services.AddScoped<IEmployeeDetails, EmployeeDetails>();
builder.Services.AddScoped<IQuizQuestionMaster, QuizQuestionMaster>();

builder.Services.AddScoped<DapperContext>();
builder.Services.AddScoped<IDapperCountryMaster, DapperCountryMaster>();
builder.Services.AddScoped<IDapperStateMaster, DapperStateMaster>();

builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptionsforApiVersioning>();

builder.Services.AddEndpointsApiExplorer();
// Display Authorize Button
builder.Services.AddSwaggerGen(opt => 
{
    //opt.SwaggerDoc("v1", new OpenApiInfo { Title = "MyAPI", Version = "v1" });    //Commented as it has been added in API Versioning 
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });
    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});
//service CORS
builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

//JWT Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience= true,
        ValidateLifetime= true,
        ValidateIssuerSigningKey= true,
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidAudience = builder.Configuration["JWT:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
    };
});

var app = builder.Build();
app.UseSession();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    //app.UseSwaggerUI();
    app.UseSwaggerUI(
        options =>
        {
            var descriptions = app.DescribeApiVersions();
            foreach (var desc in descriptions)
            {
                options.SwaggerEndpoint($"/swagger/{desc.GroupName}/swagger.json", desc.GroupName.ToUpperInvariant());
            }
        });
}
//app CORS
app.UseCors("corsapp");

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
