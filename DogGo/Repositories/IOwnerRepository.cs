using DogGo.Models;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using DogGo.Repositories;
using DogGo.Controllers;

namespace DogGo.Repositories
{
    public interface IOwnerRepository
    {

        List<Owner> GetAllOwners();
        Owner GetOwnerById(int id);

        public void AddOwner(Owner owner);

        public void UpdateOwner(Owner owner);

        public void DeleteOwner(int id);
    }
}