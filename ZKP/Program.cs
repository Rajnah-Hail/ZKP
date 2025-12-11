using ZKP.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IEntertainmentService, EntertainmentService>();
builder.Services.AddScoped<IHospitalService, HospitalService>();

// Configure Kestrel to listen on 0.0.0.0:8080
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(8080); // ÇÓÊãÇÚ Úáì ÌãíÚ ÇáÚäÇæíä Úáì ÇáÈæÑÊ 8080
});

var app = builder.Build();

// Configure the HTTP request pipeline.

    app.UseSwagger();
    app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();