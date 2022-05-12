﻿using Appo.Server.Features.ServiceAttachmentType.Model;
using AutoMapper;
using CoreBusiness;
using CoreBusiness.Master;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Net.Http.Headers;
using UseCases.DataStorePluginInterfaces.SrvTable.SrvMaster;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Mvc;

namespace Appo.Server.Features.ServiceAttachmentType.Service
{
    public class ServiceAttachmentType : IServiceAttachmentType

    {

        private readonly IServiceTypeAttachmentRepository repository;

        private readonly IWebHostEnvironment Environment;

        private readonly IMapper mapper;

        private SrvServiceAttachment dbmodel = new();

        public ServiceAttachmentType(IServiceTypeAttachmentRepository _repository, IMapper _mapper, IWebHostEnvironment _hostEnvironment)
        {
            repository = _repository;
            mapper = _mapper;
            Environment = _hostEnvironment;
        }


        public ServiceAttachmentTypeResponseModel GetById(int Id)
        {
            var model = repository.GetById(Id);
            return mapper.Map<ServiceAttachmentTypeResponseModel>(model);
        }

        public IEnumerable<ServiceAttachmentTypeResponseModel> GetByServiceTypeId(int serviceId)
        {
            var list = repository.GetByServiceTypeId(serviceId);
            return mapper.Map<IEnumerable<ServiceAttachmentTypeResponseModel>>(list);
        }

        public Response UploadFile(IList<IFormFile> files, IDictionary<string,string> data)
        {
            string wwwPath = this.Environment.WebRootPath;
            string contentPath = this.Environment.ContentRootPath;

            string path = contentPath + $"\\upload\\serviceImage";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            List<string> uploadedFiles = new List<string>();
            foreach (IFormFile postedFile in files)
            {
                string fileName = Path.GetFileName(postedFile.FileName);
                string[] fileName1 = fileName.Split(".");
                using (FileStream stream = new FileStream(Path.Combine(path, $"{data["serviceId"]}_{data["attachmentId"]}.{fileName1[1]}"), FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                    uploadedFiles.Add(fileName);
                }
            }

            return null;


        }

        public Stream GetImage(int serviceId, int attachmentId)
        {
            string contentPath = this.Environment.ContentRootPath;

            string path = contentPath + $"\\upload\\serviceImage\\{"" + serviceId}_{"" + attachmentId}.png";
            Stream stream = null;

            if (File.Exists(path))
            {
                stream = File.OpenRead(path);
            }

            return stream;
        }
    }
}
