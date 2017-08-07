using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

namespace DocSource.Controllers
{
    [Route("[controller]")]
    public class DocsController : Controller
    {
        private IHostingEnvironment _env;
        public DocsController(IHostingEnvironment env)
        {
            _env = env;
        }

        [Route("{*path}")]
        public async Task<ActionResult> Index(string path, bool edit = false)
        {
            if (string.IsNullOrEmpty(path))
            {
                path = "index";
            }

            ViewBag.IsEdit = edit;
            ViewBag.Path = path;

            return View();
        }
    }
}
