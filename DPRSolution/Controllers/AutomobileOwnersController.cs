using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DPRSolution.Data;
using DPRSolution.Models;
using DPRSolution.DTO;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using DPRSolution.Service;

namespace DPRSolution.Controllers
{
    public class AutomobileOwnersController : Controller
    {
        private readonly IAutoMobile  _autoMobile;
        private readonly IWebHostEnvironment _hosting;

        public AutomobileOwnersController( 
            IWebHostEnvironment hosting, IAutoMobile autoMobil)
        {
            _autoMobile = autoMobil;
            _hosting = hosting;
        }

        // GET: AutomobileOwners
      
        // GET: AutomobileOwners/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AutomobileOwners/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AutoMobileVM mobileVM)
        {
            if (ModelState.IsValid)
            {
                List<AutoFileDetail> fileDetails = new List<AutoFileDetail>();
                string uniqueFilename = null;
                if (mobileVM.Documents != null && mobileVM.Documents.Count() >3)
                {
                    foreach (var document in mobileVM.Documents)
                    {
                        string UploadFolder = Path.Combine(_hosting.WebRootPath, "img");
                        uniqueFilename = Guid.NewGuid().ToString() + "_" + document.FileName + "_" + mobileVM.Lastname;
                        string Uniquefilepath = Path.Combine(UploadFolder, uniqueFilename);
                        if (System.IO.File.Exists(Uniquefilepath))
                        {
                            System.IO.File.Delete(Uniquefilepath);
                        }
                            document.CopyTo(new FileStream(Uniquefilepath, FileMode.Create));
                        var newfile = new AutoFileDetail()
                        {
                            FileExtension = Path.GetExtension(document.FileName),
                            filename = uniqueFilename,
                            filepath = Uniquefilepath,
                             Email = mobileVM.Email,    

                        };
                        fileDetails.Add(newfile);
                    }
                    AutomobileOwner owner = new AutomobileOwner
                    {
                        CompDesc = mobileVM.CompDesc,
                        Fullname = mobileVM.Firstname + " " + mobileVM.Lastname,
                        CreatedAt = DateTime.Now,
                        Email = mobileVM.Email,
                        CreadtedBy = mobileVM.Firstname + " " + mobileVM.Lastname,
                        Documents = fileDetails

                    };
                    await _autoMobile.create(owner);
                    return View();
                }
               
               
               return RedirectToAction("Index", "Home");
            }
            return View();

        }
     
    }
}
