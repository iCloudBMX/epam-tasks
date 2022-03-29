using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BrainstormSessions.Core.Interfaces;
using BrainstormSessions.Core.Model;
using BrainstormSessions.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace BrainstormSessions.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBrainstormSessionRepository sessionRepository;

        public HomeController(IBrainstormSessionRepository sessionRepository)
        {
            this.sessionRepository = sessionRepository;
        }

        public async Task<IActionResult> Index()
        {
            Log.Information("Index action is making reponse");
            var sessionList = await this.sessionRepository.ListAsync();
            
            var model = sessionList.Select(session => new StormSessionViewModel()
            {
                Id = session.Id,
                DateCreated = session.DateCreated,
                Name = session.Name,
                IdeaCount = session.Ideas.Count
            });

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(NewSessionModel model)
        {
            if (!ModelState.IsValid)
            {
                Log.Warning($"Model state is invalid in {nameof(Index)}");
                
                return BadRequest(ModelState);
            }
            else
            {
                await this.sessionRepository.AddAsync(new BrainstormSession()
                {
                    DateCreated = DateTimeOffset.Now,
                    Name = model.SessionName
                });
            }

            return RedirectToAction(actionName: nameof(Index));
        }

        public class NewSessionModel
        {
            [Required]
            public string SessionName { get; set; }
        }
    }
}
