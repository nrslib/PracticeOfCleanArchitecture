using System.Linq;
using ClArc.Sync;
using Microsoft.AspNetCore.Mvc;
using UseCase.Users.Create;
using UseCase.Users.GetList;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class UserController : Controller {
        private readonly UseCaseBus bus;

        public UserController(UseCaseBus bus) {
            this.bus = bus;
        }


        public IActionResult Index()
        {
            var request = new UserGetListRequest();
            var response = bus.Handle(request);

            var summaries = response.Summaries
                .Select(x => new UserSummaryViewModel(x.Id, x.UserName))
                .ToList();
                
            return View(summaries);
        }

        public IActionResult NewUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterUserViewModel model) {
            var username = model.UserName;

            var request = new UserCreateRequest(username);
            var response = bus.Handle(request);

            return Redirect("Index");
        }
    }
}
