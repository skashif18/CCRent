using Appo.Server.Features.ServiceAttachment.Model;
using AutoMapper;
using CoreBusiness;
using CoreBusiness.Master;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Plugins.DataStore.SQL.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.IO;
using UseCases.DataStorePluginInterfaces.SrvTable;

namespace Appo.Server.Features.ServiceAttachment.Service
{
    public class ServiceAttachmentService : IServiceAttachmentService
    {
        private const string UploadDirectory = "upload/serviceImage";

        private readonly IWebHostEnvironment env;

        private readonly IServiceAttachmentRepository repository;
        private readonly ICurrentUserService currentUser;

        private readonly IMapper mapper;

        Response response= new();
        private SrvServiceAttachment dbmodel = new();
        private object postedFile;

        public ServiceAttachmentService(IServiceAttachmentRepository _repository, IMapper _mapper, IWebHostEnvironment _env, ICurrentUserService _currentUser)
        {
            repository = _repository;
            mapper = _mapper;
            env = _env;
            currentUser = _currentUser;
        }

        public Response Create(IFormFile files, IFormCollection formFileCollection)
        {

            int serviceId = Convert.ToInt32(formFileCollection["serviceId"]);
            int attachmentTypeId = Convert.ToInt32(formFileCollection["attachmentId"]);


            string filePath = GetFilePath();

            ServiceAttachmentRequestModel model = new();
            model.ServiceId = Convert.ToInt32(formFileCollection["serviceId"]);
            model.ServiceTypeAttachmentId = attachmentTypeId;
            model.FileUrlpath = filePath;
            model.ServerLocalPath = filePath;
            model.FileType = 1;
            model.IsActive = false;
            model.Note = "";

            string email = currentUser.GetUserName();


            bool exist = repository.CheckDuplicate(attachmentTypeId, serviceId, email);
            var response = new Response();

            if (!exist)
            {
                dbmodel = mapper.Map<SrvServiceAttachment>(model);
                response  = repository.Create(dbmodel);
            }

            var ext = Path.GetExtension(files.FileName);
            string fileName = "" + serviceId + "_" + attachmentTypeId + ext;
            string serverLocalPath = $"http://135.181.134.124:8001//{UploadDirectory}/{fileName}";

            dbmodel.Id = response.Id;
            dbmodel.ServerLocalPath = serverLocalPath;
            dbmodel.FileUrlpath= UploadDirectory + "/" + fileName;
            dbmodel.IsActive = true;
            response.IsSuccess = true;
            response.Objects = dbmodel;
            if (!exist)
            {
                var updateresponse = repository.Update(dbmodel);
            }

            UploadFile(files, filePath, fileName);

            return response;
        }

        public Response Delete(int Id)
        {
            return repository.Delete(Id);
        }

        public ServiceAttachmentResponseModel GetById(int Id)
        {
            var model = repository.GetById(Id);
            return mapper.Map<ServiceAttachmentResponseModel>(model);
        }

        public IEnumerable<ServiceAttachmentResponseModel> GetByServiceId(int serviceId)
        {
            var model = repository.GetByServiceId(serviceId);
            return mapper.Map<IEnumerable<ServiceAttachmentResponseModel>>(model);
        }

        public Response Update(ServiceAttachmentRequestModel model)
        {
            dbmodel = mapper.Map<SrvServiceAttachment>(model);
            return repository.Create(dbmodel);
        }

        public Stream GetImage(string filePath)
        {
            string wwwPath = env.WebRootPath;

            FileStream stream = null;
            if(filePath != null && filePath != "")
            {
                string path = Path.Combine(env.ContentRootPath, filePath);

                if (File.Exists(path))
                {
                    stream = new FileStream(path, FileMode.Open);
                }
       
            }
            return stream;
        }

        private Boolean UploadFile(IFormFile file, string filePath, string fileName)
        {

            string wwwPath = env.WebRootPath;

            var directory = GetFilePath();

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            var path = Path.Combine(directory,fileName);


            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return true;
        }

        private string GetFilePath()
        {
            string contentPath = env.ContentRootPath;

            var filePath = Path.Combine(contentPath, UploadDirectory);

            return filePath;
        }
    }
}
