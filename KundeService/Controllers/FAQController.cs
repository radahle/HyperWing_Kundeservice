using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Script.Serialization;
using System.Net.Http.Formatting;
using System.Data.Common;

using KundeService.Models;

namespace KundeService
{
    public class FAQController : ApiController
    {
        SprsmlDB faqDb = new SprsmlDB();

        // GET api/Kunde
        public HttpResponseMessage Get()
        {
            List<faq> alleFAQ = faqDb.hentAlleFAQ();

            var Json = new JavaScriptSerializer();
            string JsonString = Json.Serialize(alleFAQ);

            return new HttpResponseMessage()
            {
                Content = new StringContent(JsonString, Encoding.UTF8, "application/json"),
                StatusCode = HttpStatusCode.OK
            };
        }
    }
}