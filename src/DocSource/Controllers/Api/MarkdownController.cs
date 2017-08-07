using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Microsoft.AspNetCore.Hosting;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DocSource.Controllers.Api
{
    [Route("api/[controller]")]
    public class MarkdownController : Controller
    {
        private IHostingEnvironment _env;
        public MarkdownController(IHostingEnvironment env)
        {
            _env = env;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                id = "index";
            }

            var relativePathCurrent = $"App_Data/docs/{id}.md";
            var filePath = Path.Combine(_env.ContentRootPath, relativePathCurrent);
            if (!System.IO.File.Exists(filePath))
            {
                return "No Content Found";
            }
            
            return System.IO.File.ReadAllText(filePath);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody]string value)
        {
        }
    }
}
