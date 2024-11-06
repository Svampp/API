using QuestAPI;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args); 

builder.Services.AddDbContext<QuestDB>(opt => opt.UseInMemoryDatabase("Questlist")); 
builder.Services.AddDatabaseDeveloperPageExceptionFilter(); 

var app = builder.Build(); 

app.MapGet("/quest", async (QuestDB db) => 
    await db.Quests.ToListAsync()); 

app.MapGet("/quest/{id}", async (int id, QuestDB db) => 
    await db.Quests.FindAsync(id) 
        is Quest quest 
            ? Results.Ok(quest) 
            : Results.NotFound()); 

app.MapPost("/quest", async (Quest quest, QuestDB db) => 
{ 
    db.Quests.Add(quest); 
    await db.SaveChangesAsync(); 
    
    return Results.Created($"/quest/{quest.Id}", quest); 
}); 

app.Run();