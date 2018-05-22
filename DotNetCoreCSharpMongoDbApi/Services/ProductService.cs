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
				return await _mongoRepo.product.Find(x => true).ToListAsync();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public async Task<Product> GetProductById(int id)
		{
			try
			{
				var filter = Builders<Product>.Filter.Eq("ProdId", id);
				return await _mongoRepo.product.Find(filter).FirstOrDefaultAsync();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public async Task<bool> SaveProduct(Product product)
		{
			try
			{
				await _mongoRepo.product.InsertOneAsync(product);
				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public async Task<bool> UpdateProduct(Product product)
		{
			try
			{
				var filter = Builders<Product>.Filter.Eq("ProdId", product.ProdId);
				var result = _mongoRepo.product.Find(filter).FirstOrDefaultAsync();
				if (result.Result == null)
				{
					return false;
				}
				else
				{
					var update = Builders<Product>.Update
						.Set(x => x.ProductName, product.ProductName)
						.Set(x => x.ProductDescription, product.ProductDescription)
						.Set(x => x.Amount, product.Amount)
						.Set(x => x.ActiveStatus, product.ActiveStatus);
					await _mongoRepo.product.UpdateOneAsync(filter, update);
					return true;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public async Task<bool> DeleteProduct(int id)
		{
			try
			{
				var filter = Builders<Product>.Filter.Eq("ProdId", id);
				var result = _mongoRepo.product.Find(filter).FirstOrDefaultAsync();
				if (result.Result == null)
				{
					return false;
				}
				else
				{
					await _mongoRepo.product.DeleteOneAsync(filter);
					return true;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}



	}
}
