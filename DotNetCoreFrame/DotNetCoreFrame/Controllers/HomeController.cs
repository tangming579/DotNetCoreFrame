using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DotNetCoreFrame.Models;
using DotNetCoreFrame.Common;
using SqlSugar;
using ServiceCore.Helpers;
using System.Net.Http.Headers;
using System.Text;
using System.IO;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Http;

namespace DotNetCoreFrame.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Upload(List<IFormFile> files)
        {
            long size = 0;
            var result = new DbResult<bool>();
            foreach (var file in files)
            {
                //var fileName = file.FileName;
                var fileName = ContentDispositionHeaderValue
                                .Parse(file.ContentDisposition)
                                .FileName
                                .Trim('"');
                fileName = Path.Combine(Directory.GetCurrentDirectory(), $@"Files\{fileName}");
                size += file.Length;
                using (FileStream fs = System.IO.File.Create(fileName))
                {
                    file.CopyTo(fs);
                    fs.Flush();
                }
                result = GetDatasFromExcel(fileName);
            }
            ViewBag.Message = result.IsSuccess ? $"{files.Count}个文件 /{size}字节上传成功!" : $"上传失败：{result.ErrorMessage}";
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UploadFile(string z)
        {
            var sb = new StringBuilder();
            long size = 0;
            var files = Request.Form.Files;
            var result = new DbResult<bool>();
            foreach (var file in files)
            {
                //var ss = ContentDispositionHeaderValue.Parse(file.ContentDisposition);
                var filename = ContentDispositionHeaderValue
                                .Parse(file.ContentDisposition)
                                .FileName
                                .Trim('"');
                sb.Clear();
                sb.Append(filename);
                filename = Path.Combine(Directory.GetCurrentDirectory(), $@"Files\{filename}");
                size += file.Length;
                using (FileStream fs = System.IO.File.Create(filename))
                {
                    file.CopyTo(fs);
                    fs.Flush();
                }
                result = GetDatasFromExcel(filename);
            }

            var retVal = new JObject();
            retVal[Constants.Result] = result.IsSuccess ? Constants.Success : Constants.Failed;
            retVal[Constants.Reason] = result.IsSuccess ? "文件已成功上传！" : result.ErrorMessage;
            return Json(retVal);
        }

        public DbResult<bool> GetDatasFromExcel(string fileName)
        {
            var result = new DbResult<bool>() { };
            if (!System.IO.File.Exists(fileName)) return result;
           
            return result;
        }

        public async Task<ActionResult> Simulation()
        {
            return View();
        }
        
        public async Task<ActionResult> UpdateBimComponentLibrary()
        {
            return View();
        }
    }
}
