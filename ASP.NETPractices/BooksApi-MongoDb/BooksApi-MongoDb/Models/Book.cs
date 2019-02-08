using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace BooksApiMongoDb.Models
{
    public class Book
    {
        [BsonId]//Is annotated with [BsonId] to designate this property as the document's primary key.
        [BsonRepresentation(BsonType.ObjectId)]
        //Is annotated with [BsonRepresentation(BsonType.ObjectId)] to allow passing the parameter
        //as type string instead of ObjectId. Mongo handles the conversion from string to ObjectId.
        public string Id { get; set; }

        [BsonElement("Name")]
        public string BookName { get; set; }

        [BsonElement("Price")]
        public decimal Price { get; set; }

        [BsonElement("Category")]
        public string Category { get; set; }

        [BsonElement("Author")]
        public string Author { get; set; }
    }
}
