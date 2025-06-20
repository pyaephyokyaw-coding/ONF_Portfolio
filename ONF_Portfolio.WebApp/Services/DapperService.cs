using Dapper;
using Microsoft.Data.SqlClient;
using ONF_Portfolio.WebApp.Models;

namespace ONF_Portfolio.WebApp.Services;

public class DapperService
{
    private readonly IConfiguration _configuration;
    private readonly string _dbConnection;
    public DapperService(IConfiguration configuration)
    {
        _configuration = configuration;
        _dbConnection = _configuration.GetConnectionString("DefaultConnection");
    }

    public async Task<IEnumerable<ProjectsModel>> GetProjectsAsync()
    {
        using var conn = new SqlConnection(_dbConnection);
        return await conn.QueryAsync<ProjectsModel>("SELECT * FROM Projects");
    }
}
