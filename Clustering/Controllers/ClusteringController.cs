using Microsoft.AspNetCore.Mvc;
using System;

namespace Clustering
{
    [Route("api/[controller]")]
    public class ClusteringController : Controller
    {
        private IClusteringService _clusteringService;

        public ClusteringController(IClusteringService clusteringService)
        {
            _clusteringService = clusteringService;
        }

        [HttpPost("learn")]
        public IActionResult Learn([FromBody] LearnViewModel vm)
        {
            try
            {
                _clusteringService.Learn(vm.Observations, vm.AmountOfClusters);
                return Ok("Success");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("decide")]
        public IActionResult Decide([FromBody] DecideViewModel vm)
        {
            try
            {
                var result = _clusteringService.Decide(vm.Observations);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}