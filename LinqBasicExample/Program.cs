using System.Collections;
using System.Runtime.ExceptionServices;

namespace LinqBasicExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int categoryTop = 1;
            Console.SetCursorPosition(0, 0);
            Console.Write("Id");
            Console.SetCursorPosition(5, 0);
            Console.Write("Name");
            Console.SetCursorPosition(20, 0);
            Console.WriteLine("Status");
            Console.WriteLine("-------------------------------");
            foreach (var category in DbContext.CategoryList())
            {
                categoryTop++;
                Console.SetCursorPosition(0, categoryTop);
                Console.Write(category.Id);
                Console.SetCursorPosition(5, categoryTop);
                Console.Write(category.Name);
                Console.SetCursorPosition(20, categoryTop);
                Console.WriteLine(category.IsStatus ? "Active" : "Passive");
            }
            Console.WriteLine("-------------------------------");


            int productTop = categoryTop + 4;

            Console.SetCursorPosition(0, 8);
            Console.Write("Id");
            Console.SetCursorPosition(5, 8);
            Console.Write("Name");
            Console.SetCursorPosition(30, 8);
            Console.Write("Price");
            Console.SetCursorPosition(40, 8);
            Console.Write("Stock");
            Console.SetCursorPosition(50, 8);
            Console.Write("CategoryId");
            Console.SetCursorPosition(70, 8);
            Console.WriteLine("Status");
            Console.WriteLine("------------------------------------------------------------------------------");
            foreach (var product in DbContext.ProductList())
            {
                productTop++;
                Console.SetCursorPosition(0, productTop);
                Console.Write(product.Id);
                Console.SetCursorPosition(5, productTop);
                Console.Write(product.Name);
                Console.SetCursorPosition(30, productTop);
                Console.Write(product.Price);
                Console.SetCursorPosition(40, productTop);
                Console.Write(product.Stock);
                Console.SetCursorPosition(50, productTop);
                Console.Write(product.CategoryId);
                Console.SetCursorPosition(70, productTop);
                Console.WriteLine(product.IsStatus ? "Active" : "Passive");
            }
            Console.WriteLine("------------------------------------------------------------------------------");

            var newProductList = from product in DbContext.ProductList()
                                 join category in DbContext.CategoryList()
                                 on product.CategoryId equals (category.Id)
                                 select new
                                 {
                                     Id = product.Id,
                                     Name = product.Name,
                                     Price = product.Price,
                                     Stock = product.Stock,
                                     CategoryName = category.Name,
                                     IsStatus = product.IsStatus
                                 };

            int newProductTop = productTop + 4;

            Console.SetCursorPosition(0, newProductTop);
            Console.Write("Id");
            Console.SetCursorPosition(5, newProductTop);
            Console.Write("Name");
            Console.SetCursorPosition(30, newProductTop);
            Console.Write("Price");
            Console.SetCursorPosition(40, newProductTop);
            Console.Write("Stock");
            Console.SetCursorPosition(50, newProductTop);
            Console.Write("CategoryName");
            Console.SetCursorPosition(70, newProductTop);
            Console.WriteLine("Status");
            Console.WriteLine("------------------------------------------------------------------------------");
            newProductTop++;
            foreach (var product in newProductList)
            {
                newProductTop++;
                Console.SetCursorPosition(0, newProductTop);
                Console.Write(product.Id);
                Console.SetCursorPosition(5, newProductTop);
                Console.Write(product.Name);
                Console.SetCursorPosition(30, newProductTop);
                Console.Write(product.Price);
                Console.SetCursorPosition(40, newProductTop);
                Console.Write(product.Stock);
                Console.SetCursorPosition(50, newProductTop);
                Console.Write(product.CategoryName);
                Console.SetCursorPosition(70, newProductTop);
                Console.WriteLine(product.IsStatus ? "Active" : "Passive");
            }
            Console.WriteLine("------------------------------------------------------------------------------");

            newProductTop += 4;
            var filteredProductList = DbContext.ProductList().Where(x => x.Name.ToLower().StartsWith("m")).ToList();

            Console.SetCursorPosition(0, newProductTop);
            Console.Write("Id");
            Console.SetCursorPosition(5, newProductTop);
            Console.Write("Name");
            Console.SetCursorPosition(30, newProductTop);
            Console.Write("Price");
            Console.SetCursorPosition(40, newProductTop);
            Console.Write("Stock");
            Console.SetCursorPosition(50, newProductTop);
            Console.Write("CategoryId");
            Console.SetCursorPosition(70, newProductTop);
            Console.WriteLine("Status");
            Console.WriteLine("------------------------------------------------------------------------------");

            newProductTop++;
            foreach (var product in filteredProductList)
            {
                newProductTop++;
                Console.SetCursorPosition(0, newProductTop);
                Console.Write(product.Id);
                Console.SetCursorPosition(5, newProductTop);
                Console.Write(product.Name);
                Console.SetCursorPosition(30, newProductTop);
                Console.Write(product.Price);
                Console.SetCursorPosition(40, newProductTop);
                Console.Write(product.Stock);
                Console.SetCursorPosition(50, newProductTop);
                Console.Write(product.CategoryId);
                Console.SetCursorPosition(70, newProductTop);
                Console.WriteLine(product.IsStatus ? "Active" : "Passive");
            }
            Console.WriteLine("------------------------------------------------------------------------------");

            newProductTop += 4;
            var statusProductList = DbContext.ProductList().Any(x => x.Name == "Yasin");
            //Any metodu bir liste içerisinde değerin varlığını kontrol eder ve true ya da false değeri döner
            Console.SetCursorPosition(0, newProductTop);
            Console.WriteLine(statusProductList ? "Aranan ürün bulundu" : "Aranan ürün bulunamadı.");

            Console.WriteLine("------------------------------------------------------------------------------");

            //kesişim kümesinin dışındakileri birleştir
            newProductTop += 4;
            var numbers = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var kesisimNumbers = new[] { 6, 8, 10, 12 };

            var result = numbers.Except(kesisimNumbers);
            Console.WriteLine(string.Join(",", result));
            Console.WriteLine("------------------------------------------------------------------------------");

            // listeleri birbirleriyle kaynaştırma işlemleri

            newProductTop += 4;
            var numbers1 = new[] { 10, 20, 30, 40, 50 };
            var numbers2 = new[] { 1, 2, 3, 4, 5, };

            var topla = numbers1.Zip(numbers2, (first, second) => first + second );
            Console.WriteLine(string.Join(",",topla));
            Console.WriteLine("------------------------------------------------------------------------------");


            //SQL de ki group by özelliği
            newProductTop += 4;
            var groupByProducts = DbContext.ProductList().ToLookup(x => x.CategoryId); //ToLookup yalnızca category nameleri dönüyor
            Console.WriteLine("Product Name  --------  Category Name");
            foreach (var product in groupByProducts)
            {
                Console.WriteLine("{0} - {1}", string.Join("\n",product.Select(x => x.Name).ToArray()), product.Key);

                Console.WriteLine(product.Key.ToString());
                Console.WriteLine("----------------------------");
                foreach (var item in product)
                {
                    Console.WriteLine("Name: " + item.Name + "\t\t Price: " + item.Price);
                }
                Console.WriteLine("------------------------------------------------------------------------------");
            }

            //kümelerin kesişim kümesini almak için:
            var numbers3 = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var numbers4 = new[] { 5, 6, 7, 8, 9, 10, 11, 12 ,13 ,14, 15};

            var numbers3tonumber4 = numbers3.Intersect(numbers4);
            Console.WriteLine("------------------------------------------------------------------------------");

            var numbers5 = new[] { 1, 2, 3, 4, 5};
            var numbers6 = new[] { 3, 4, 5, 6, 7};

            var numbers5tonumber6 = numbers5.Intersect(numbers6);
            Console.WriteLine(string.Join(",", numbers5tonumber6));
            Console.WriteLine("------------------------------------------------------------------------------");

            var sumnumbers5 = numbers5.Sum();
            Console.WriteLine("Toplam: " + sumnumbers5);
            Console.WriteLine("------------------------------------------------------------------------------");

            var numbers5tonumbers6distinct = numbers5tonumber6.Distinct();
            Console.WriteLine(string.Join(",", numbers5tonumbers6distinct));
            Console.WriteLine("------------------------------------------------------------------------------");


            var numbers5to6MinMax = numbers5tonumbers6distinct.Max()-numbers5tonumbers6distinct.Min();
            Console.WriteLine(numbers5to6MinMax);

            var minPriceProduct = DbContext.ProductList().Where(x => x.Price == DbContext.ProductList().Min(y => y.Price));
            Console.WriteLine("Min Price: "+ minPriceProduct);

            foreach (var item in minPriceProduct)
            {
                Console.WriteLine("Toplam: {0} adet ürün bulundu", minPriceProduct.Count());
            }


            Console.WriteLine("------------------------------------------------------------------------------");

            var selectNumberCountProduct = DbContext.ProductList().Take(5).ToList();
            foreach (var item in minPriceProduct)
            {
                Console.WriteLine("Name: " + item.Name + "Price: " + item.Price);
            }

            Console.WriteLine("------------------------------------------------------------------------------");


            var rangeProduct = DbContext.ProductList().Where(x => x.Price>5000 && x.Price<40000).ToList();
            foreach (var item in rangeProduct)
            {
                Console.WriteLine("Name: " + item.Name + "Price: " + item.Price);
            }

            var repeat =Enumerable.Repeat("İndirim...", rangeProduct.Count());
            Console.WriteLine(string.Join(",", repeat));
            

            Console.WriteLine("------------------------------------------------------------------------------");


            //LİSTELEME
            var orderByRangeProduct = rangeProduct.OrderBy(x => x.Name);
            foreach (var item in orderByRangeProduct)
            {
                Console.WriteLine("Name: " + item.Name + "Price: " + item.Price);
            }

            Console.WriteLine("------------------------------------------------------------------------------");

            //TAM TERSİ LİSTELEME İÇİN
            var orderByDescRangeProduct = rangeProduct.OrderByDescending(x => x.Name);
            foreach (var item in orderByDescRangeProduct)
            {
                Console.WriteLine("Name: " + item.Name + "Price: " + item.Price);
            }

            Console.WriteLine("------------------------------------------------------------------------------");

            //İÇİNDE DEĞER ARAMAK İÇİN
            //var stringCheck = "Monster";
            //var containProduct = rangeProduct.Where(x => stringCheck.Any(a =>x.Name.Contains(stringCheck.ToLower()))).ToList();

            //foreach (var item in containProduct)
            //{
            //    Console.WriteLine("Name: " + containProduct.Name + "Price: " + containProduct.Price);
            //}



            var firstProduct = rangeProduct.First();
            Console.WriteLine("Name: " + firstProduct.Name + "Price: " + firstProduct.Price);
            Console.WriteLine("------------------------------------------------------------------------------");

            var LastProduct = rangeProduct.Last();
            Console.WriteLine("Name: " + LastProduct.Name + "Price: " + LastProduct.Price);
            Console.WriteLine("------------------------------------------------------------------------------");

            var takeProducts = rangeProduct.Take(2);
            foreach (var item in takeProducts)
            {
                Console.WriteLine("Name: " + item.Name + "Price: " + item.Price);
            }
            Console.WriteLine("------------------------------------------------------------------------------");


            //Listeyi tersine çevirme
            rangeProduct.Reverse(); 

            foreach (var item in rangeProduct)
            {
                Console.WriteLine("Name: " + item.Name + "Price: " + item.Price);
            }


            string ad = "Yasir";
            var yeniAd = ad.Reverse();
            Console.WriteLine(string.Join("",yeniAd));
            Console.WriteLine("------------------------------------------------------------------------------");

            var mixedValues = new object[]
            {
                1, "Azra", false, 2, "Yüksel", true, 'a', 30.1, 12f
            };

            var stringValues = mixedValues.OfType<string>().ToArray();
            var exceptValues = mixedValues.Except(stringValues).ToArray();
            Console.WriteLine(string.Join(",", exceptValues));









            //

        }
    }
}