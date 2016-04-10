using System;
using System.Configuration;

using MongoDB.Driver;
using MongoDB.Bson;

using Project.Data.Entity;

namespace Project.Data.Repository
{
    public class PersonRepository
    {
        private IMongoCollection<Person> _collection;

        public PersonRepository()
        {
            var cnnStr = ConfigurationManager.AppSettings["CNN_STR"] ?? "mongodb://localhost";
            var dbName = ConfigurationManager.AppSettings["DB_NAME"] ?? "PeopleDB";

            var settings = new MongoDatabaseSettings();
            settings.ReadConcern = new ReadConcern(ReadConcernLevel.Local);
            settings.WriteConcern = new WriteConcern(1, TimeSpan.FromSeconds(30), false, true);

            var client = new MongoClient(cnnStr);
            var database = client.GetDatabase(dbName, settings);

            _collection = database.GetCollection<Person>("People");
        }

        public void Insert(Person entity)
        {
            _collection.InsertOne(entity);
        }

        public UpdateResult Update(Person entity)
        {
            var update = Builders<Person>.Update;
            var definition = update.Set("FirstName", entity.FirstName)
                                   .Set("LastName", entity.LastName)
                                   .Set("Phone", entity.Phone);

            var result = _collection.UpdateOne(x => x.Id == entity.Id, definition);
            return result;
        }

        public Person SelectOne(string uid)
        {
            var filter = Builders<Person>.Filter;

            var id = new ObjectId(uid);
            var query = filter.Eq(x => x.Id, id);

            var entity = _collection.Find(query).FirstOrDefault();
            return entity;
        }

        public PersonPage SelectPage(int skip, int take, string filter = null)
        {
            var filterObject = Builders<Person>.Filter;
            var query = filterObject.Where(x => x.Email != "");

            if (!string.IsNullOrWhiteSpace(filter))
            {
                query = filterObject.Where(x => x.FirstName.Contains(filter)
                                                || x.LastName.Contains(filter)
                                                || x.Email.Contains(filter)
                                                || x.Phone.Contains(filter));                
            }

            var count = _collection.Count(query);
            var items = _collection.Find(query).Skip(skip).Limit(take).ToList();

            var result = new PersonPage();
            result.Count = count;
            result.Items = items;           

            return result;
        }
    }
}
