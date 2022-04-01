using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DogGo.Repositories;
using DogGo.Models;
using DogGo.Controllers;
using System.Collections.Generic;
using DogGo.Models.ViewModels;
using System.Security.Claims;

namespace DogGo.Controllers
{
    public class WalkerController : Controller
    {
        private readonly IWalkerRepository _walkerRepo;
        private readonly IWalkRepository _walkRepo;

        // ASP.NET will give us an instance of our Walker Repository. This is called "Dependency Injection"
        public WalkerController(IWalkerRepository walkerRepository, IWalkRepository walkRepository)
        {
            _walkerRepo = walkerRepository;
            _walkRepo = walkRepository;
        }

        // GET: Walkers
        public ActionResult Index()
        {

            int currUserId = 0;
            List<Walker> walkers = new List<Walker>();

            if (User.FindFirstValue(ClaimTypes.NameIdentifier) != null)
            {
               currUserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            }


                if (currUserId != 0)
            {
                walkers = _walkerRepo.GetAllWalkersInHoodByOwnerId(currUserId);
            }
            else
            {
                walkers = _walkerRepo.GetAllWalkers();
            }

            return View(walkers);
        }



        // GET: Walkers/Details/5
        public ActionResult Details(int id)
        {
            Walker walker = _walkerRepo.GetWalkerById(id);
            List<Walk> walks = _walkRepo.GetAllWalksByWalkerId(walker.Id);
            List<Owner> clients = _walkRepo.GetAllClientsByWalkerId(walker.Id);

            WalkFormViewModel vm = new WalkFormViewModel()
            {
                Walker = walker,
                Walks =walks,
                Clients =clients
            };
            if (walker == null)
            {
                return NotFound();
            }

            return View(vm);
        }

        // GET: WalkerController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WalkerController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: WalkerController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: WalkerController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: WalkerController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: WalkerController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
