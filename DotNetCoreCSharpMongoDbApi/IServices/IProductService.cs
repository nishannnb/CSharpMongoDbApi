using DotNetCoreCSharpMongoDbApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreCSharpMongoDbApi.IServices
{
	public interface IProductService
	{

		Task<List<Product>> GetAllProducts();
		Task<Product> GetProductById(int id);
		Task<bool> InsertOneProduct(Product product);
		//Task<bool> InsertManyProducts(List<Product> products);
		Task<bool> UpdateOneProduct(Product product);
		//Task<bool> UpdateManyProducts(List<Product> products);
		Task<bool> DeleteOneProduct(int id);
		//Task<bool> DeleteManyProducts();

	}
}
