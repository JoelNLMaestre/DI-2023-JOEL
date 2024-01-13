using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExampleMVCnoDatabase.Persistence.Manages;
using Newtonsoft.Json;

namespace ExampleMVCnoDatabase.Domain
{
    internal class People
    {
        public int ID { get; set; }
        public String name { get; set; }
        public int age { get; set; }

        [JsonIgnore]
        public PeopleManage pm { get; set; }

        public People() {
            pm = new PeopleManage();
        }

        public People(string name, int age)
        {
            this.name = name;
            this.age = age;
            pm = new PeopleManage();
        }

        public People(int id)
        {
            this.ID = id;
            pm = new PeopleManage();
        }

        public void readP()
        {
            pm.readPeople();
        }

        public List<People> getListPeople(){
            return pm.listPeople;
        }

        public void insert()
        {
            pm.insertPeople(this);
        }

        public void last()
        {
            pm.last(this);
        }

        public void delete()
        {
            pm.delete(this);
        }

        public void update()
        {
            pm.updatePeople(this);
        }
    }
}
