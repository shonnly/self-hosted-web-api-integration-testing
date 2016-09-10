namespace IntegrationTesting
{
    using System;
    using System.Net.Http;
    using Microsoft.Owin.Hosting;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json.Linq;

    [TestClass]
    public sealed class TreePropertiesControllerTests
    {
        private readonly string _baseAddress;

        public TreePropertiesControllerTests()
        {
            _baseAddress = "http://localhost:20022";
        }

        [TestMethod]
        public void TestMethod()
        {
            // Start OWIN host 
            using (WebApp.Start<Startup>(url: _baseAddress))
            {
                // Create HttpCient and make a request to api/values 
                var client = new HttpClient();

                var responseTask = client.GetAsync($"{_baseAddress}/api/values");
                var response = responseTask.Result;

                var json = response.Content.ReadAsStringAsync().Result;
                var jObject = JObject.Parse(json);

                var propertyName = jObject.Property("Name");

                Assert.IsTrue(propertyName.Value.ToString().Equals("John Petrucci", StringComparison.Ordinal));
            }
        }
    }
}
