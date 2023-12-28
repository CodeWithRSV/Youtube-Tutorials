using System;

namespace DemoApp
{
    class Program
    {
        public static void Main()
        {
            Product product = new Product
            {
                Id = 1,
                Name = "Test",
                InStock = true,
                InventoryDate = DateTime.Now,
                Price = 240.5M
            };

            #region Using System.Text.Json

            //string json = JsonSerializer.Serialize(product, new JsonSerializerOptions { WriteIndented = true });
            //Console.WriteLine(json);
            //Product clone = JsonSerializer.Deserialize<Product>(json);

            #endregion

            #region using Newtonsoft.Json

            //string json = JsonConvert.SerializeObject(product, Formatting.Indented);
            //Console.WriteLine(json);
            //Product clone = JsonConvert.DeserializeObject<Product>(json);

            #endregion
        }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool InStock { get; set; }
        //[JsonPropertyName("invDate")]
        //[JsonProperty("invDate")]
        public DateTime InventoryDate { get; set; }
    }
}