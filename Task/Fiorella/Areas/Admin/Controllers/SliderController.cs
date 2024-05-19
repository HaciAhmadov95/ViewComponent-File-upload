﻿using Fiorella.Data;
using Fiorella.Models;
using Fiorella.ViewModels.Sliders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fiorella.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {

        private readonly AppDbContext _context;
        public SliderController(AppDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Slider> sliders = await _context.Sliders.ToListAsync();

            List<SliderVM> result = sliders.Select(x => new SliderVM { Id = x.Id, Image = x.Image }).ToList();

            return View(result);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
    }
}
