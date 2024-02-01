using CrystalView.Persistence.Manage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrystalView.Domain
{
    internal class People
    {
        public int Id { get; set; }
        public String name { get; set; }
        public int age { get; set; }
        public PeopleManage pm { get; set; }

        public People()
        {
            pm = new PeopleManage();
        }

        public People(int id)
        {
            pm = new PeopleManage();
            this.Id = id;
        }
        public People(string name, int age)
        {
            this.name = name;
            this.age = age;
            pm = new PeopleManage();
        }

        public void readP()
        {
            pm.readPeople();
        }

        public List<People> getListPeople()
        {
            return pm.listPeople;
        }

        public void insert()
        {
            pm.insertPeople(this);
        }

        public void last()
        {
            pm.lastId(this);
        }
        public void delete()
        {
            pm.delete(this);
        }
        public DataTable getP()
        {
            return pm.getPeople();
        }
    }
}
