using ServicioOrganizacionDDD.DataAccess.Repositories;
using ServicioOrganizacionDDD.Domain.Entities;
using ServicioOrganizacionDDD.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioOrganizacionDDD.DataAccess.Test
{
    public class AreaRepositoryTest
    {
        [Fact]
        public async Task GetArea()
        {
            //Arrange
            int idPais = 1;
            List<Area> areas = new List<Area>();
            IAreaRepository areaRepository = new AreaRepository();

            //Act
            areas = areaRepository.GetArea(idPais);

            //Assert
            Assert.True(areas.Count > 0);

        }
        [Fact]
        public async Task GetSubArea()
        {
            //Arrange
            int idArea = 1;
            List<SubArea> subAreas = new List<SubArea>();
            IAreaRepository areaRepository = new AreaRepository();

            //Act
            subAreas = areaRepository.GetSubArea(idArea);

            //Assert
            Assert.True(subAreas.Count > 0);
        }
    }
}
