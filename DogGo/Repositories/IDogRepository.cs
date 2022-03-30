using DogGo.Models;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using DogGo.Repositories;
using DogGo.Controllers;

namespace DogGo.Repositories
{
    public interface IDogRepository
    {

        List<Dog> GetAllDogs();
        Dog GetDogById(int id);

        public void AddDog(Dog dog);

        public void UpdateDog(Dog dog);

        public void DeleteDog(int id);

    }
}
