using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


 
    {
        var builder = WebApplication.CreateBuilder(args);

        
    

        builder.Services.AddControllers();
        var app = builder.Build();

        // Configurar middleware de autenticación y autorización
        app.UseAuthentication();
        app.UseAuthorization();


        // Configura la conexión a la base de datos
        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));



        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }




        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
