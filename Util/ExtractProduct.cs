using flatrock.Model;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace flatrock.Util
{
    internal class ExtractProduct
    {
        public static List<Product> Extract(string html)
        {
            var products = new List<Product>();

            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);

            var itemNodes = doc.DocumentNode.SelectNodes("//div[@class='item']");

            if (itemNodes != null)
            {
                foreach (var itemNode in itemNodes)
                {
                    string productName = DecodeHtmlEntity(itemNode.SelectSingleNode(".//h4/a").InnerText.Trim());
                    string price = Regex.Match(itemNode.SelectSingleNode(".//span[@itemprop='price']").InnerText, @"[\d.]+").Value;
                    string rating = itemNode.GetAttributeValue("rating", "0");

                    decimal normalizedRating = NormalizeRating(rating);

                    products.Add(new Product
                    {
                        ProductName = productName,
                        Price = price,
                        Rating = normalizedRating
                    });
                }
            }

            return products;
        }

        static string DecodeHtmlEntity(string htmlEncodedString)
        {
            return System.Net.WebUtility.HtmlDecode(htmlEncodedString);
        }

        static decimal NormalizeRating(string rating)
        {
            if (decimal.TryParse(rating, out decimal parsedRating))
            {
                return parsedRating / 2.0m;
            }
            return 0;
        }
    }
}
