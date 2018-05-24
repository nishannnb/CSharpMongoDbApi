using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreCSharpMongoDbApi.Models
{
	public class Product
	{
		public ObjectId Id { get; set; }

		public int ProdId { get; set; }

		public string ProductName { get; set; }

		public string ProductDescription { get; set; }

		public int Amount { get; set; }

		public bool ActiveStatus { get; set; }
	}
}
