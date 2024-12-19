using Dapper;
using Npgsql;
using RestoranSiparis.Models;
namespace RestoranSiparis.Repositories
{
    

    public class KategoriRepository
    {
        private readonly string _connectionString;

        public KategoriRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<Kategori>> GetAllAsync()
        {
            using var connection = new NpgsqlConnection(_connectionString);
            var query = "SELECT * FROM Kategori";
            return await connection.QueryAsync<Kategori>(query);
        }

        public async Task<Kategori> GetKategoriByIdAsync(int id)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            var query = "SELECT * FROM Kategori WHERE Kategori_ID = @id";
            var kategori = await connection.QuerySingleOrDefaultAsync<Kategori>(query, new { id });

            return kategori;
        }

        public async Task<int> AddAsync(Kategori kategori)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            var query = "INSERT INTO Kategori (KategoriAdi) VALUES (@KategoriAdi)";
            return await connection.ExecuteAsync(query, kategori);
        }

        public async Task<int> UpdateAsync(Kategori kategori)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            var query = "UPDATE Kategori SET KategoriAdi = @KategoriAdi WHERE Kategori_ID = @Kategori_ID";
            return await connection.ExecuteAsync(query, kategori);
        }

        public async Task<int> DeleteAsync(int id)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            var query = "DELETE FROM Kategori WHERE Kategori_ID = @id";
            return await connection.ExecuteAsync(query, new { id });
        }
    }

}
