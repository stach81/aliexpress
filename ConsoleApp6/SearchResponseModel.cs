using System.Collections.Generic;

namespace AliExpressPoC
{
    public class SearchResponseModel
    {
        public Aggregation aggregation { get; set; }
        public List<Item> items { get; set; }
    }

    public class Aggregation
    {
        public int totalCount { get; set; }
        public List<string> shipFromCountries { get; set; }
    }

    public class Price
    {
        public string currency { get; set; }
        public string value { get; set; }
    }

    public class Freight
    {
        public Price price { get; set; }
    }

    public class Amount
    {
        public string currency { get; set; }
        public string value { get; set; }
    }

    public class PriceOption
    {
        public string type { get; set; }
        public Amount amount { get; set; }
    }

    public class Item
    {
        public string id { get; set; }
        public string imageUrl { get; set; }
        public string title { get; set; }
        public double ratings { get; set; }
        public int orders { get; set; }
        public Freight freight { get; set; }
        public List<PriceOption> priceOptions { get; set; }
    }


}