using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Mysql.Helper;
using Mysql.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mysql.Controllers
{
    public class Dashboard : Controller
    {
        private readonly MyDBContext db;
        private readonly IHubContext<Dashboards> _signalrHub;

        public Dashboard(MyDBContext db, IHubContext<Dashboards> signalrHub)
        {
            this.db = db;
            _signalrHub = signalrHub; 

        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]

        public IActionResult GetProducts()
        {
            var res = db.products.ToList();
            return Ok(res);
        }

        public async Task<IActionResult> SaveAssets(Products assets)
        {
            if (ModelState.IsValid)
            {
                db.Add(assets);
                await db.SaveChangesAsync();
                await _signalrHub.Clients.All.SendAsync("LoadProducts");
                return RedirectToAction(nameof(Index));
            }
            
            return View(assets);
        }

    }
}
