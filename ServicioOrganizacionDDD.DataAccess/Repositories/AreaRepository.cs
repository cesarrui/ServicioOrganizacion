

using ServicioOrganizacionDDD.Domain.Repositories;
using System.Data.SqlClient;
using System.Data;
using ServicioOrganizacionDDD.Domain.Entities;

namespace ServicioOrganizacionDDD.DataAccess.Repositories
{
    public class AreaRepository : IAreaRepository
    {
        private readonly string connectionString = Environment.GetEnvironmentVariable("SqlConnectionString");
        public List<Area> GetArea(int idPais)
        {
            List<Area> areas = new();
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand("ObtenerAreasPorPais", connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    // Agregar parámetro para el idPais
                    sqlCommand.Parameters.AddWithValue("@idPais", idPais);

                    connection.Open();

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Area area = new Area()
                            {
                                idArea = Convert.ToInt32(reader["idArea"]),
                                nombreArea = reader["nombreArea"].ToString(),
                                idPais = Convert.ToInt32(reader["idPais"]),
                            };
                            areas.Add(area);
                        }
                    }
                }

                return areas;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return areas;
            }
        }

        public List<SubArea> GetSubArea(int idArea)
        {
            List<SubArea> subAreas = new();

            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand("ObtenerSubareasPorArea", connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    // Agregar parámetro para el idArea
                    sqlCommand.Parameters.AddWithValue("@idArea", idArea);

                    connection.Open();

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            SubArea subArea = new SubArea()
                            {
                                idSubArea = Convert.ToInt32(reader["idSubArea"]),
                                nombreSubArea = reader["nombreSubArea"].ToString(),
                                idArea = Convert.ToInt32(reader["idArea"]),
                            };
                            subAreas.Add(subArea);
                        }
                    }
                }

                return subAreas;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return subAreas;
            }
        }
    }
}