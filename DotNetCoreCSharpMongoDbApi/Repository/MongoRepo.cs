using DotNetCoreCSharpMongoDbApi.Model;
using DotNetCoreCSharpMongoDbApi;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreCSharpMongoDbApi.Repository
{
	public class MongoRepo
	{
		////startup without context
		//private readonly IMongoDatabase _database;


		//public MongoRepo(IOptions<Setting> setting)
		//{
		//	try
		//	{
		//		var client = new MongoClient(setting.Value.ConnectionString);

		//		if (client != null)
		//		{
		//			_database = client.GetDatabase(setting.Value.Database);
		//		}
		//	}
		//	catch (Exception ex)
		//	{
		//		throw new Exception("Can not access to MongoDb server.", ex);
		//	}
		//}

		//public IMongoCollection<Product> product => _database.GetCollection<Product>("Product");

		

	}
}
