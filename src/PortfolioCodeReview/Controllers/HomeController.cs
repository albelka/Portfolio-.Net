using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PortfolioCodeReview.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace PortfolioCodeReview.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Projects()
        {
            var allRepos = Repo.GetRepos();
            List<Repo> threeRepos = new List<Repo>() { };
            foreach (var project in allRepos)
            {
                Repo newRepo = new Repo();
                newRepo.Name = project["name"].ToString();
                newRepo.HtmlUrl = project["html_url"].ToString();
                threeRepos.Add(newRepo);
            }
            var firstThree = threeRepos.Take(3);
            return View(firstThree);
        }
    }
}
