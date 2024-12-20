﻿using Dapper;
using Npgsql;
using RestoranSiparis.Models;

namespace RestoranSiparis.Repositories
{
    public class MutfakPersoneliRepository
    {
        private readonly string _connectionString;

        public MutfakPersoneliRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<MutfakPersoneli>> GetAllAsync()
        {
            using var connection = new NpgsqlConnection(_connectionString);
            var query = "SELECT * FROM MutfakPersoneli";
            return await connection.QueryAsync<MutfakPersoneli>(query);
        }

        public async Task<MutfakPersoneli> GetMutfakPersoneliByIdAsync(int id)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            var query = "SELECT * FROM MutfakPersoneli WHERE mutfakp_id = @id";
            return await connection.QueryFirstOrDefaultAsync<MutfakPersoneli>(query, new { id });
        }

        public async Task<int> AddAsync(MutfakPersoneli personel)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            var query = "INSERT INTO MutfakPersoneli (Ad, Soyad) VALUES (@Ad, @Soyad)";
            return await connection.ExecuteAsync(query, personel);
        }

        public async Task<int> UpdateAsync(MutfakPersoneli personel)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            var query = "UPDATE MutfakPersoneli SET Ad = @Ad, Soyad = @Soyad WHERE mutfakp_id = @mutfakp_id";
            return await connection.ExecuteAsync(query, personel);
        }

        public async Task<int> DeleteAsync(int id)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            var query = "DELETE FROM MutfakPersoneli WHERE mutfakp_id = @id";
            return await connection.ExecuteAsync(query, new { id });
        }
    }
}
