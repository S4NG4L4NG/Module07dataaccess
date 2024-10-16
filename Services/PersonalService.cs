using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Module07dataaccess.Model;
using MySql.Data.MySqlClient;

namespace Module07dataaccess.Services
{
    public class PersonalService
    {
        public readonly string _connectionString;

        public PersonalService()
            {
            var dbService = new DataBaseConnectionService();
            _connectionString = dbService.GetConnectionString();
            }

        public async Task<List<Personal>>GetAllPersonalsAsync()
        {
            var personalService = new List<Personal>();
            using (var conn = new MySqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                var cmd = new MySqlCommand("SELECT * FROM tblemployee", conn);

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while(await reader.ReadAsync())
                    {
                        personalService.Add(new Personal
                        {
                            //ID = reader.GetInt32("ID"),
                            //NAME = reader.GetString("NAME"),
                            //Gender = reader.GetString("Gender"),
                            //ContactNo = reader.GetString("ContactNo")
                            EmployeeID = reader.GetInt32("EmployeeID"),
                            Name = reader.GetString("Name"),
                            Address = reader.GetString("Address"),
                            email = reader.GetString("email"),
                            ContactNo = reader.GetString("ContactNo"),

                        });
                    }
                }
            }
            return personalService;
        }
    }
}

