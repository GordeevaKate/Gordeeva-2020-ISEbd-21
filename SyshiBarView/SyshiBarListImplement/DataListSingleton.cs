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
        public List<Storage> Storages { get; set; }
        public List<StorageSeafood> StorageSeafoods { get; set; }
        private DataListSingleton()
        {

            Seafoods = new List<Seafood>();
            Orders = new List<Order>();
            Sushis = new List<Sushi>();
            SushiSeafoods = new List<SushiSeafood>();
            Storages = new List<Storage>();
            StorageSeafoods = new List<StorageSeafood>();
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
