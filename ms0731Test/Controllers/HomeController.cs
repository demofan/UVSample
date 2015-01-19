using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace ms0731Test.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            var webClient = new WebClient();
            var baseUri = "http://opendata.epa.gov.tw/ws/Data/UV/?format=json";
            var result = webClient.DownloadData(baseUri);
            var jsonData = Encoding.UTF8.GetString(result);
            if (Session["city"]!=null)
            {
                var ciry = Session["city"].ToString().Replace("台", "臺");
                var data = JsonConvert.DeserializeObject<List<UV>>(jsonData).Where(d => d.County == ciry).ToList();
                ViewData.Model = data;
            }
            else
            {
                ViewData.Model = JsonConvert.DeserializeObject<List<UV>>(jsonData);
            }

            return View();
        }

        public void CityName(string name)
        {
            Session["city"] = name;
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}