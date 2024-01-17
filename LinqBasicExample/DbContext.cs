using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqBasicExample
{
    internal class DbContext
    {
        static int categoryId=4;
        static List<Category> _categoryList = new List<Category>()
        {
            new Category(){Id=1,Name="Computer",Description="Computer Category",IsStatus=true},
            new Category(){Id=2,Name="Phone",Description="Phone Category",IsStatus=true},
            new Category(){Id=3,Name="Tablet",Description="Tablet Category",IsStatus=false},
            new Category(){Id=4,Name="Accessories",Description="Accessories Category",IsStatus=true}
        };

        static List<Product> _productList=new List<Product>()
        {
            new Product(){Id=1,Name="Asus Game Computer",Description="Asus Game Computer",Price=15000,Stock=5,CategoryId=1,IsStatus=true},
            new Product(){Id=2,Name="Dell Personel Computer",Description="Dell Personel Computer",Price=25000,Stock=3,CategoryId=1,IsStatus=true},
            new Product(){Id=3,Name="Apple Macbook Pro",Description="Apple Macbook Pro",Price=43000,Stock=4,CategoryId=1,IsStatus=true},
            new Product(){Id=4,Name="Samsung Tab 22",Description="Samsung Tab 22",Price=16500,Stock=15,CategoryId=2,IsStatus=true},
            new Product(){Id=5,Name="Iphone 15 Pro Max",Description="Iphone 15 Pro Max",Price=25000,Stock=12,CategoryId=2,IsStatus=true},
            new Product(){Id=6,Name="Galaxy Tab 7",Description="Galaxy Tab 7",Price=5000,Stock=2,CategoryId=3,IsStatus=true},
            new Product(){Id=7,Name="Asus Rog Game Tablet",Description="Asus Rog Game Tablet",Price=12000,Stock=32,CategoryId=3,IsStatus=true},
            new Product(){Id=8,Name="Hp Headphone",Description="Hp Headphone",Price=55000,Stock=26,CategoryId=4,IsStatus=true},
            new Product(){Id=9,Name="Monster Gamer Mouse",Description="Monster Gamer Mouse",Price=35000,Stock=12,CategoryId=4,IsStatus=true},
            new Product(){Id=10,Name="Monster Game Computer",Description="Monster Game Computer",Price=1000,Stock=8,CategoryId=1,IsStatus=true},
            new Product(){Id=11,Name="General Mobile S22",Description="General Mobile S22",Price=5000,Stock=5,CategoryId=2,IsStatus=true},
            new Product(){Id=12,Name="Nintendo Switch",Description="Nintendo Switch",Price=3600,Stock=7,CategoryId=3,IsStatus=true},
            new Product(){Id=13,Name="MSI Gamer Keyboard",Description="MSI Gamer Keyboard",Price=2900,Stock=2,CategoryId=4,IsStatus=true},
        };

        public static List<Category> CategoryList()
        {
            return _categoryList.ToList();
        }
        public static List<Product> ProductList()
        {
            return _productList.Where(x => x.IsStatus == true).ToList();
        }
    }
}
