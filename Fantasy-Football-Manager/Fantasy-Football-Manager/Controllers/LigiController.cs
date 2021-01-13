using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Fantasy_Football_Manager.Data;
using Fantasy_Football_Manager.Models;
using Fantasy_Football_Manager.ViewModels;
using System.Net.Http;
using System.Web;
using System.Data;


namespace Fantasy_Football_Manager.Controllers
{
    public class LigiController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILigaRepo _ligaRepo;

        public LigiController(ApplicationDbContext applicationDbContext, ILigaRepo ligaRepo)
        {
            _context = applicationDbContext;
            _ligaRepo = ligaRepo;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Liga liga)
        {
            if (ModelState.IsValid)
            {
                _ligaRepo.AddLeague(liga);  
            }

            return View(liga);
        }

        public IActionResult GetLeaguesNoUser()
        {
            List<LeagueStats> ligi = _ligaRepo.GetLeaguesNotCurrUser().ToList();

            ViewData["Ligi"] = ligi;

            return View();
        }

        public IActionResult GetLeaguesWithUser()
        {
            List<LeagueStats> ligi = _ligaRepo.GetLeaguesWithCurrUser().ToList();

            ViewData["Ligi"] = ligi;

            return View();
        }

        public IActionResult JoinLeague(int? id)
        {
            //Console.WriteLine("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            _ligaRepo.AddNewUser((int)id);
            return RedirectToAction("CreateTeam", "Echipe", new { idLiga = (int)id});
        }

        public IActionResult GetLeaderboard(int? id)
        {
            List<TeamLeaderboard> teams = _ligaRepo.GetLeaderboard((int)id);
            ViewData["teams"] = teams;
            return View();
        }
    }
}
