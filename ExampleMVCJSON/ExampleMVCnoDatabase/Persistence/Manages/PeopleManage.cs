using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using ExampleMVCnoDatabase.Domain;
using ExampleMVCnoDatabase.Persistence;
using Newtonsoft.Json;

namespace ExampleMVCnoDatabase.Persistence.Manages
{
    internal class PeopleManage
    {
        public List<People> listPeople { get; set; }

        private string ruta;
        public PeopleManage()
        {
            listPeople=new List<People>();
            ruta = "C:\\DAM\\DAM2\\DI\\T4\\sample4.json";
        }

        public void readPeople()
        {
            string contenidoJson = File.ReadAllText(ruta);
            RootObject rootObject = JsonConvert.DeserializeObject<RootObject>(contenidoJson);
            listPeople = rootObject.People;
        }

        public void readPeople(int id)
        {
            
        }

        public void insertPeople(People p)
        {
            listPeople.Add(p);
            RootObject rootObject = new RootObject();
            rootObject.People = listPeople;
            string contenidoJson = JsonConvert.SerializeObject(rootObject, Formatting.Indented);
            File.WriteAllText("C:\\DAM\\DAM2\\DI\\T4\\sample4.json", contenidoJson);
        }

        public void last(People p)
        {
           p.ID = MaxId() + 1;
        }

        public void delete(People p)
        {
            RemoveById(p);
            RootObject rootObject = new RootObject();
            rootObject.People = listPeople;
            string contenidoJson = JsonConvert.SerializeObject(rootObject, Formatting.Indented);
            File.WriteAllText("C:\\DAM\\DAM2\\DI\\T4\\sample4.json", contenidoJson);
        }

        public bool updatePeople(People p)
        {
            if (RemoveById(p))
            {
                insertPeople(p);
                return true;
            }
            else
            {
                return false;
            }
        }

        class RootObject
        {
            [JsonProperty("people")]
            public List<People> People { get; set; }
        }



        private bool RemoveById(People p)
        {
            foreach (People people in listPeople)
            {
                if (people.ID == p.ID)
                {
                    listPeople.Remove(people);
                    return true;
                }
            }
            return false;
        }

        private int MaxId()
        {
            int max = 0;
            foreach (People people in listPeople)
            {
                if (people.ID > max)
                {
                    max = people.ID;
                }
            }
            return max;
        }
    }
}
