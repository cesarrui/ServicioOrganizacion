

using ServicioOrganizacionDDD.DataAccess.Repositories;
using ServicioOrganizacionDDD.Domain.Entities;
using ServicioOrganizacionDDD.Domain.Repositories;

namespace ServicioOrganizacionDDD.DataAccess.Test
{
    public class PaisRepositoryTest
    {
        [Fact]
        public async Task GetPais()
        {
            //Arrange 
            List<Pais> paises = new List<Pais>();
            IPaisRepository paisRepository = new PaisRepository();

            // Act
            paises = paisRepository.GetPais();

            //Assert
            Assert.True(paises.Count >0);

        }
    }
}