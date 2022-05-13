using CoreBusiness;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Appo.Server.Features
{
    [Route("upload/[controller]")]
    [AllowAnonymous]
    public class ImageController : ApiController
    {
        private const string UploadDirectory = "upload/serviceImage";

        private readonly IWebHostEnvironment env;


        Response response = new();
        private object postedFile;

        public ImageController(IWebHostEnvironment _env)
        {
            env = _env;
        }

        // GET: api/<ImageController>
        [HttpGet("{imagePath}")]
        public Stream GetImage(string imagePath)
        {
            string wwwPath = env.WebRootPath;
            string path1 = Path.Combine(env.ContentRootPath, UploadDirectory);
            string path = Path.Combine(path1, imagePath);

            FileStream stream = null;
            
            stream = new FileStream(path, FileMode.Open);
            

            return stream;

            //\
        }
    }
}
