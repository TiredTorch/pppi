using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace pppi
{
    public class AssociateModel
    {
        public string Message { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public AssociateResultRoot AssociateResult { get; set; }
        public string Error { get; set; }

        public void PrintResult()
        {
            Console.WriteLine($"Error: {this.Error}");
            Console.WriteLine($"Message {this.Message}");
            Console.WriteLine($"StatusCode: {this.StatusCode}");

            if (this.Error == null)
            {
                Console.WriteLine($"id: {this.AssociateResult.id}");
                Console.WriteLine($"userId: {this.AssociateResult.userId}");
                Console.WriteLine($"body: {this.AssociateResult.body}");
                Console.WriteLine($"title: {this.AssociateResult.title}");
            }
        }
    }

    public class ClientAssociate
    {

        private readonly HttpClient client;

        public ClientAssociate()
        {
            this.client = new HttpClient();
        }

        public async Task<AssociateModel> Get()
        {
            int postId = 1;
            string url = $"https://jsonplaceholder.typicode.com/posts/{postId}";

            try
            {
                HttpResponseMessage response = await client.GetAsync($"{url}");
                string json = await response.Content.ReadAsStringAsync();
                Console.WriteLine(json);
                AssociateResultRoot data = JsonSerializer.Deserialize<AssociateResultRoot>(json);

                return new AssociateModel
                {
                    Message = "Data retrieved successfully",
                    StatusCode = response.StatusCode,
                    AssociateResult = data,
                    Error = null
                };
            }
            catch (Exception ex)
            {
                return new AssociateModel
                {
                    Message = "Error retrieving data",
                    StatusCode = HttpStatusCode.InternalServerError,
                    AssociateResult = null,
                    Error = ex.Message
                };
            }
        }

        public async Task<AssociateModel> Post(string postId)
        {
            string url = $"https://jsonplaceholder.typicode.com/posts";

            Dictionary<string, string> requestData = new Dictionary<string, string>() { { "postId", postId } };
            try
            {
                FormUrlEncodedContent requestBody = new FormUrlEncodedContent(requestData);
                HttpResponseMessage response = await client.PostAsync(url, requestBody);
                string json = await response.Content.ReadAsStringAsync();
                Console.WriteLine(json);
                AssociateResultRoot data = JsonSerializer.Deserialize<AssociateResultRoot>(json);

                return new AssociateModel
                {
                    Message = "Data retrieved successfully",
                    StatusCode = response.StatusCode,
                    AssociateResult = data,
                    Error = null
                };
            }
            catch (Exception ex)
            {
                return new AssociateModel
                {
                    Message = "Error retrieving data",
                    StatusCode = HttpStatusCode.InternalServerError,
                    AssociateResult = null,
                    Error = ex.Message
                };
            }
        }


    }
}
