var builder = WebApplication.CreateBuilder(args);

// Habilita el uso de Clases "Controller" para tu API
builder.Services.AddControllers(); 

// Añade los servicios de Swagger (Swashbuckle) para la documentación de API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuración de MediatR: Escanea el proyecto Application
// en busca de todos los Handlers.
builder.Services.AddMediatR(cfg => 
    cfg.RegisterServicesFromAssemblies(
        typeof(WISOMAPP.Application.ApplicationAssemblyReference).Assembly
    )
);

/* NOTA: Aquí también es donde agregarías tu DbContext
   (lo haremos en el siguiente paso cuando conectemos la BD)
   Ej: builder.Services.AddDbContext<TuDbContext>(...);
*/


// --- 3. Construcción de la Aplicación ---
var app = builder.Build();


// --- 4. Configuración del "Pipeline" de HTTP ---

// Configura Swagger para que solo esté activo en el entorno de Desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); // Esto te da la interfaz gráfica de Swagger en /swagger
}

// Redirección automática de HTTP a HTTPS
app.UseHttpsRedirection();

// Le dice a la API que use las rutas definidas en tus Clases "Controller"
app.MapControllers(); 

// --- 5. Ejecución de la Aplicación ---
app.Run();