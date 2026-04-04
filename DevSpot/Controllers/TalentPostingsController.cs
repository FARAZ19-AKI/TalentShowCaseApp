using DevSpot.Constants;
using DevSpot.Repositories;
using DevSpot.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DevSpot.Controllers
{
    [Authorize]
    public class TalentPostingsController : Controller
    {
        private readonly IRepository<Talent> _repository;
        private readonly UserManager<IdentityUser> _userManager;

        public TalentPostingsController(
            IRepository<Talent> repository,
            UserManager<IdentityUser> userManager)
        {
            _repository = repository;
            _userManager = userManager;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var talents = await _repository.GetAllAsync();

            if (User.IsInRole(Roles.RegisteredUser))
            {
                var userId = _userManager.GetUserId(User);
                talents = talents.Where(t => t.UserId == userId);
            }

            return View(talents);
        }



        [Authorize(Roles = "Admin, RegisteredUser")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin, RegisteredUser")]
        public async Task<IActionResult> Create(TalentViewModel TalentVm)
        {
            if (ModelState.IsValid)
            {
                var talent = new Talent
                {
                    Title = TalentVm.Title,
                    Description = TalentVm.Description,
                    VideoUrl = TalentVm.Video_url,
                    Category = TalentVm.Category,
                    UserId = _userManager.GetUserId(User)
                };

                await _repository.AddAsync(talent);
                return RedirectToAction(nameof(Index));
            }

            return View(TalentVm);
        }

        [HttpDelete]
        [Authorize(Roles = "Admin, RegisteredUser")]
        public async Task<IActionResult> Delete(int id)
        {
            var talent = await _repository.GetByIdAsync(id);

            if (talent == null)
                return NotFound();

            var userId = _userManager.GetUserId(User);

            if (!User.IsInRole(Roles.Admin) && talent.UserId != userId)
                return Forbid();

            await _repository.DeleteAsync(id);

            return Ok();
        }
    }
}
