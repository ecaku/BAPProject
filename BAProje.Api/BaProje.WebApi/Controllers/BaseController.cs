using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BaProje.WebApi.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaProje.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        public async Task<UploadModel> UploadImageFileAsync(IFormFile file,string contentType)
        {
            UploadModel uploadModel = new UploadModel();
            if (file != null)
            {
                if (file.ContentType != contentType)
                {
                    uploadModel.ErrorMessage = "Başka Formatta Dosya Yükleyemessiniz";
                    uploadModel.UploadState = UploadState.Error;
                    return uploadModel;
                }
                else
                {
                    var newName = Guid.NewGuid() + Path.GetExtension(file.FileName);
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/" + newName);
                    var stream = new FileStream(path, FileMode.Create);
                    await file.CopyToAsync(stream);

                    uploadModel.NewName = newName;
                    uploadModel.UploadState = UploadState.Success;
                    return uploadModel;
                }
            }
            else
            {
                uploadModel.UploadState = UploadState.NotExist;
                uploadModel.ErrorMessage = "Dosya mevcut Değil";
                return uploadModel;
            }

        }
        

    }
}