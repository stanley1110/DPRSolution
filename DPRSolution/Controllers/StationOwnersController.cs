using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DPRSolution.Data;
using DPRSolution.Models;
using DPRSolution.Service;
using Microsoft.AspNetCore.Hosting;
using DPRSolution.DTO;
using System.IO;

namespace DPRSolution.Controllers
{
    public class StationOwnersController : Controller
    {
        private readonly IFuelStation  _fuelStation;
        private readonly IWebHostEnvironment _hosting;

        public StationOwnersController(IFuelStation fuelStation, IWebHostEnvironment hosting)
        {
      
            _fuelStation = fuelStation;
            _hosting = hosting;
        }


        // GET: StationOwners/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StationOwners/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( StationVM  stationVM)
        {
            if (ModelState.IsValid)
            {
                List<AutoFileDetail> fileDetails = new List<AutoFileDetail>();
                string uniqueFilename = null;
                if (stationVM.Documents != null && stationVM.Documents.Count() > 3)
                {
                    foreach (var document in stationVM.Documents)
                    {
                        string UploadFolder = Path.Combine(_hosting.WebRootPath, "img");
                        uniqueFilename = Guid.NewGuid().ToString() + "_" + document.FileName + "_" + stationVM.Lastname;
                        string Uniquefilepath = Path.Combine(UploadFolder, uniqueFilename);
                     
                        document.CopyTo(new FileStream(Uniquefilepath, FileMode.Create));
                        var newfile = new AutoFileDetail()
                        {
                            FileExtension = Path.GetExtension(document.FileName),
                            filename = uniqueFilename,
                            filepath = Uniquefilepath,
                            Email = stationVM.Email,

                        };
                        fileDetails.Add(newfile);
                    }
                    StationOwner owner = new StationOwner
                    {
                        CompDesc = stationVM.CompDesc,
                         FullName = stationVM.Firstname + " " + stationVM.Lastname,
                        CreatedAt = DateTime.Now,
                        Email = stationVM.Email,
                        CreadtedBy = stationVM.Firstname + " " + stationVM.Lastname,
                         BusinessName = stationVM.BusinessName,
                        Documents = fileDetails

                    };
                    var result = await _fuelStation.create(owner);
                    if (result == "sucess")
                    {
                        ViewBag.msg = String.Format("Hello {0} your complaints has been submitted successfully on {1}.\\nWe will get back to you via E-mail", stationVM.Firstname, DateTime.Now.ToString());
                        return View();
                    }
                    else
                    {
                        ViewBag.msg = String.Format("Error. \\nTry again later");
                        return View();
                    }
                }
                ViewBag.msg = String.Format("Error. \\Requested documents are not complete \\nTry again");
                return View();
            }
            ViewBag.msg = String.Format("Error. \\Requested documents are not complete \\nTry again");
            return View();


        }

     
    }
}
