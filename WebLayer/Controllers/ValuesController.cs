namespace WebLayer.Controllers
{
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Web.Http;
    using Newtonsoft.Json;
    using ServiceLayer;

    public class ValuesController : ApiController
    {
        private readonly IValuesService _valuesService;

        public ValuesController(IValuesService valuesService)
        {
            _valuesService = valuesService;
        }


        // GET: api/Values
        [HttpGet]
        [Route("api/values")]
        public HttpResponseMessage Get()
        {
            var response = this.Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(JsonConvert.SerializeObject(_valuesService.GetPerson()), Encoding.UTF8, "application/json");
            return response;
        }
    }
}
