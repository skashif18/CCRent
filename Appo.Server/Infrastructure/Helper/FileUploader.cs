
using System;
using System.IO;
using System.Linq;

namespace Appo.Server.Infrastructure.Helper
{
    public enum FileResponse
    {
        ExtNotAllowed,
        FileExists,
        ExceedFileSize,
        Nothing,
        NotImage,
        DirectoryNotExists,
        Ok
    }
    public interface IFileUploader
    {
        string GetUniqueName(string fileName);
        string GetUniqueName(string fileName, bool isContent);
        string GetUniqueFlagName(string fileName);
        bool IsThisImage(Microsoft.AspNetCore.Http.IFormFile file);
        FileResponse SaveImageFile(Microsoft.AspNetCore.Http.IFormFile file, string uploadedFileName);
        FileResponse SaveFlagFile(Microsoft.AspNetCore.Http.IFormFile file, string uploadedFileName);
        FileResponse SavePDF_DocFile(Microsoft.AspNetCore.Http.IFormFile file, string uploadedFileName);
        FileResponse SaveUploadedFile(Microsoft.AspNetCore.Http.IFormFile file, string uploadedFileName);
        FileResponse SaveUploadedFile(Microsoft.AspNetCore.Http.IFormFile file, string uploadedFileName, bool isContent, bool isFlag = false, bool isFile = false);
        void RemoveUploadedFiles(string fileName, bool isContent = false, bool isFlag = false, bool isFile = false);
    }

    public class FileUploader : IFileUploader
    {
        private const string UploadDirectory = "upload";
        private const string UploadCvsDirectory = "upload/cvs";
        private const string UploadContentDirectory = "upload/content";
        private const string UploadFlagDirectory = "upload/flags";

        private readonly string[] _allowedFileExtensions = { ".jpg", ".gif", ".png", ".jpeg", ".pdf", ".doc", ".docx", ".xls", ".xlsx", ".txt", ".svg", ".webp" };
        private readonly string[] _imageExtensions = { ".jpg", ".gif", ".png", ".jpeg", ".svg", ".webp" };


        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _env;


        public FileUploader(Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            _env = env;
        }

        public string GetUniqueName(string fileName)
        {
            return GetUniqueName(fileName, false);
        }

        public string GetUniqueName(string fileName, bool isContent)
        {
            return GetUniqueName(fileName, isContent ? UploadContentDirectory : UploadDirectory);
        }
        public string GetUniqueFlagName(string fileName)
        {
            return GetUniqueName(fileName, UploadFlagDirectory);
        }
        private string GetUniqueName(string fileName, string uploadDirectory)
        {
            var directory = Path.Combine(_env.WebRootPath, uploadDirectory);
            var ext = Path.GetExtension(fileName);
            fileName = Path.GetFileNameWithoutExtension(fileName);
            fileName = System.Text.RegularExpressions.Regex.Replace(fileName, @"\s+", "-");
            fileName = System.Text.RegularExpressions.Regex.Replace(fileName, @"[^\w\d-]", "");
            fileName = fileName + ext;
            var uniqueName = fileName;

            while (File.Exists(Path.Combine(directory, uniqueName)))
            {
                uniqueName = Guid.NewGuid().ToString().Substring(0, 8) + "_" + fileName;
            }
            return uniqueName;
        }

        private bool IsAllowedExt(string ext)
        {
            return _allowedFileExtensions.Contains(ext.ToLower());
        }

        private bool IsImage(string ext)
        {
            return _imageExtensions.Contains(ext.ToLower());
        }
        public FileResponse SaveImageFile(Microsoft.AspNetCore.Http.IFormFile file, string uploadedFileName)
        {
            return IsImage(Path.GetExtension(file.FileName)) ? SaveUploadedFile(file, uploadedFileName) : FileResponse.NotImage;
        }
        public FileResponse SaveFlagFile(Microsoft.AspNetCore.Http.IFormFile file, string uploadedFileName)
        {
            return IsImage(Path.GetExtension(file.FileName)) ? SaveUploadedFile(file, uploadedFileName, false, true) : FileResponse.NotImage;
        }

        public FileResponse SavePDF_DocFile(Microsoft.AspNetCore.Http.IFormFile file, string uploadedFileName)
        {
            return IsAllowedExt(Path.GetExtension(file.FileName)) ? SaveUploadedFile(file, uploadedFileName, false, false, true) : FileResponse.ExtNotAllowed;
        }


        public FileResponse SaveUploadedFile(Microsoft.AspNetCore.Http.IFormFile file, string uploadedFileName)
        {
            return SaveUploadedFile(file, uploadedFileName, false);
        }

        public FileResponse SaveUploadedFile(Microsoft.AspNetCore.Http.IFormFile file, string uploadedFileName, bool isContent, bool isFlag = false, bool isFile = false)
        {
            if (file == null || file.Length <= 0) return FileResponse.Nothing;
            // limit 5mb file size 5242880
            if (file.Length > 124288000) return FileResponse.ExceedFileSize;

            if (!IsAllowedExt(Path.GetExtension(file.FileName)))
            {
                return FileResponse.ExtNotAllowed;
            }


            var fileName = uploadedFileName == "" ? file.FileName : uploadedFileName;
            var directory = Path.Combine(_env.WebRootPath, isContent ? UploadContentDirectory : isFlag ? UploadFlagDirectory : isFile ? UploadCvsDirectory : UploadDirectory);

            if (File.Exists(Path.Combine(directory, fileName)))
            {
                return FileResponse.FileExists;
            }
            //   if (directory == null) return FileResponse.DirectoryNotExists;

            using (var fileStream = new FileStream(Path.Combine(directory, fileName), FileMode.Create))
            {
                file.CopyTo(fileStream);
            }


            //using (FileStream fs = System.IO.File.Create(fullFilePath))
            //{
            //    file.CopyTo(fs);
            //    fs.Flush();
            //}
            // if (fullFilePath != null) System.IO.File.WriteAllBytes(file);
            return FileResponse.Ok;
        }

        public void RemoveUploadedFiles(string fileName, bool isContent = false, bool isFlag = false, bool isFile = false)
        {
            if (fileName == null) return;
            try
            {
                var directory = Path.Combine(_env.WebRootPath, isContent ? UploadContentDirectory : isFlag ? UploadFlagDirectory : isFile ? UploadCvsDirectory : UploadDirectory);
                if (File.Exists(Path.Combine(directory, fileName)))
                {
                    File.Delete(Path.Combine(directory, fileName));
                }
            }
            catch (Exception)
            {

            }
        }

        public bool IsThisImage(Microsoft.AspNetCore.Http.IFormFile file)
        {
            return IsImage(Path.GetExtension(file.FileName));
        }
    }
}
