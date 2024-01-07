using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using ServicioOrganizacionDDD.Domain.Entities;
using ServicioOrganizacionDDD.DataAccess.Repositories;
using ServicioOrganizacionDDD.Domain.Repositories;

namespace ServicioOrganizacionDDD
{
    public class PaisFn
    {
        //Obtener Paises
        [FunctionName("GetPaises")]
        public async Task<IActionResult> GetPaises(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            List<Pais> paises = new List<Pais>();
            try
            {

                IPaisRepository paisRepository = new PaisRepository();
                paises = paisRepository.GetPais();
                return new OkObjectResult(paises);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(paises);
            }
        }
    }
}
