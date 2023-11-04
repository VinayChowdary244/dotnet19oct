
using ShoppingBLLibrary;
using ShoppingDALLibrary;
using ShoppingModelLibrary;


namespace BLTest
{
    public class Tests
    {
        IProductService  _service;
        [SetUp]
        public void Setup()
        {
            _service = new ProductService();
        }

        [Test]
        public void AddProductsNullTest()
        {
            var result = _service.AddProduct(new Product { Id = 100, Name = "Pencil" });
            Assert.IsNotNull(result);
        }
        
    }
}