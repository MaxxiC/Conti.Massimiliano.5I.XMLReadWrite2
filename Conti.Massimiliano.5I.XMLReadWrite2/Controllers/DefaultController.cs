using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Xml.Linq;

namespace Conti.Massimiliano._5I.XMLReadWrite2
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// ///
        /// </summary>

        private string nomeFile = HostingEnvironment.MapPath(@"~/App_Data/Persone.xml");

        public ActionResult PersoneXMLWeb()
        {
            XElement data = XElement.Load(nomeFile);
            var persone = (from l in data.Elements("Persona") select new Persona(l)).ToList();
            return View(persone);
        }

        public ActionResult XMLReadWrite()
        {
            var p = new Persone(nomeFile);
            return View("XMLReadWrite", p);
        }

        /// <summary>
        /// - XMLReadWrite2
        /// </summary>
        /// 

        public ActionResult XMLReadWrite2()
        {
            var p = new Persone(nomeFile);
            return View(p);
        }

        public ActionResult AddPredefinito()
        {
            var p = new Persone(nomeFile);
            p.AggiungiPredefinito();

            return View("XMLReadWrite2", p);
        }

        public ActionResult DelSelected(int IdToDel)
        {
            var p = new Persone(nomeFile);
            p.RemoveAll(x => x.IdPersona == IdToDel);
            p.Save();

            return View("XMLReadWrite2", p);
        }

        public ActionResult XML_AddContact()
        {
            return View();
        }
        public ActionResult RetContatto(Persona ctn)
        {
            var p = new Persone(nomeFile);
            p.MyAdd(ctn);
            p.Save();

            return View("XMLReadWrite2", p);
        }

        public ActionResult XML_ViewContact(int ctn)
        {
            var p = new Persone(nomeFile);
            Persona temp = p.FirstOrDefault(x => x.IdPersona == ctn);
            return View(temp);
        }

        public ActionResult XML_EditContact(int ctn)
        {
            var p = new Persone(nomeFile);
            Persona temp = p.FirstOrDefault(x => x.IdPersona == ctn);
            return View("XML_AddContact", temp);
        }

    }
}