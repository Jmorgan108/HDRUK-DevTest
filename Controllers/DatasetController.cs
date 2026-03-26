using HDRUK_DevTest.Models;
using HDRUK_DevTest.Services;
using Microsoft.AspNetCore.Mvc;

namespace HDRUK_DevTest.Controllers
{
    public class DatasetController : Controller
    {
        private readonly DatasetService _datasetService;

        public DatasetController(DatasetService datasetService)
        {
            _datasetService = datasetService;
        }

        public async Task<IActionResult> Index()
        {
            List<HealthDataModel> datasets = await _datasetService.GetDatasets();
            return View(datasets);
        }
    }
}
