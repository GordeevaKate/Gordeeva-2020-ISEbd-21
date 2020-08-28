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
        public List<Client> Clients { get; set; }
        public List<Implementer> Implementers { get; set; }
        public List<MessageInfo> MessageInfoes { get; set; }
        private DataListSingleton()
        {

            Seafoods = new List<Seafood>();
            Orders = new List<Order>();
            Sushis = new List<Sushi>();
            SushiSeafoods = new List<SushiSeafood>();
            Clients = new List<Client>();
            Implementers = new List<Implementer>();
            MessageInfoes = new List<MessageInfo>();
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
