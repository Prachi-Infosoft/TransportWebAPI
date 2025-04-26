using MongoDB.Bson;
using MongoDB.Driver;
using System.Xml.Linq;

namespace TransportWebAPI
{
    public class MongoHelper
    {
        
        const string connectionUri = "mongodb+srv://test1:test1@cluster0.9gk0m.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0";


        public static async Task<TDDUser> GetUserAsync(string username,string pw,string dbname)
        {
            var settings = MongoClientSettings.FromConnectionString(connectionUri);
            
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            
            var client = new MongoClient(settings);
            TDDUser Vuser = new TDDUser(username, pw);
            try
            {
                var result = client.GetDatabase("admin").RunCommand<BsonDocument>(new BsonDocument("ping", 1));
                Console.WriteLine("Pinged your deployment. You successfully connected to MongoDB!");
                var database = client.GetDatabase(dbname);

                var _userscoll = database.GetCollection<BsonDocument>("users");
                var filter = Builders<BsonDocument>.Filter.Eq("name", username) &
                             Builders<BsonDocument>.Filter.Eq("password", pw); // Using "password" as stored in MongoDB

                var user = await _userscoll.Find(filter).FirstOrDefaultAsync();


                if (user != null)
                {
                    Vuser.isvaliduser = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);


            }
            return Vuser;

        }
        public static async Task<int> UpdateMultiLRAsync(MultiLR pmultilr)
        {
            var settings = MongoClientSettings.FromConnectionString(connectionUri);
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            var client = new MongoClient(settings);
            try
            {
                var result = client.GetDatabase("admin").RunCommand<BsonDocument>(new BsonDocument("ping", 1));
                Console.WriteLine("Pinged your deployment. You successfully connected to MongoDB!");
                var database = client.GetDatabase("transporttrial");
                var _userscoll = database.GetCollection<MultiLR>("multilr");

                var filter = Builders<MultiLR>.Filter.Eq("_id", pmultilr.id);

                // Use ReplaceOneAsync to upsert the document
                var options = new ReplaceOptions { IsUpsert = true };
                var upsertResult = await _userscoll.ReplaceOneAsync(filter, pmultilr, options);
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return -1;
            }
        }
        public static async Task<List<MultiLR>> GetListOfExistingLRAsync()
        {
            var settings = MongoClientSettings.FromConnectionString(connectionUri);
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            var client = new MongoClient(settings);
            try
            {
                // Ping the database to confirm connection
                var result = client.GetDatabase("admin").RunCommand<BsonDocument>(new BsonDocument("ping", 1));
                Console.WriteLine("Pinged your deployment. Connection successful!");

                // Access the collection
                var database = client.GetDatabase("transporttrial");
                var collection = database.GetCollection<MultiLR>("multilrs");

                // Fetch all documents
                var list = await collection.Find(Builders<MultiLR>.Filter.Empty).ToListAsync();
                return list;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }
        public static async Task<List<Lorry>> GetListOfLoriesAsync()
        {
            var settings = MongoClientSettings.FromConnectionString(connectionUri);
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            var client = new MongoClient(settings);
            try
            {
                // Ping the database to confirm connection
                var result = client.GetDatabase("admin").RunCommand<BsonDocument>(new BsonDocument("ping", 1));
                Console.WriteLine("Pinged your deployment. Connection successful!");

                // Access the collection
                var database = client.GetDatabase("transporttrial");
                var collection = database.GetCollection<Lorry>("lorries");

                // Fetch all documents
                var list = await collection.Find(Builders<Lorry>.Filter.Empty).ToListAsync();
                return list;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }

    }
}
