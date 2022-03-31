using System.Collections.Generic;
using DogGo.Models;
using DogGo.Controllers;
using DogGo;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace DogGo.Repositories
{
    public class WalkRepository : IWalkRepository
    {

        private readonly IConfiguration _config;

        // The constructor accepts an IConfiguration object as a parameter. This class comes from the ASP.NET framework and is useful for retrieving things out of the appsettings.json file like connection strings.
        public WalkRepository(IConfiguration config)
        {
            _config = config;
        }

        public SqlConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            }
        }

        public List<Walk> GetAllWalksByWalkerId(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT  w.Id, w.Date, w.Duration, w.WalkerId, w.DogId, o.Name
                                        FROM Walks w
                                        JOIN Dog d ON d.Id = w.DogId
                                        JOIN Owner o ON o.Id = d.OwnerId
                                        WHERE WalkerId = @id
                                        ORDER BY o.Name";
                    cmd.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List < Walk > walks = new List<Walk>();

                        while (reader.Read())
                        {
                            Walk walk = new Walk
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Duration = reader.GetInt32(reader.GetOrdinal("Duration")),
                                Date = reader.GetDateTime(reader.GetOrdinal("Date")),
                                WalkerId = reader.GetInt32(reader.GetOrdinal("WalkerId")),
                                DogId = reader.GetInt32(reader.GetOrdinal("DogId"))
                            };

                            walks.Add(walk);

                        }

                        return walks;
                    }


                }

            }
        }

        public List<Owner> GetAllClientsByWalkerId(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT  o.Name as 'Name', o.Id as 'Id' 
                                        FROM Walks w
                                        JOIN Dog d ON d.Id = w.DogId
                                        JOIN Owner o ON o.Id = d.OwnerId
                                        WHERE WalkerId = @id
                                        ORDER BY o.Name";
                    cmd.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<Owner> clients = new List<Owner>();

                        while (reader.Read())
                        {
                            Owner client = new Owner
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Name = reader.GetString(reader.GetOrdinal("Name"))
                            };

                            clients.Add(client);

                        }

                        return clients;
                    }


                }

            }
        }
    }
}
