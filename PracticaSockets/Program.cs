using PracticaSockets.Hubs;
using PracticaSockets.Models;
using PracticaSockets.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddSingleton(new MongoDbSettings
{
    ConnectionString = "mongodb+srv://JhonAlbert06:Bender345@cluster0.z76lstc.mongodb.net/",
    DatabaseName = "SocketsDB"
});
builder.Services.AddScoped<UserRepository>();
builder.Services.AddSignalR();
builder.Services.AddCors();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


// Configurar enrutamiento y controladores

app.UseRouting();

app.UseCors(options => options.AllowAnyHeader().AllowAnyMethod().AllowCredentials().SetIsOriginAllowed(_ => true));
app.UseAuthorization();


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapHub<UserHub>("/userHub");
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();