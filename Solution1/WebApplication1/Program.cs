var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// 정책 이름을 _myAllowSpecificOrigins로 설정합니다. 정책 이름은 임의로 지정할 수 있습니다.
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.AllowAnyOrigin();
                          policy.AllowAnyHeader();
                          policy.AllowAnyMethod();
                          // policy.WithOrigins("https://localhost:7099", "http://localhost:5106");
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

// CORS 미들웨서 추가
app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
