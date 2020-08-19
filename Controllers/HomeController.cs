using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using tenthMVP.Models;

namespace tenthMVP.Controllers {
    public class HomeController : Controller {

        //********************************************************************//

        private MyContext _context;

        public HomeController (MyContext context) {
            _context = context;
        }
        //********************* GET METHOD

        [HttpGet ("")]
        public ViewResult Index () {

            List<Dish> AllDishes = _context.Dishes.ToList ();

            return View (AllDishes);
        }

        [HttpGet ("newdish")]
        public ViewResult NewDish () {
            return View ();
        }

        [HttpGet ("detail/{dishId}")]
        public IActionResult Detail (int dishId) {
            Dish show = _context.Dishes.FirstOrDefault (dish => dish.DishId == dishId);

            return View (show);
        }

        [HttpGet ("editdish/{dishId}")]
        public IActionResult Edit (int dishId) {
            Dish Edit = _context.Dishes.FirstOrDefault (dish => dish.DishId == dishId);

            return View (Edit);
        }

        [HttpGet ("delete/{dishId}")]
        public IActionResult Delete (int dishId) {
            Dish GetDish = _context.Dishes.SingleOrDefault (dish => dish.DishId == dishId);
            _context.Dishes.Remove (GetDish);
            _context.SaveChanges ();
            return RedirectToAction ("Index");
        }

        //********************* POST METHODS

        [HttpPost ("adddish")]
        public IActionResult AddDish (Dish newDish) {

            if (ModelState.IsValid) {
                _context.Dishes.Add (newDish);
                _context.SaveChanges ();
                Console.WriteLine (newDish.Name);
                return RedirectToAction ("Index");
            } else {
                return View ("NewDish");
            }

        }

        [HttpPost ("update")]
        public IActionResult Update (Dish update) {

            if (ModelState.IsValid) {
                Dish GetDish = _context.Dishes.FirstOrDefault (d => d.DishId == update.DishId);
                GetDish.Name = update.Name;
                GetDish.DishName = update.DishName;
                GetDish.Calories = update.Calories;
                GetDish.Taste = update.Taste;
                GetDish.Description = update.Description;
                _context.SaveChanges ();
                Console.WriteLine (update);
                return RedirectToAction ("Index");
            } else {
                return View ("Edit", update);


        }

        //********************************************************************//

        [ResponseCache (Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error () {
            return View (new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}