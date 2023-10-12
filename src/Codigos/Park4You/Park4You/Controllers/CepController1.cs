using Microsoft.AspNetCore.Mvc;

namespace Park4You.Controllers
{
    public class CepController1 : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Cep = Park4You.Cep.Busca("30512430");
            return View();
        }

        public string Consulta(string cep)
        {
            var cepObj = Park4You.Cep.Busca(cep);
            return new JavaScriptSerializer().Serialize(cepObj);

        }
    }
}
