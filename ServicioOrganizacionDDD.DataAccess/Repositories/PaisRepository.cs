using ServicioOrganizacionDDD.Domain.Entities;
using ServicioOrganizacionDDD.Domain.Repositories;
using System.Data.SqlClient;
using System.Data;

namespace ServicioOrganizacionDDD.DataAccess.Repositories
{
    public class PaisRepository : IPaisRepository
    {
        private readonly string connectionString = Environment.GetEnvironmentVariable("SqlConnectionString");
        public List<Pais> GetPais()
        {
            List<Pais> paises = new();

            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand("ObtenerPaises", connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    connection.Open();

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Pais pais = new Pais()
                            {
                                idPais = Convert.ToInt32(reader["idPais"]),
                                nombrePais = reader["nombrePais"].ToString(),

                            };
                            paises.Add(pais);
                        }
                    }
                }

                return paises;

            }
            catch (Exception ex)
            {
                return paises;
            }
        }
    }
}