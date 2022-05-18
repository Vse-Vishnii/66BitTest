using _66BitApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using _66BitApp.Repositories;
using _66BitApp.ViewModels;

namespace _66BitApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly FootballerRepository footballerRepository;
        private readonly TeamRepository teamRepository;

        public HomeController(FootballerRepository footballerRepository, TeamRepository teamRepository)
        {
            this.footballerRepository = footballerRepository;
            this.teamRepository = teamRepository;
        }
        
        public IActionResult Index(int page = 1)
        {
            var pagesize = 3;
            var footballers = footballerRepository.GetRange((page - 1) * pagesize, pagesize).Result;
            var pageViewModel = new PageViewModel(footballerRepository.GetSize(), page, pagesize);
            var teams = teamRepository.GetAll().Result;
            return View(new FootballViewModel(footballers, teams, pageViewModel));
        }

        public IActionResult AddFootballer()
        {
            ViewBag.Teams = teamRepository.GetAll().Result.Select(t => t.Name).ToArray();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Footballer footballer)
        {
            footballerRepository.Add(footballer);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<ActionResult> Update(Footballer footballer)
        {
            await footballerRepository.Update(footballer.Id, footballer);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<ActionResult> Delete(Footballer footballer)
        {
            await footballerRepository.Delete(footballer.Id);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
