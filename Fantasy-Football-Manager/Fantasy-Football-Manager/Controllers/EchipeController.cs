using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fantasy_Football_Manager.Models;
using Fantasy_Football_Manager.ViewModels;
using Fantasy_Football_Manager.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Fantasy_Football_Manager.Controllers
{
    public class EchipeController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IEchipaRepo _echipaRepo;

        public EchipeController(ApplicationDbContext applicationDbContext, IEchipaRepo echipaRepo)
        {
            _echipaRepo = echipaRepo;
            _applicationDbContext = applicationDbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateTeam(int idLiga)
        {
            ViewData["idLiga"] = idLiga;
            List<Jucator> portari = _echipaRepo.GetJucatori("Portar");
            List<Jucator> mijlocasi = _echipaRepo.GetJucatori("Mijlocas");
            List<Jucator> fundasi = _echipaRepo.GetJucatori("Fundas");
            List<Jucator> atacanti = _echipaRepo.GetJucatori("Atacant");
            ViewData["Portar1"] = new SelectList(portari, "JucatorId", "Nume");
            ViewData["Portar2"] = new SelectList(portari, "JucatorId", "Nume");
            ViewData["Fundas1"] = new SelectList(fundasi, "JucatorId", "Nume");
            ViewData["Fundas2"] = new SelectList(fundasi, "JucatorId", "Nume");
            ViewData["Fundas3"] = new SelectList(fundasi, "JucatorId", "Nume");
            ViewData["Fundas4"] = new SelectList(fundasi, "JucatorId", "Nume");
            ViewData["Fundas5"] = new SelectList(fundasi, "JucatorId", "Nume");
            ViewData["Mijlocas1"] = new SelectList(mijlocasi, "JucatorId", "Nume");
            ViewData["Mijlocas2"] = new SelectList(mijlocasi, "JucatorId", "Nume");
            ViewData["Mijlocas3"] = new SelectList(mijlocasi, "JucatorId", "Nume");
            ViewData["Mijlocas4"] = new SelectList(mijlocasi, "JucatorId", "Nume");
            ViewData["Mijlocas5"] = new SelectList(mijlocasi, "JucatorId", "Nume");
            ViewData["Atacant1"] = new SelectList(atacanti, "JucatorId", "Nume");
            ViewData["Atacant2"] = new SelectList(atacanti, "JucatorId", "Nume");
            ViewData["Atacant3"] = new SelectList(atacanti, "JucatorId", "Nume");
            
            return View();
        }

        [HttpPost]
        public IActionResult CreateTeam(CreateEchipa createEchipa)
        {
            Console.WriteLine(createEchipa.LigaId);
            if (ModelState.IsValid)
            {
                _echipaRepo.AddTeam(createEchipa);
            }
            return RedirectToAction("GetLeaguesWithUser","Ligi");
        }

        public IActionResult GetTeam(int? id)
        {
            List<PlayerAllInfoDTO> jucatori = _echipaRepo.GetPlayersByTeam((int)id);

            ViewData["jucatori"] = jucatori;

            return View();
        }
    }
}
