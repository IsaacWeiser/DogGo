using DogGo.Models;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using DogGo.Repositories;
using DogGo.Controllers;

namespace DogGo.Repositories
{
    public interface IWalkerRepository
    {

        List<Walker> GetAllWalkers();
        Walker GetWalkerById(int id);
        List<Walker> GetWalkersInNeighborhood(int neighborhoodId);
    }
}