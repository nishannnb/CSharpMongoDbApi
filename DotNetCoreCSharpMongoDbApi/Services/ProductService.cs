using CSharpMongoDbApi.IServices;
using CSharpMongoDbApi.Model;
using CSharpMongoDbApi.Repository;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharpMongoDbApi.Services
{
	public class ProductService : IProductService
	{
		private readonly MongoRepo _mongoRepo = null;

		public ProductService(IOptions<Setting> setting)
		{
			_mongoRepo = new MongoRepo(setting);
		}

		public async Task<List<Product>> GetAllProducts()
		{
			try
			{
				var filter = Builders<Product>.Filter.Eq("ProductName", "Acer");
				return await _mongoRepo.product.Find(filter).ToListAsync();
			}
			catch (Exception ex)
			{

				throw ex;
			}

		}


	}
}
