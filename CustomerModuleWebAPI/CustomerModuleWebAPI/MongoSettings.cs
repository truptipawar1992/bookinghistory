using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingHistoryModuleWebAPI
{
    //public class MongoSettings
    //{
        //public string BookingHistoryCollectionName { get; set; }
        //public string ConnectionString { get; set; }
        //public string Database { get; set; }


        public class MongoSettings : IMongoSettings
        {
            public string BookingHistoryCollectionName { get; set; }
            public string ConnectionString { get; set; }
            public string Database { get; set; }
        }

        public interface IMongoSettings
        {
            string BookingHistoryCollectionName { get; set; }
            string ConnectionString { get; set; }
            string Database { get; set; }
        }
    //}
}
