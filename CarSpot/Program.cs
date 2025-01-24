using Microsoft.EntityFrameworkCore;



 
    {
        var builder = WebApplication.CreateBuilder(args);

        
    

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseInMemoryDatabase("InMemoryDb"));
        
        /*builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));*/

        
        var app = builder.Build();

       
        // Configurar middleware de autenticación y autorización
        app.UseAuthentication();
        app.UseAuthorization();


       
       


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
