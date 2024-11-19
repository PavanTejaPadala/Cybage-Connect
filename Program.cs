var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var origindetails = "allowallorigins";
builder.Services.AddCors(opt =>
{
    opt.AddPolicy(name: origindetails, policy =>
    {
        policy.WithOrigins("*");
        policy.WithHeaders("*");
        policy.WithMethods("*");
    });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors(origindetails);

app.MapControllers();

app.Run();
