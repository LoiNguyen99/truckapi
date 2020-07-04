using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace truckapi.Controllers
{
    [Route("api/files")]
    [ApiController]
    public class FilesControllers : ControllerBase
    {
        [HttpPost("images")]
        public async Task<String> Get([FromForm] Image image)
        {
            Stream fs = image.File.OpenReadStream();
            return await FileServices.getFile(fs, image.Name);
        }

        public class Image
        {
            public IFormFile File { get; set; }
            public string Name { get; set; }
        }
    }
}
