using Dapper;
using Npgsql;
using RestoranSiparis.Models;

public class UrunlerRepository
{
    private readonly string _connectionString;

    public UrunlerRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<IEnumerable<Urunler>> GetAllAsync()
    {
        using var connection = new NpgsqlConnection(_connectionString);
        var query = "SELECT * FROM Urunler";
        return await connection.QueryAsync<Urunler>(query);
    }

    public async Task<Urunler> GetByIdAsync(int id)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        var query = "SELECT * FROM Urunler WHERE Urun_ID = @id";
        return await connection.QueryFirstOrDefaultAsync<Urunler>(query, new { id });
    }

    public async Task AddAsync(Urunler urun)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        var query = "INSERT INTO Urunler (Kategori_ID, Ad, Fiyat) VALUES (@Kategori_ID, @Ad, @Fiyat)";
        await connection.ExecuteAsync(query, urun);
    }

    public async Task UpdateAsync(Urunler urun)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        var query = "UPDATE Urunler SET Kategori_ID = @Kategori_ID, Ad = @Ad, Fiyat = @Fiyat WHERE Urun_ID = @Urun_ID";
        await connection.ExecuteAsync(query, urun);
    }
  
    public async Task DeleteAsync(int id)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        var query = "DELETE FROM Urunler WHERE Urun_ID = @id";
        await connection.ExecuteAsync(query, new { id });
    }
}
