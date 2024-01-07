using ServicioOrganizacionDDD.Domain.Entities;

namespace ServicioOrganizacionDDD.Domain.Repositories
{
    public interface IAreaRepository
    {
        List<Area> GetArea(int idPais);
        List<SubArea> GetSubArea(int idArea);
    }
}