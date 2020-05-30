using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Linq;
using System.Xml.Linq;


namespace BG.Web.UI.Models
{

    public class VizierType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Checked { get; set; }

        public static VizierType GetById(int id)
        {
            var doc = XDocument.Load(System.Web.HttpContext.Current.Server.MapPath("~/App_Data/XMLData/VizierType.xml"));

            var records = (from p in doc.Descendants("VizierType")
                           select new VizierType
                           {
                               Id = int.Parse(p.Element("Id").Value),
                               Name = p.Element("Name").Value,
                               Checked = false
                           }).AsQueryable();

            var extrs = records.ToList();

            var extr = extrs.Where(x => x.Id == id).FirstOrDefault(); 

            return extr;

        }

        public static IEnumerable<VizierType> GetAll()
        {
            //VizierType
            var doc = XDocument.Load(System.Web.HttpContext.Current.Server.MapPath("~/App_Data/XMLData/VizierType.xml"));
            var total = doc.Descendants("VizierType").Count();
            var records = (from p in doc.Descendants("VizierType")
                           select new VizierType
                           {
                               Id = int.Parse(p.Element("Id").Value),
                               Name = p.Element("Name").Value,
                               Checked = false
                           }).AsQueryable();

            var extrs = records.ToList();

            return extrs;

        }


    }

}

