using Enum_Conversion.Converter;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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


app.MapGet("/{enumName}", ([FromRoute] string enumName) =>
{
    try
    {
        var result = EnumConvertor.GetEnumValueNamePairs(enumName);
        return Results.Ok(result);
    }
    catch (ArgumentException ex)
    {
        return Results.BadRequest(new { message = ex.Message });
    }
})
.WithName("GetAllEnumerates")
.Produces<Dictionary<string, int>>(StatusCodes.Status200OK)
.Produces(StatusCodes.Status400BadRequest);

app.Run();

