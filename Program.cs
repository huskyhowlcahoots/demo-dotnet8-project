using SchoolApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// This how we register the required services with the container from above (only this line is unique here, everything else is boilerplate)
builder.Services.AddSingleton<IFindPotentialSiblingService, FindPotentialSiblingService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// Just a UI for exploratory finding and testing of api endpoints, can be deleted and tested via Bruno, Postman, http files, etc.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline - Boilerplate
// NB: I am on .NET 8, Swagger was replaced with some OpenAPI stuff in 10.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
