using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookingHistoryModuleWebAPI.Models
{
    public class BookingHistory
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        public string Id {get; set; }

        [BsonRequired]
        public string PickupLocation { get; set; }

        [BsonRequired]
        public string DropLocation { get; set; }

        

    }
}
