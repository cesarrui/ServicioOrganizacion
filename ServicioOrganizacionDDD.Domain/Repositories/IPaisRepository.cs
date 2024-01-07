using ServicioOrganizacionDDD.Domain.Entities;

namespace ServicioOrganizacionDDD.Domain.Repositories
{
    public interface IPaisRepository
    {
        List<Pais> GetPais();
    }
}