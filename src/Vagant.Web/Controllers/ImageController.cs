using Agile.Web.Framework.ActionResults;
using System;
using System.IO;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Vagant.Domain.Entities;
using Vagant.Domain.Services;

namespace Vagant.Web.Controllers
{
    public class ImageController : Controller
    {
        #region Fields

        private readonly IImageFileService _imageService;

        #endregion

        #region Ctor

        public ImageController(IImageFileService imageService)
        {
            _imageService = imageService;
        }

        #endregion

        #region Actions

        [HttpPost]
        public ActionResult Upload()
        {
            try
            {
                var file = GetFileFromStream();

                var imageFile = new ImageFile
                {
                    Data = ReadToEnd(file.InputStream),
                    ContentType = file.ContentType
                };

                _imageService.Create(imageFile);

                return new SuccessJsonResult(imageFile.Id);
            }
            catch (Exception)
            {
                return new HttpBadRequestResult();
            }
        }

        [HttpGet]
        public void Download(int id)
        {
            var context = HttpContext;
            try
            {
                var imageFile = _imageService.Get(id);

                if (imageFile == null)
                {
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                }

                context.Response.ContentType = imageFile.ContentType;
                context.Response.ClearContent();
                context.Response.BinaryWrite(imageFile.Data);
            }
            catch (Exception)
            {
                //log error
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
        }

        #endregion

        #region Helper Methods

        private HttpPostedFileBase GetFileFromStream()
        {
            if (Request.Files.Count > 0)
            {
                return Request.Files[0];
            }

            return null;
        }

        private byte[] ReadToEnd(Stream stream)
        {
            long originalPosition = 0;

            if (stream.CanSeek)
            {
                originalPosition = stream.Position;
                stream.Position = 0;
            }

            try
            {
                var readBuffer = new byte[4096];

                int totalBytesRead = 0;
                int bytesRead;

                while ((bytesRead = stream.Read(readBuffer, totalBytesRead, readBuffer.Length - totalBytesRead)) > 0)
                {
                    totalBytesRead += bytesRead;

                    if (totalBytesRead == readBuffer.Length)
                    {
                        int nextByte = stream.ReadByte();
                        if (nextByte != -1)
                        {
                            var temp = new byte[readBuffer.Length * 2];
                            Buffer.BlockCopy(readBuffer, 0, temp, 0, readBuffer.Length);
                            Buffer.SetByte(temp, totalBytesRead, (byte)nextByte);
                            readBuffer = temp;
                            totalBytesRead++;
                        }
                    }
                }

                byte[] buffer = readBuffer;
                if (readBuffer.Length != totalBytesRead)
                {
                    buffer = new byte[totalBytesRead];
                    Buffer.BlockCopy(readBuffer, 0, buffer, 0, totalBytesRead);
                }
                return buffer;
            }
            finally
            {
                if (stream.CanSeek)
                {
                    stream.Position = originalPosition;
                }
            }
        }

        #endregion
    }
}