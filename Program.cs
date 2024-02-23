using flatrock.ExtractMaterials;
using flatrock.Model;
using flatrock.Util;

namespace flatrock
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string html = ProductHtml.GetHtml();

            List<Product> products = ExtractProduct.Extract(html);

            foreach (var product in products)
            {
                Console.WriteLine($"Product Name: {product.ProductName}");
                Console.WriteLine($"Price: {product.Price}");
                Console.WriteLine($"Rating: {product.Rating}");
                Console.WriteLine();
            }
        }
    }
}