using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fantasy_Football_Manager.Data;
using Fantasy_Football_Manager.Models;
using Fantasy_Football_Manager.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Fantasy_Football_Manager.Controllers
{
    public class LigiController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LigiController(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }


    }
}
