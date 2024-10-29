var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
    options.AddPolicy
    (
        "Seti5CorsPolicy", builder => builder
            .WithOrigins("https://localhost:7058")
            .AllowAnyHeader()
            .AllowAnyMethod()
    )
);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("Seti5CorsPolicy");

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();