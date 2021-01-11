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

namespace Fantasy_Football_Manager.Controllers
{
    public class JucatoriController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IJucatorRepo _jucatorRepo;

        public JucatoriController(ApplicationDbContext context, IJucatorRepo jucatorRepo)
        {
            _context = context;
            _jucatorRepo = jucatorRepo;
        }
        
        //[HttpGet("allplayers")]
        public async Task<IActionResult> PostAllPlayers()
        {
            List<Jucator> jucatori = await _jucatorRepo.GetAllPlayersAsync();

            ViewData["jucatori"] = jucatori;

            return View();
        }
      
        public async Task<IActionResult> PlayersDB()
        {
            List<Jucator> jucatori = await _jucatorRepo.GetAllPlayersAsync();

            foreach(Jucator jucator in jucatori)
            {
                StatisticiJucator statisticiJucator = new StatisticiJucator();
                statisticiJucator.StatisticiJucatorId = jucator.JucatorId;
                statisticiJucator.NrGoluri = 0;
                statisticiJucator.NrAssists = 0;
                statisticiJucator.NrCleansheets = 0;
                statisticiJucator.NrTotalPuncte = 0;
                _context.StatisticiJucatori.Add(statisticiJucator);
                jucator.StatisticiJucatorId = jucator.JucatorId;
                _context.Jucatori.Add(jucator);
                _context.SaveChanges();
            }
            return View();
        }

         public async Task<IActionResult> UpdateStatistics()
         {

             await _jucatorRepo.UpdatePlayers("2021-01-04", "2021-01-04");

             return View();
         }
        // GET: /authors/create
        
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Jucator jucator)
        {
            if (ModelState.IsValid)
            {
                StatisticiJucator statisticiJucator = new StatisticiJucator();
                statisticiJucator.NrAssists = 0;
                statisticiJucator.NrCleansheets = 0;
                statisticiJucator.NrGoluri = 0;
                statisticiJucator.NrTotalPuncte = 0;
                _jucatorRepo.AddPlayer(jucator, statisticiJucator);

                return RedirectToAction("Index");
            }

            return View(jucator);
        }

        public IActionResult Delete(Jucator jucator)
        {
            if (ModelState.IsValid)
            {
                _jucatorRepo.DeletePlayer(jucator);

                return RedirectToAction("Index");
            }

            return View(jucator);
        }

        public IActionResult EditTeam(EditPlayerTeamDTO editPlayerTeam)
        {
            if (ModelState.IsValid)
            {
                _jucatorRepo.EditTeam(editPlayerTeam);

                return RedirectToAction("Index");
            }

            return View(editPlayerTeam);
        }

        public IActionResult EditPosition(EditPlayerPositionDTO editPlayerPosition)
        {
            if (ModelState.IsValid)
            {
                _jucatorRepo.EditPosition(editPlayerPosition);

                return RedirectToAction("Index");
            }

            return View(editPlayerPosition);
        }

        public IActionResult DisplayAllStats()
        {
            Console.WriteLine("INCEPUT");
            List<PlayerAllInfoDTO> playerInfos = new List<PlayerAllInfoDTO>();

            Console.WriteLine("INAINTE DATA");
            playerInfos = _jucatorRepo.GetAllInfo();

            Console.WriteLine("DUPA DATA");
            ViewData["playersInfos"] = playerInfos;

            return View();
        }
    }
}