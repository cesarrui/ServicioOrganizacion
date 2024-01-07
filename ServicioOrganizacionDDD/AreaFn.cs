using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using ServicioOrganizacionDDD.DataAccess.Repositories;
using ServicioOrganizacionDDD.Domain.Entities;
using ServicioOrganizacionDDD.Domain.Repositories;

namespace ServicioOrganizacionDDD
{
    public class AreaFn
    {
        //Obtener Areas
        [FunctionName("GetAreas")]
        public async Task<IActionResult> GetAreas(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "GetAreas/{idPais}")] HttpRequest req,
            int idPais,
            ILogger log)
        {
            List<Area> areas = new List<Area>();
            try
            {

                IAreaRepository areaRepository = new AreaRepository();
                areas = areaRepository.GetArea(idPais);
                return new OkObjectResult(areas);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(areas);
            }
        }

        //Obtener SubAreasAreas
        [FunctionName("GetSubAreas")]
        public async Task<IActionResult> GetSubAreas(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "GetSubAreas/{idArea}")] HttpRequest req,
            int idArea,
            ILogger log)
        {
            List<SubArea> subAreas = new List<SubArea>();
            try
            {

                IAreaRepository areaRepository = new AreaRepository();
                subAreas = areaRepository.GetSubArea(idArea);
                return new OkObjectResult(subAreas);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(subAreas);
            }
        }
    }
}
