﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Models.Branch;
using LibraryData;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class BranchController : Controller
    {
        private ILibraryBranch _branch;

        public BranchController(ILibraryBranch branch)
        {
            _branch = branch;
        }

        public IActionResult Index()
        {
            var branches = _branch.GetAll().Select(br => new BranchDetailModel
            {
                Id = br.Id,
                BranchName = br.Name,
                NumberOfAssets = _branch.GetAssets(br.Id).Count(),
                NumberOfPatrons = _branch.GetPatrons(br.Id).Count(),
                IsOpen = _branch.IsBranchOpen(br.Id)
            }).ToList();

            var model = new BranchIndexModel()
            {
                Branches = branches
            };

            return View(model);
        }

        public IActionResult Detail(int id)
        {
            var branch = _branch.Get(id);
            var model = new BranchDetailModel
            {
                BranchName = branch.Name,
                Description = branch.Description,
                Address = branch.Adress,
                Telephone = branch.Telephone,
                BranchOpenedDate = branch.OpenDate.ToString("yyyy-MM-dd"),
                NumberOfPatrons = _branch.GetPatrons(id).Count(),
                NumberOfAssets = _branch.GetAssets(id).Count(),
                TotalAssetValue = _branch.GetAssets(id).Sum(a => double.Parse(a.Cost.Replace('.',','))),
                ImageUrl = branch.ImageUrl,
                HoursOpen = _branch.GetBranchHours(id)
            };

            return View(model);
        }
    }
}