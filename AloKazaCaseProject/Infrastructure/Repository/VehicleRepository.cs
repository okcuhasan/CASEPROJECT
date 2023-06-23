using AloKazaCaseProject.Core.Entities;
using AloKazaCaseProject.Core.Interfaces;
using Dapper;
using System.Data.SqlClient;

namespace AloKazaCaseProject.Infrastructure.Repository
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly IConfiguration _configuration;


        // DEPENDENCY INJECTION
        public VehicleRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> Add(Vehicle entity)
        {
            var sql = "INSERT INTO [dbo].[Vehicle] ([VehicleName], [CarBrand], [AccidentSituation], [TotalPrice]) VALUES (@VehicleName, @CarBrand, @AccidentSituation, @TotalPrice)";

            using (var connection =  new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return true;
            }
        }

        public async Task<IEnumerable<Vehicle>> GetAll()
        {
            var sql = "SELECT * FROM Vehicle";

            using(var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<Vehicle>(sql);
                return result.ToList();
            }
        }

        public async Task<Vehicle?> GetById(int id)
        {
            var sql = "SELECT * FROM Vehicle WHERE Id = @Id";

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<Vehicle>(sql, new {Id = id});
                return result;
            }
        }
        
        public async Task<bool> Remove(int id)
        {
            var sql = "DELETE FROM Vehicle WHERE Id = @Id";

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, new {Id = id});
                return true;
            }
        }

        public async Task<bool> Update(Vehicle entity)
        {
            var sql = "UPDATE Vehicle SET VehicleName = @VehicleName, CarBrand = @CarBrand, AccidentSituation = @AccidentSituation, TotalPrice = @TotalPrice WHERE Id = @Id";

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                await connection.ExecuteAsync(sql, entity);
                return true;
            }
        }





    }
}
