using ExampleMVC_NO_DataBase.Persistence.Manages;
using System;
using System.Windows.Controls;
using System.Xml.Linq;
using System.Collections.Generic;

namespace ExampleMVC_NO_DataBase.Domain
{
    public class People
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public PeopleManage pm { get; set; }

        public People()
        {
            pm = new PeopleManage();
        }


        public People(string name, int age)
        {
            this.Name = name;
            this.Age = age;
            pm = new PeopleManage();
        }
        public People(string name)
        {
            this.Name = name;
            this.Age = 15;
            pm = new PeopleManage();
        }

        public void readP()
        {
            pm.readPeople();
        }

        public List<People> GetList()
        {
            return pm.listPeople;
        }
        public void addList(People people)
        {
            pm.listPeople.Add(people);
        }
    }
}
