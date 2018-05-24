using DotNetCoreCSharpMongoDbApi.IServices;
using DotNetCoreCSharpMongoDbApi.Model;
using DotNetCoreCSharpMongoDbApi.Repository;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreCSharpMongoDbApi.Services
{
	public class ProductService : IProductService
	{
		////startup without context
		//private readonly MongoRepo _mongoRepo = null;


		//public ProductService(IOptions<Setting> setting)
		//{
		//	_mongoRepo = new MongoRepo(setting);
		//}

		private readonly ProductRepo _productRepo = null;


		public ProductService()
		{
			_productRepo = new ProductRepo();
		}

		public async Task<List<Product>> GetAllProducts()
		{
			try
			{
				//return await _productRepo.product.Find(x => true).ToListAsync();
				return await _productRepo.GetAllProducts();

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
				//var filter = Builders<Product>.Filter.Eq("ProdId", id);
				//return await _mongoRepo.product.Find(filter).FirstOrDefaultAsync();
				return await _productRepo.GetProductById(id);
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
				//await _mongoRepo.product.InsertOneAsync(product);
				await _productRepo.InsertOneProduct(product);
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
				//var filter = Builders<Product>.Filter.Eq("ProdId", product.ProdId);
				//var result = _mongoRepo.product.Find(filter).FirstOrDefaultAsync();
				//if (result.Result == null)
				//{
				//	return false;
				//}
				//else
				//{
				//	var update = Builders<Product>.Update
				//		.Set(x => x.ProductName, product.ProductName)
				//		.Set(x => x.ProductDescription, product.ProductDescription)
				//		.Set(x => x.Amount, product.Amount)
				//		.Set(x => x.ActiveStatus, product.ActiveStatus);
				//	//await _mongoRepo.product.UpdateOneAsync(filter, update);
				return await _productRepo.UpdateOneProduct(product);
				//	return true;
				//}
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
				//var filter = Builders<Product>.Filter.Eq("ProdId", id);
				//var result = _mongoRepo.product.Find(filter).FirstOrDefaultAsync();
				//var result = _productRepo.GetProductById(id);
				//if (result.Result == null)
				//{
				//	return false;
				//}
				//else
				//{
				//	//await _mongoRepo.product.DeleteOneAsync(filter);
				return await _productRepo.DeleteOneProduct(id);
				//	return true;
				//}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}



	}
}
