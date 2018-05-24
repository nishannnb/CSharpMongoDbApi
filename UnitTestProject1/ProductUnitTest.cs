using DotNetCoreCSharpMongoDbApi.Controllers;
using DotNetCoreCSharpMongoDbApi.IServices;
using DotNetCoreCSharpMongoDbApi.Model;
using DotNetCoreCSharpMongoDbApi.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
	[TestClass]
	public class ProductUnitTest
	{
		private ProductService _productService = null;

		public ProductUnitTest()
		{
			_productService = new ProductService();
		}

		[TestMethod]
		public void InsertOneProduct_Test()
		{
			//Arrange
			Product product = new Product() { ProdId = 1, ProductName = "LG", ProductDescription = "LG Mobile", Amount = 5, ActiveStatus = true };

			//Act
			var result = _productService.InsertOneProduct(product).IsCompletedSuccessfully;

			//Assert
			Assert.IsNotNull(result);

		}
	}
}
