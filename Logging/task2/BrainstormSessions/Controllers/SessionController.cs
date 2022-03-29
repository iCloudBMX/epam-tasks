using System.Threading.Tasks;
using BrainstormSessions.Core.Interfaces;
using BrainstormSessions.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace BrainstormSessions.Controllers
{
    public class SessionController : Controller
    {
        private readonly IBrainstormSessionRepository sessionRepository;

        public SessionController(IBrainstormSessionRepository sessionRepository)
        {
            this.sessionRepository = sessionRepository;
        }

        public async Task<IActionResult> Index(int? id)
        {
            Log.Debug($"Value of id is {id}");

            if (!id.HasValue)
            {
                return RedirectToAction(actionName: nameof(Index),
                    controllerName: "Home");
            }

            var session = await this.sessionRepository.GetByIdAsync(id.Value);

            Log.Debug($"Value of session is {session}");

            if (session == null)
            {
                return Content("Session not found.");
            }

            var viewModel = new StormSessionViewModel()
            {
                DateCreated = session.DateCreated,
                Name = session.Name,
                Id = session.Id
            };

            return View(viewModel);
        }
    }
}
