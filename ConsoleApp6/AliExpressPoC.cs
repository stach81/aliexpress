using System;
using RestSharp;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using System.IO;

namespace AliExpressPoC
{
    class AliExpressPoC
    {
        //public static SearchResponseModel SearchResponseResult;

        //        public static IRestResponse ProductIdRequest;

        static void Main(string[] args)
        {
         
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            Console.WriteLine("-------------------------------------------------------------------------------");
            String token = File.ReadAllText(@"..\..\token.txt", Encoding.UTF8);
            Console.WriteLine(" Your token in file token.txt : " +token);
            Console.WriteLine("-------------------------------------------------------------------------------");

            int skip = 1;
            String text = "t-shirt";

            SearchResponseModel searchResponseResult = SearchProducts(skip, text, token);

            Console.WriteLine("---------------- Job finished ---------------------------------------------");
            Console.WriteLine("searchResponseResult.items.Count = " + searchResponseResult.items.Count);

            if (searchResponseResult.items != null)
            {
                foreach (var item in searchResponseResult.items)
                {
                    String ProductId = item.id;
                    Console.WriteLine(" Search result Product Id: " + item.id);
                    //GetProductIdDetails(ProductId);
                    //GetProductIdTransactionDetails(ProductId);
                }
                Console.WriteLine("---------------- Job finished ---------------------------------------------");
                Console.WriteLine("press key to finish");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("---------------- Search response Result was empty -------------------------");
                Console.WriteLine("---------------- Job finished ---------------------------------------------");
            }
        }


        public static SearchResponseModel SearchProducts(int skip, string text, string token)
        {
            var client = new RestClient("http://api.aliseeks.com/v1/search");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("X-Api-Client-Id", token);
            request.AddParameter("undefined", $"{{\r\n  \"text\": \"{text}\",\r\n  \"skip\": {skip},\r\n  \"limit\": 50\r\n}}", ParameterType.RequestBody);

            Console.WriteLine("Request " + request.Parameters[1].ToString());

            IRestResponse response = client.Execute(request);

            //response.Content
            return JsonConvert.DeserializeObject<SearchResponseModel>(response.Content);

        }

        public static void GetProductIdTransactionDetails(String productId, string token)
        {
            var ProductTransactionsRequestUrl = new RestClient("http://api.aliseeks.com/v1/products/transactions");
            var ProductTransactionsRequest = new RestRequest(Method.POST);
            ProductTransactionsRequest.AddHeader("Postman-Token", "bc60b02e-1802-4bd2-8ed8-239e9e222ca1");
            ProductTransactionsRequest.AddHeader("cache-control", "no-cache");
            ProductTransactionsRequest.AddHeader("Content-Type", "application/json");
            ProductTransactionsRequest.AddHeader("X-Api-Client-Id", token);
            ProductTransactionsRequest.AddParameter("undefined", $"{{\r\n    \"productId\": \"{productId}\",\r\n    \"page\": 1\r\n}}", ParameterType.RequestBody);

            IRestResponse ProductTransactionsResponse = ProductTransactionsRequestUrl.Execute(ProductTransactionsRequest);

            var ProductTransactionsResult = JsonConvert.DeserializeObject<ProductTransactionsResponseModel>(ProductTransactionsResponse.Content);

            try
            {

                if (ProductTransactionsResult.count !=0)
                {
                    Console.WriteLine("Product Transaction count " + ProductTransactionsResult.count + " Name  " + ProductTransactionsResult.transactions[0].name + " date " + " transaction " + ProductTransactionsResult.transactions[0].date);
                    Console.WriteLine("press key to finish");
                }
                else
                {
                    Console.WriteLine("Product Transaction count == 0  " + ProductTransactionsResult.count );
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine("---------------- Exception caught ---------------------------------------------");

                Console.WriteLine("Product Transaction count " + ProductTransactionsResult.count );
                Console.WriteLine("press key to finish");
                Console.WriteLine("---------------- Exception Details --------------------------------------------");
                Console.WriteLine("{0} Exception caught.", e);
                Console.WriteLine("-------------------------------------------------------------------------------");
                Console.ReadKey();

            }
        }

        public static void GetProductIdDetails(String productId, string token)
        {
            //Get ProductId details - to be external method (get's product id as Input)
            var ProductIdRequestUrl = new RestClient("http://api.aliseeks.com/v1/products/details");
            var ProductIdRequest = new RestRequest(Method.POST);
            ProductIdRequest.AddHeader("Postman-Token", "82b7dc8e-4ade-45b9-87f8-d8f54105c1e0");
            ProductIdRequest.AddHeader("cache-control", "no-cache");
            ProductIdRequest.AddHeader("Content-Type", "application/json");
            ProductIdRequest.AddHeader("X-Api-Client-Id", token);
            ProductIdRequest.AddParameter("undefined", $"{{\n    \"productId\": \"{productId}\",\n    \"currency\": \"USD\",\n    \"locale\": \"en_US\"\n}}", ParameterType.RequestBody);
            
            IRestResponse productIdResponse = ProductIdRequestUrl.Execute(ProductIdRequest);
            var productIdResponseResult = JsonConvert.DeserializeObject<ProductIdResponseModel>(productIdResponse.Content);

            try
            {
                
                if (productIdResponseResult.detailUrl != null)
                {
                    Console.WriteLine("Product Data - Product Id: " + productIdResponseResult.id + " URL " + productIdResponseResult.detailUrl.ToString());
                    Console.WriteLine("press key to finish");
                }
                else
                {
                    Console.WriteLine("Product Transaction url ==   " +productIdResponseResult.detailUrl);
                }

            }catch(Exception e)
            {
                Console.WriteLine("---------------- Exception caught ---------------------------------------------");

                Console.WriteLine("Product Data - Product Id: " + productIdResponseResult.id + " URL " + productIdResponseResult.detailUrl.ToString());
                Console.WriteLine("press key to finish");
                Console.WriteLine("---------------- Exception Details --------------------------------------------");
                Console.WriteLine("{0} Exception caught.", e);
                Console.WriteLine("-------------------------------------------------------------------------------");
                Console.ReadKey();

            }
            
            //Console.ReadKey();
        }
    }
}
