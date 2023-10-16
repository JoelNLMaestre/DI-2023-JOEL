using ExampleMVC_NO_DataBase.Persistence.Manages;
using System;

namespace ExampleMVC_NO_DataBase.Domain
{
    internal class People
    {
        private String name;
        private int age;
        private PeopleManage pm;

        public People(string name, int age)
        {
            this.name = name;
            this.Age = age;
            pm = new PeopleManage();
        }

        public string Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }
    }
}
