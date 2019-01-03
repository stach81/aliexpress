using System;
using System.Collections.Generic;

namespace AliExpressPoC
{

        public class ProductTransactionsResponseModel
        {
            public int count { get; set; }
            public List<Transaction> transactions { get; set; }
        }

        public class Transaction
        {
            public string id { get; set; }
            public string name { get; set; }
            public string countryCode { get; set; }
            public int quantity { get; set; }
            public DateTime date { get; set; }
            public string unit { get; set; }
        }

}