using DotNetCoreCSharpMongoDbApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreCSharpMongoDbApi
{
	public class MongoDBContext : DbContext
	{
		public static string ConnectionString { get; set; }

		public static string DatabaseName { get; set; }

		public static bool IsSSL { get; set; }


		private IMongoDatabase _database { get; }


		public MongoDBContext()
		{
			try
			{
				MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(ConnectionString));
				if (IsSSL)
				{
					settings.SslSettings = new SslSettings { EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12 };
				}
				MongoClient mongoClient = new MongoClient(settings);
				_database = mongoClient.GetDatabase(DatabaseName);

			}
			catch (Exception ex)
			{
				throw new Exception("Can not access to MongoDb server.", ex);
			}
		}

		public IMongoCollection<Product> product => _database.GetCollection<Product>("Product");
	}
}
