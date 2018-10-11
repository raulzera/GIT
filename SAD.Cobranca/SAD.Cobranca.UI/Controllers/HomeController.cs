using System;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using CC.SAD.Cobranca.Infra.CrossCutting.MvcFilters;

namespace SAD.Cobranca.UI.Controllers
{
    [RoutePrefix("")]
    public class HomeController : BaseController
    {
        [HttpGet]
        [Route("")]
        [ClaimsAuthorize("sad", "sadl")]
        public ActionResult Index()
        {
            var caminhoRaiz = AppDomain.CurrentDomain.BaseDirectory + @"\Arquivos";
            if (new DirectoryInfo(caminhoRaiz).Exists)
            {
                if (new DirectoryInfo(caminhoRaiz).GetDirectories().Length > 0)
                {
                    var pasta = new DirectoryInfo(caminhoRaiz).GetDirectories("*", SearchOption.AllDirectories).OrderByDescending(d => d.LastWriteTimeUtc).First();


                    if (new DirectoryInfo(pasta.FullName).EnumerateFiles().Any())
                    {
                        var caminhoArquivo = Path.Combine(pasta.FullName, Directory.GetFiles(pasta.FullName).First());
                        ViewBag.CaminhoAnalitico = caminhoArquivo;
                    }
                }
            }

            return View();
        }
    }
}