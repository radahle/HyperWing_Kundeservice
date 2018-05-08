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
    public class BrukerSprsmlController : ApiController
    {
        SprsmlDB brukerSprsmlDb = new SprsmlDB();

        // GET api/Kunde
        public HttpResponseMessage Get()
        {
            List<brukerSprsml> alleBrukerSprsml = brukerSprsmlDb.hentAlleBrukerSprsml();

            var Json = new JavaScriptSerializer();
            string JsonString = Json.Serialize(alleBrukerSprsml);

            return new HttpResponseMessage()
            {
                Content = new StringContent(JsonString, Encoding.UTF8, "application/json"),
                StatusCode = HttpStatusCode.OK
            };
        }

        // GET api/Kunde/5
        public HttpResponseMessage Get(int id)
        {
            brukerSprsml etBrukerSprsml = brukerSprsmlDb.hentEtBrukerSprsml(id);

            var Json = new JavaScriptSerializer();
            string JsonString = Json.Serialize(etBrukerSprsml);

            return new HttpResponseMessage()
            {
                Content = new StringContent(JsonString, Encoding.UTF8, "application/json"),
                StatusCode = HttpStatusCode.OK
            };
        }

        // POST api/Kunde
        [HttpPost]
        public HttpResponseMessage Post([FromBody]brukerSprsml innSprsml)
        {

            if (ModelState.IsValid)
            {
                bool OK = brukerSprsmlDb.lagreEtBrukerSprsml(innSprsml);
                if (OK)
                {
                    return new HttpResponseMessage()
                    {
                        StatusCode = HttpStatusCode.OK
                    };

                }
            }
            return new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.BadRequest,
                Content = new StringContent("Kunne ikke sette inn spørsmål i DB")
            };
        }

        // PUT api/Kunde/5
        public HttpResponseMessage Put(int id, [FromBody]brukerSprsml innSprsml)
        {
            if (ModelState.IsValid)
            {
                bool OK = brukerSprsmlDb.endreEtBrukerSprsml(id, innSprsml);
                if (OK)
                {
                    return new HttpResponseMessage()
                    {
                        StatusCode = HttpStatusCode.OK
                    };
                }
            }
            return new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.NotFound,
                Content = new StringContent("Kunne ikke endre spørsmålet i DB")
            };

        }

        // DELETE api/Kunde/5
        public HttpResponseMessage Delete(int id)
        {
            bool OK = brukerSprsmlDb.slettEtBrukerSprsml(id);
            if (!OK)
            {
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Content = new StringContent("Kunne ikke slette spørsmålet i DB")
                };
            }
            return new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK
            };
        }
    }
}