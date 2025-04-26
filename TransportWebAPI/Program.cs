namespace TransportWebAPI
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.OpenApi.Models;
    using MongoDB.Bson;
    using MongoDB.Driver;

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container
            builder.Services.AddControllers();
            //builder.Services.AddAuthorization();

            // Register Swagger
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Transport API", Version = "v1" });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline
            if (app.Environment.IsDevelopment()) // Ensuring Swagger is enabled only in development mode
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Transport API V1");
                    c.RoutePrefix = string.Empty; // Set Swagger UI at the app's root
                });
            }

            app.UseHttpsRedirection();
            //app.UseAuthorization();
            //app.UseAuthentication(); // Ensure authentication middleware is included if needed

            app.MapControllers(); // Maps controller endpoints
            //AddDummyMultilr();
            //SaveLorryObjectsAsync();
            app.Run();
        }

        public static async void AddDummyMultilr()
        {
            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://test1:test1@cluster0.9gk0m.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0");
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            var client = new MongoClient(settings);
            var database = client.GetDatabase("transporttrial");
            var collection = database.GetCollection<MultiLR>("multilrs");

            var dummyMultiLRList = new List<MultiLR>
                {
                    new MultiLR
                    {
                        masterid =1,
                        //_id = new MongoDB.Bson.ObjectId(),
                        name = "Name1",
                        date = DateTime.Now.AddDays(1),
                        multilrdetails = new List<MultiLRDetails>
                        {
                            new MultiLRDetails { loryno = "LR-101", destinition = "CityA", source = "DepotX", description = "Cargo A", opkm = 1200 },
                            new MultiLRDetails { loryno = "LR-102", destinition = "CityB", source = "DepotY", description = "Cargo B", opkm = 1500 }
                        }
                    },
                    new MultiLR
                    {
                        masterid = 2,
                        //_id = new MongoDB.Bson.ObjectId(),
                        name = "Name2",
                        date = DateTime.Now.AddDays(2),
                        multilrdetails = new List<MultiLRDetails>
                        {
                            new MultiLRDetails { loryno = "LR-201", destinition = "CityC", source = "DepotZ", description = "Cargo C", opkm = 1800 },
                            new MultiLRDetails { loryno = "LR-202", destinition = "CityA", source = "DepotX", description = "Cargo D", opkm = 2000 }
                        }
                    },
                    new MultiLR
                    {
                        masterid = 3,
                        //_id = new MongoDB.Bson.ObjectId(),
                        name = "Name3",
                        date = DateTime.Now.AddDays(3),
                        multilrdetails = new List<MultiLRDetails>
                        {
                            new MultiLRDetails { loryno = "LR-301", destinition = "CityB", source = "DepotY", description = "Cargo E", opkm = 2200 },
                            new MultiLRDetails { loryno = "LR-302", destinition = "CityC", source = "DepotZ", description = "Cargo F", opkm = 2500 }
                        }
                    },
                    new MultiLR
                    {
                        masterid = 4,
                        //_id = new MongoDB.Bson.ObjectId(),
                        name = "Name4",
                        date = DateTime.Now.AddDays(4),
                        multilrdetails = new List<MultiLRDetails>
                        {
                            new MultiLRDetails { loryno = "LR-401", destinition = "CityA", source = "DepotX", description = "Cargo G", opkm = 3000 },
                            new MultiLRDetails { loryno = "LR-402", destinition = "CityB", source = "DepotY", description = "Cargo H", opkm = 3200 }
                        }
                    },
                    new MultiLR
                    {
                        masterid = 5,
                        //_id = new MongoDB.Bson.ObjectId(),
                        name = "Name5",
                        date = DateTime.Now.AddDays(5),
                        multilrdetails = new List<MultiLRDetails>
                        {
                            new MultiLRDetails { loryno = "LR-501", destinition = "CityC", source = "DepotZ", description = "Cargo I", opkm = 3500 },
                            new MultiLRDetails { loryno = "LR-502", destinition = "CityA", source = "DepotX", description = "Cargo J", opkm = 4000 }
                        }
                    },
                    new MultiLR
                    {
                        masterid = 6,
                        //_id = new MongoDB.Bson.ObjectId(),
                        name = "Name6",
                        date = DateTime.Now.AddDays(6),
                        multilrdetails = new List<MultiLRDetails>
                        {
                            new MultiLRDetails { loryno = "LR-601", destinition = "CityB", source = "DepotY", description = "Cargo K", opkm = 4500 },
                            new MultiLRDetails { loryno = "LR-602", destinition = "CityC", source = "DepotZ", description = "Cargo L", opkm = 5000 }
                        }
                    },
                    new MultiLR
                    {
                        masterid = 7,
                        //_id = new MongoDB.Bson.ObjectId(),
                        name = "Name7",
                        date = DateTime.Now.AddDays(7),
                        multilrdetails = new List<MultiLRDetails>
                        {
                            new MultiLRDetails { loryno = "LR-701", destinition = "CityA", source = "DepotX", description = "Cargo M", opkm = 5500 },
                            new MultiLRDetails { loryno = "LR-702", destinition = "CityB", source = "DepotY", description = "Cargo N", opkm = 6000 }
                        }
                    },
                    new MultiLR
                    {
                        masterid = 8,
                        //_id = new MongoDB.Bson.ObjectId(),
                        name = "Name8",
                        date = DateTime.Now.AddDays(8),
                        multilrdetails = new List<MultiLRDetails>
                        {
                            new MultiLRDetails { loryno = "LR-801", destinition = "CityC", source = "DepotZ", description = "Cargo O", opkm = 6500 },
                            new MultiLRDetails { loryno = "LR-802", destinition = "CityA", source = "DepotX", description = "Cargo P", opkm = 7000 },
                            new MultiLRDetails { loryno = "LR-701", destinition = "CityA", source = "DepotX", description = "Cargo M", opkm = 5500 },
                            new MultiLRDetails { loryno = "LR-702", destinition = "CityB", source = "DepotY", description = "Cargo N", opkm = 6000 }
                        }
                    },
                    new MultiLR
                    {
                        masterid = 9,
                        //_id = new MongoDB.Bson.ObjectId(),
                        name = "Name9",
                        date = DateTime.Now.AddDays(9),
                        multilrdetails = new List<MultiLRDetails>
                        {
                            new MultiLRDetails { loryno = "LR-901", destinition = "CityB", source = "DepotY", description = "Cargo Q", opkm = 7500 },
                            new MultiLRDetails { loryno = "LR-902", destinition = "CityC", source = "DepotZ", description = "Cargo R", opkm = 8000 }
                        }
                    },
                    new MultiLR
                    {
                        masterid=10,
                        //_id = new MongoDB.Bson.ObjectId(),
                        name = "Name10",
                        date = DateTime.Now.AddDays(10),
                        multilrdetails = new List<MultiLRDetails>
                        {
                            new MultiLRDetails { loryno = "LR-1001", destinition = "CityA", source = "DepotX", description = "Cargo S", opkm = 8500 },
                            new MultiLRDetails { loryno = "LR-1002", destinition = "CityB", source = "DepotY", description = "Cargo T", opkm = 9000 }
                        }
                    }
                };
            try
            {
                var result = client.GetDatabase("admin").RunCommand<BsonDocument>(new BsonDocument("ping", 1));
                Console.WriteLine("Pinged your deployment. You successfully connected to MongoDB!");
                
               
                
                await collection.InsertManyAsync(dummyMultiLRList);
                Console.WriteLine("Dummy MultiLR data inserted successfully.");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                
            }
            


        }
        public static async void SaveLorryObjectsAsync()
        {
            // Connection string to your MongoDB Atlas
            var connectionUri = "mongodb+srv://test1:test1@cluster0.9gk0m.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0"; // Replace with your connection string
            var settings = MongoClientSettings.FromConnectionString(connectionUri);
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            var client = new MongoClient(settings);

            try
            {
                // Access the database and collection
                var database = client.GetDatabase("transporttrial"); // Replace with your database name
                var collection = database.GetCollection<Lorry>("lorries"); // Replace with your collection name

                // Create 15 objects with `prvkm` set to 100
                var lorries = new List<Lorry>();
                for (int i = 1; i <= 15; i++)
                {
                    lorries.Add(new Lorry
                    {
                        id = ObjectId.GenerateNewId(),
                        name = $"Lorry-{i}",
                        prvkm = 100
                    });
                }

                // Insert the objects into MongoDB
                await collection.InsertManyAsync(lorries);
                Console.WriteLine("15 lorry objects have been saved to MongoDB Atlas.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
