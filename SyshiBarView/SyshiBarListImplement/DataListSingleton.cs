using SyshiBarListImplement.Models;
using System.Collections.Generic;

namespace SyshiBarListImplement
{
    public class DataListSingleton
    {
        private static DataListSingleton instance;
        public List<Seafood> Seafoods { get; set; }
        public List<Order> Orders { get; set; }
        public List<Sushi> Sushis { get; set; }
        public List<SushiSeafood> SushiSeafoods { get; set; }
        private DataListSingleton()
        {

            Seafoods = new List<Seafood>();
            Orders = new List<Order>();
            Sushis = new List<Sushi>();
            SushiSeafoods = new List<SushiSeafood>();
        }
        public static DataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new DataListSingleton();
            }
            return instance;
        }
    }
}
