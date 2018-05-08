using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;
using KundeService.Models;

namespace KundeService
{
    public class SprsmlDB
    {
        SprsmlContext db = new SprsmlContext();

        public List<brukerSprsml> hentAlleBrukerSprsml()
        {
            List<brukerSprsml> alleBrukerSprsml = db.BrukerSprsml.Select(q => new brukerSprsml()
            {
                id = q.id,
                sprsml = q.sprsml,
                email = q.email
            }).ToList();    
            return alleBrukerSprsml;
        }

        public List<faq> hentAlleFAQ()
        {
            List<faq> alleFAQ = db.FAQ.Select(q => new faq()
            {
                id = q.id,
                kategori = q.kategori,
                sprsml = q.sprsml,
                svar = q.svar
            }).ToList();
            return alleFAQ;
        }

        public brukerSprsml hentEtBrukerSprsml(int id)
        {
            BrukerSprsml etBrukerSprsml = db.BrukerSprsml.Find(id);

            var etSprsml = new brukerSprsml()
            {
                id = etBrukerSprsml.id,
                sprsml = etBrukerSprsml.sprsml,
                email = etBrukerSprsml.email
            };
            return etSprsml;
        }

        public bool lagreEtBrukerSprsml(brukerSprsml innSprsml)
        {
            var nyttSprsml = new BrukerSprsml
            {
                sprsml = innSprsml.sprsml,
                email = innSprsml.email,
            };
            try
            {
                db.BrukerSprsml.Add(nyttSprsml);
                db.SaveChanges();
            }
            catch (Exception feil)
            {
                return false;
            }
            return true;
        }

        public bool endreEtBrukerSprsml(int id, brukerSprsml innSprsml)
        {
            BrukerSprsml funnetSprsml = db.BrukerSprsml.FirstOrDefault(q => q.id == id);
            if (funnetSprsml == null)
            {
                return false;
            }
            funnetSprsml.sprsml = innSprsml.sprsml;
            funnetSprsml.email = innSprsml.email;
            try
            {
                db.SaveChanges();
            }
            catch (Exception feil)
            {
                return false;
            }
            return true;
        }
      
        public bool slettEtBrukerSprsml(int id)
        {
            try
            {
                BrukerSprsml finnSprsml = db.BrukerSprsml.Find(id);
                db.BrukerSprsml.Remove(finnSprsml);
                db.SaveChanges();
            }
            catch (Exception feil)
            {
                return false;
            }
            return true;
        }

    }
}