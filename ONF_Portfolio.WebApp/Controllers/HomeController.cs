using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ONF_Portfolio.WebApp.Models;
using ONF_Portfolio.WebApp.Services;

namespace ONF_Portfolio.WebApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly DapperService _dapperService;

    public HomeController(ILogger<HomeController> logger, DapperService dapperService)
    {
        _logger = logger;
        _dapperService = dapperService;
    }

    public async Task<IActionResult> Index()
    {
        try
        {
            var projects = await _dapperService.GetProjectsAsync();
            return View(projects);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while fetching projects.");
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
