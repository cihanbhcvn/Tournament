using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LotsController : Controller
    {
        private readonly ILotService _lotService;
        private readonly ITeamService _teamService;
        private readonly ICountryService _countryService;
        private readonly IGroupService _groupService;

        public LotsController(ILotService lotService, IGroupService groupService, ICountryService countryService, ITeamService teamService)
        {
            _lotService = lotService;
            _groupService = groupService;
            _countryService = countryService;
            _teamService = teamService;
        }

        [HttpGet("index")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("draw-lottery")]
        public IActionResult DrawLottery(DrawLotteryDto drawLotteryDto)
        {
            return Ok(_lotService.DrawLottery(drawLotteryDto));
            
        }
        [HttpGet("seed-data")]
        public IActionResult SeedData()
        {
            _countryService.SeedData();
            _teamService.SeedData();
            _groupService.SeedData();
            return Ok("Data created");
        }
    }
}
