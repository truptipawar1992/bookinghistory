using BookingHistoryModuleWebAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingHistoryModuleWebAPI.Services
{
    public class BookingHistoryService
    {
        private MongoSettings mongosettings;
        private readonly IMongoDatabase database;

        public BookingHistoryService(IOptions<MongoSettings> options)
        {
            this.mongosettings = options.Value;

            MongoClientSettings clientsettings = MongoClientSettings.FromConnectionString(mongosettings.ConnectionString);

            MongoClient client = new MongoClient(clientsettings);

            if (client != null)
            {
                this.database = client.GetDatabase(mongosettings.Database.Trim());
            }

        }

        public IMongoCollection<BookingHistory> GetBookingHistorys
        {
            get
            {
                return this.database.GetCollection<BookingHistory>(mongosettings.BookingHistoryCollectionName);
            }
        }

        public BookingHistory Create(BookingHistory BookingHistory)
        {
            //this.database.GetCollection<BookingHistory>(mongosettings.BookingHistoryCollectionName).InsertOne(BookingHistory);
            GetBookingHistorys.InsertOne(BookingHistory);
            return BookingHistory;
        }

        //public void Update(ObjectId id, BookingHistory BookingHistory) =>
        //    GetBookingHistorys.ReplaceOne(BookingHistorynew => BookingHistorynew.Id == id, BookingHistory);
    }
}
