using System;
using System.Collections.Generic;
using System.Text;
using OdeToFood.Core;
using System.Linq;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
           //IEnumerable<Restaurant> GetAll();
        IEnumerable<Restaurant> GetRestaurantsByName(string name);

    }
    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;
        public InMemoryRestaurantData(){
            restaurants = new List<Restaurant>(){
                new Restaurant{ Id = 1, Name = "Scott's Pizza", Location="Fortaleza", Cuisine=CuisineType.Italian},
                new Restaurant{ Id = 1, Name = "Cinnamon Club", Location="London", Cuisine=CuisineType.Indian},
                new Restaurant{ Id = 1, Name = "La Costa", Location="Mexico", Cuisine=CuisineType.Mexican}
            };
        }
        //public IEnumerable<Restaurant> GetAll()
        //{
        //    return from r in restaurants
        //           orderby r.Name
        //           select r;
        //}

        public IEnumerable<Restaurant> GetRestaurantsByName(string name)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }
    }
}
