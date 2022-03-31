using System;
using System.Collections.Generic;
using DogGo.Models;
using DogGo.Controllers;
using DogGo;

namespace DogGo.Repositories
{
    public interface IWalkRepository
    {
        public List<Walk> GetAllWalksByWalkerId(int id);

        public List<Owner> GetAllClientsByWalkerId(int id);
    }
}
