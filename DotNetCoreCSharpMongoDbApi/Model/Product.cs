using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharpMongoDbApi.Model
{
    public class Product
    {
		public int Id { get; set; }

		public string ProductName { get; set; }

		public string ProductDescription { get; set; }

		public int Amount { get; set; }

		public bool ActiveStatus { get; set; }
	}
}
