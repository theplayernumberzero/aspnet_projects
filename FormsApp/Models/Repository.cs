using System.IO.Compression;

namespace FormsApp.Models{
    public class Repository{

        static Repository(){
            _categories.Add(new Category{CategoryId = 1, Name="Telefon"});
            _categories.Add(new Category{CategoryId = 2, Name="Bilgisayar"});

            _products.Add(new Product{ProductId=1, Name="Iphone 11", Price=20000, IsActive=true, Image="iphone11.jpg", CategoryId=1});
            _products.Add(new Product{ProductId=2, Name="Iphone 13", Price=30000, IsActive=true, Image="iphone13.jpg", CategoryId=1});
            _products.Add(new Product{ProductId=3, Name="Iphone 15", Price=50000, IsActive=true, Image="iphone15.jpg", CategoryId=1});
            _products.Add(new Product{ProductId=4, Name="Iphone 16", Price=70000, IsActive=true, Image="iphone16.jpg", CategoryId=1});

            _products.Add(new Product{ProductId=5, Name="Macbook Air", Price=45000, IsActive=true, Image="macbook-air.jpg", CategoryId=2});
            _products.Add(new Product{ProductId=6, Name="Macbook Pro", Price=95000, IsActive=true, Image="macbook-pro.jpg", CategoryId=2});
        }
        private static readonly List<Product> _products = new();
        private static readonly List<Category> _categories = new();
        //private dışarı açıldı ama sadece get özelliği var
        public static List<Product> Products{
            get{
                return _products;
            }
        }

        public static void CreateProduct(Product entity)
        {
            _products.Add(entity);
        }

        public static void EditProduct(Product updatededProduct)
        {
            var entity = _products.FirstOrDefault(p => p.ProductId == updatededProduct.ProductId);
            if (entity != null)
            {
                entity.Name = updatededProduct.Name;
                entity.Image = updatededProduct.Image;
                entity.CategoryId = updatededProduct.CategoryId;
                entity.Price = updatededProduct.Price;
                entity.IsActive = updatededProduct.IsActive;
            }
        }

        public static void EditProducts(Product updatededProduct)
        {
            var entity = _products.FirstOrDefault(p => p.ProductId == updatededProduct.ProductId);
            if (entity != null)
            {
                entity.IsActive = updatededProduct.IsActive;
            }
        }

        public static void DeleteProduct(Product deletedProduct)
        {
            var entity = _products.FirstOrDefault(p => p.ProductId == deletedProduct.ProductId);
            if (entity != null)
            {
                _products.Remove(entity);
            }
        }

        public static List<Category> Categories
        {
            get
            {
                return _categories;
            }
        }
    }
}