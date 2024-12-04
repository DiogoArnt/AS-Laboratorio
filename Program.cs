using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configurar serviços
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer(); // Necessário para gerar os endpoints no Swagger
builder.Services.AddSwaggerGen();          // Registra o Swagger

// Configuração do banco de dados e dependências
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IPedidoRepository, PedidoRepository>();
builder.Services.AddScoped<IFornecedorRepository, FornecedorRepository>();

var app = builder.Build();

// Configuração do pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Habilita o middleware do Swagger
    app.UseSwaggerUI(); // Habilita a interface gráfica do Swagger
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();