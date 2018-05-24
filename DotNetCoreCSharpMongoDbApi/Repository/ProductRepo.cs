using DotNetCoreCSharpMongoDbApi.Model;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreCSharpMongoDbApi.Repository
{
	public class ProductRepo
	{
		private MongoDBContext _mongoDBContext = new MongoDBContext();


		public async Task<List<Product>> GetAllProducts()
		{
			try
			{
				return await _mongoDBContext.product.Find(x => true).ToListAsync();
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
				return await _mongoDBContext.product.Find(filter).FirstOrDefaultAsync();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public async Task<bool> InsertOneProduct(Product product)
		{
			try
			{
				await _mongoDBContext.product.InsertOneAsync(product);
				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public async Task<bool> UpdateOneProduct(Product product)
		{
			try
			{
				var filter = Builders<Product>.Filter.Eq("ProdId", product.ProdId);
				var result = _mongoDBContext.product.Find(filter).FirstOrDefaultAsync();
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
					await _mongoDBContext.product.UpdateOneAsync(filter, update);
					return true;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public async Task<bool> DeleteOneProduct(int id)
		{
			try
			{
				var filter = Builders<Product>.Filter.Eq("ProdId", id);
				var result = _mongoDBContext.product.Find(filter).FirstOrDefaultAsync();
				if (result.Result == null)
				{
					return false;
				}
				else
				{
					await _mongoDBContext.product.DeleteOneAsync(filter);
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
