using Dapper;
using Npgsql;
using RestoranSiparis.Models;

namespace RestoranSiparis.Repositories
{
    public class GarsonRepository
    {
        private readonly string _connectionString;

        public GarsonRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<Garson>> GetAllAsync()
        {
            using var connection = new NpgsqlConnection(_connectionString);
            var query = "SELECT * FROM Garson";
            return await connection.QueryAsync<Garson>(query);
        }

        public async Task<int> AddAsync(Garson garson)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            var query = "INSERT INTO Garson (Ad, Soyad) VALUES (@Ad, @Soyad)";
            return await connection.ExecuteAsync(query, garson);
        }

        public async Task<int> DeleteAsync(int id)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            var query = "DELETE FROM Garson WHERE Garson_ID = @id";
            return await connection.ExecuteAsync(query, new { id });
        }
        public async Task<Garson> GetGarsonByIdAsync(int id)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            var query = "SELECT * FROM Garson WHERE Garson_ID = @id";
            return await connection.QueryFirstOrDefaultAsync<Garson>(query, new { id });
        }

        public async Task<int> UpdateAsync(Garson garson)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            var query = "UPDATE Garson SET Ad = @Ad, Soyad = @Soyad WHERE Garson_ID = @Garson_ID";
            return await connection.ExecuteAsync(query, garson);
        }

    }

}
