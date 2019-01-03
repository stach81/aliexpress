using System.Collections.Generic;

namespace AliExpressPoC
{

        public class ProductIdResponseModel
        {
            public string id { get; set; }
            public string categoryId { get; set; }
            public string sellerId { get; set; }
            public string detailUrl { get; set; }
            public string title { get; set; }
            public List<string> productImages { get; set; }
            public List<Promotion> promotions { get; set; }
            public List<Attribute> attributes { get; set; }
            public List<ProductPrice> ProductPrice { get; set; }
            public int statusId { get; set; }
            public int countPerLot { get; set; }
            public int wishListCount { get; set; }
            public string unit { get; set; }
            public string multiUnit { get; set; }
            public Reviews reviews { get; set; }
            public Trade trade { get; set; }
            public List<SkuProperty> skuProperties { get; set; }
        }

        public class MaxAmount
        {
            public string currency { get; set; }
            public string value { get; set; }
        }

        public class MinAmount
        {
            public string currency { get; set; }
            public string value { get; set; }
        }

        public class TimeLeft
        {
            public int days { get; set; }
            public int hours { get; set; }
            public int minutes { get; set; }
            public int seconds { get; set; }
        }

        public class Promotion
        {
            public MaxAmount maxAmount { get; set; }
            public MinAmount minAmount { get; set; }
            public string discount { get; set; }
            public TimeLeft timeLeft { get; set; }
            public int stock { get; set; }
        }

        public class Attribute
        {
            public string name { get; set; }
            public int id { get; set; }
            public string value { get; set; }
            public string valueId { get; set; }
        }

        public class MaxAmount2
        {
            public string currency { get; set; }
            public string value { get; set; }
        }

        public class MaxAmountPerPiece
        {
            public string currency { get; set; }
            public string value { get; set; }
        }

        public class MinAmount2
        {
            public string currency { get; set; }
            public string value { get; set; }
        }

        public class MinAmountPerPiece
        {
            public string currency { get; set; }
            public string value { get; set; }
        }

        public class ProductPrice
        {
            public MaxAmount2 maxAmount { get; set; }
            public MaxAmountPerPiece maxAmountPerPiece { get; set; }
            public MinAmount2 minAmount { get; set; }
            public MinAmountPerPiece minAmountPerPiece { get; set; }
            public int minimumPurchase { get; set; }
            public string processingTime { get; set; }
        }

        public class Reviews
        {
            public int fiveStarCount { get; set; }
            public int fourStarCount { get; set; }
            public int threeStarCount { get; set; }
            public int twoStarCount { get; set; }
            public int oneStarCount { get; set; }
            public int totalCount { get; set; }
            public int positiveCount { get; set; }
            public int negativeCount { get; set; }
            public int neutralCount { get; set; }
            public string ratings { get; set; }
        }

        public class Trade
        {
            public int sold { get; set; }
        }

        public class Value
        {
            public string propertyValueName { get; set; }
            public int propertyValueId { get; set; }
            public string propertyValueDisplayName { get; set; }
        }

        public class SkuProperty
        {
            public int propertyId { get; set; }
            public string propertyName { get; set; }
            public List<Value> values { get; set; }
        }

}
