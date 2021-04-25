using EasterRaces.Repositories.Contracts;
using EasterRaces.Models.Cars.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    public class CarRepository : IRepository<ICar>
    {
        private readonly List<ICar> models;

        public CarRepository()
        {
            this.models = new List<ICar>();
        }

        public IReadOnlyCollection<ICar> Models => this.models.AsReadOnly();

        public void Add(ICar model)
        {
            this.models.Add(model);
        }

        public IReadOnlyCollection<ICar> GetAll()
        {
            return this.Models;
        }

        public ICar GetByName(string name)
        {
            ICar car = this.models.FirstOrDefault(x => x.Model == name);

            return car;
        }

        public bool Remove(ICar model)
        {
            return this.models.Remove(model);
        }
    }
}
