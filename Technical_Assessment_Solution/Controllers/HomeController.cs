using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Technical_Assessment_Solution.Business;
using Technical_Assessment_Solution.Models;

namespace Technical_Assessment_Solution.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;



        private IApiHelper _apiHelper { get; set; }

        public HomeController(ILogger<HomeController> logger, IApiHelper apiHelper)
        {
            _logger = logger;

            _apiHelper = apiHelper;
        }



        public async Task<IActionResult> Assessment()
        {
            AssessmentViewModel res = await _apiHelper.GetJsonData();

            return View(res);
        }

    }
}
