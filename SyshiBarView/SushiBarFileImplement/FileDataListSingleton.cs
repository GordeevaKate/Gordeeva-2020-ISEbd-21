﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;
using SushiBarFileImplement.Models;
namespace SushiBarFileImplement
{
    public class FileDataListSingleton
    {
        private static FileDataListSingleton instance;
        private readonly string SeafoodFileName = "Seafood.xml";
        private readonly string OrderFileName = "Order.xml";
        private readonly string SushiFileName = "Sushi.xml";
        private readonly string SushiSeafoodFileName = "SushiSeafood.xml";
        public List<Seafood> Seafoods { get; set; }
        public List<Order> Orders { get; set; }
        public List<Sushi> Sushis { get; set; }
        public List<SushiSeafood> SushiSeafoods { get; set; }
        private FileDataListSingleton()
        {
            Seafoods = LoadSeafoods();
            Orders = LoadOrders();
            Sushis = LoadSushis();
            SushiSeafoods = LoadSushiSeafoods();
        }
        public static FileDataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new FileDataListSingleton();
            }
            return instance;
        }
        ~FileDataListSingleton()
        {
            SaveSeafoods();
            SaveOrders();
            SaveSushis();
            SaveSushiSeafoods();
          
        }
        private List<Seafood> LoadSeafoods()
        {
            var list = new List<Seafood>();
            if (File.Exists(SeafoodFileName))
            {
                XDocument xDocument = XDocument.Load(SeafoodFileName);
                var xElements = xDocument.Root.Elements("Seafood").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Seafood
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        SeafoodName = elem.Element("SeafoodName").Value
                    });
                }
            }
            return list;
        }
        private List<Order> LoadOrders()
        {
            var list = new List<Order>();
            if (File.Exists(OrderFileName))
            {
                XDocument xDocument = XDocument.Load(OrderFileName);
                var xElements = xDocument.Root.Elements("Order").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Order
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        SushiId = Convert.ToInt32(elem.Element("SushiId").Value),
                        Count = Convert.ToInt32(elem.Element("Count").Value),
                        Sum = Convert.ToDecimal(elem.Element("Sum").Value),
                        Status = (OrderStatus)Enum.Parse(typeof(OrderStatus),
                   elem.Element("Status").Value),
                        DateCreate =
                   Convert.ToDateTime(elem.Element("DateCreate").Value),
                        DateImplement =
                   string.IsNullOrEmpty(elem.Element("DateImplement").Value) ? (DateTime?)null :
                   Convert.ToDateTime(elem.Element("DateImplement").Value),
                    });
                }
            }
            return list;
        }
        private List<Sushi> LoadSushis()
        {
            var list = new List<Sushi>();
            if (File.Exists(SushiFileName))
            {
                XDocument xDocument = XDocument.Load(SushiFileName);
                
            var xElements = xDocument.Root.Elements("Sushi").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Sushi
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        SushiName = elem.Element("SushiName").Value,
                        Price = Convert.ToDecimal(elem.Element("Price").Value)
                    });
                }
            }
            return list;
        }
        private List<SushiSeafood> LoadSushiSeafoods()
        {
            var list = new List<SushiSeafood>();
            if (File.Exists(SushiSeafoodFileName))
            {
                XDocument xDocument = XDocument.Load(SushiSeafoodFileName);
                var xElements = xDocument.Root.Elements("SushiSeafood").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new SushiSeafood
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        SushiId = Convert.ToInt32(elem.Element("SushiId").Value),
                        SeafoodId = Convert.ToInt32(elem.Element("SeafoodId").Value),
                        Count = Convert.ToInt32(elem.Element("Count").Value)
                    });
                }
            }
            return list;
        }
        private void SaveSeafoods()
        {
            if (Seafoods != null)
            {
                var xElement = new XElement("Seafoods");
                foreach (var seafood in Seafoods)
                {
                    xElement.Add(new XElement("Seafood",
                    new XAttribute("Id", seafood.Id),
                    new XElement("SeafoodName", seafood.SeafoodName)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(SeafoodFileName);
            }
        }
        private void SaveOrders()
        {
            if (Orders != null)
            {

            var xElement = new XElement("Orders");
                foreach (var order in Orders)
                {
                    xElement.Add(new XElement("Order",
                    new XAttribute("Id", order.Id),
                    new XElement("SushiId", order.SushiId),
                    new XElement("Count", order.Count),
                    new XElement("Sum", order.Sum),
                    new XElement("Status", order.Status),
                    new XElement("DateCreate", order.DateCreate),
                    new XElement("DateImplement", order.DateImplement)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(OrderFileName);
            }
        }
        private void SaveSushis()
        {
            if (Sushis != null)
            {
                var xElement = new XElement("Sushis");
                foreach (var sushi in Sushis)
                {
                    xElement.Add(new XElement("Sushi",
                    new XAttribute("Id", sushi.Id),
                    new XElement("SushiName", sushi.SushiName),
                    new XElement("Price", sushi.Price)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(SushiFileName);
            }
        }
        private void SaveSushiSeafoods()
        {
            if (SushiSeafoods != null)
            {
                var xElement = new XElement("SushiSeafoods");
                foreach (var sushiSeafood in SushiSeafoods)
                {
                    xElement.Add(new XElement("SushiSeafood",
                    new XAttribute("Id", sushiSeafood.Id),
                    new XElement("SushiId", sushiSeafood.SushiId),
                    new XElement("SeafoodId", sushiSeafood.SeafoodId),
                    new XElement("Count", sushiSeafood.Count)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(SushiSeafoodFileName);
            }
        }
    }
}
