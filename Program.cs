
using ExamOnlineSystem.API;

namespace ExamOnlineSystem
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddOpenApi();
            builder.Services.AddApplicationServices(builder.Configuration, builder);


            var app = builder.Build();
            await DbInitializer.InitializeAsync(app);

            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseSwagger();
                app.UseSwaggerUI(op =>
                {
                    op.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                });
            }
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
