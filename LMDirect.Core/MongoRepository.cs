using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMDirect.Core
{
    public class MongoRepository : IMongoRepository
    {
        private readonly IMongoDatabase _db; //IMongoDatabase

        public MongoRepository(IMongoDatabase db)
        {
            _db = db;            
        }

        public async Task InsertOneAsync<T>(T insertobj)
        {           
            await _db.GetCollection<T>(typeof(T).Name).InsertOneAsync(insertobj);                            
        }
    }
}
