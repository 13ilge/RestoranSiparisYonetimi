using Dapper;
using Npgsql;
using RestoranSiparis.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestoranSiparis.Repositories
{
    public class StokRepository
    {
        private readonly string _connectionString;

        public StokRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<Stok>> GetAllAsync()
        {
            using var connection = new NpgsqlConnection(_connectionString);
            var query = "SELECT * FROM Stok";
            return await connection.QueryAsync<Stok>(query);
        }

        public async Task<int> AddAsync(Stok stok)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            var query = "INSERT INTO Stok (Urun_ID, StokDurum, GuncellemeTarih) VALUES (@Urun_ID, @StokDurum, @GuncellemeTarih)";
            return await connection.ExecuteAsync(query, stok);
        }

        public async Task<int> DeleteAsync(int id)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            var query = "DELETE FROM Stok WHERE Stok_ID = @id";
            return await connection.ExecuteAsync(query, new { id });
        }

        public async Task<Stok> GetStokByIdAsync(int id)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            var query = "SELECT * FROM Stok WHERE Stok_ID = @id";
            return await connection.QueryFirstOrDefaultAsync<Stok>(query, new { id });
        }

        public async Task<int> UpdateAsync(Stok stok)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            var query = "UPDATE Stok SET Urun_ID = @Urun_ID, StokDurum = @StokDurum, GuncellemeTarih = @GuncellemeTarih WHERE Stok_ID = @Stok_ID";
            return await connection.ExecuteAsync(query, stok);
        }
    }
}
    