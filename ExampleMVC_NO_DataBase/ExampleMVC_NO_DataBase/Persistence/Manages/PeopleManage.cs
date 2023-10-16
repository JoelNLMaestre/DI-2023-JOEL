using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExampleMVC_NO_DataBase.Domain;

namespace ExampleMVC_NO_DataBase.Persistence.Manages
{
    internal class PeopleManage
    {
        private DataTable table;
        List<People> listPeople;


        public PeopleManage()
        {
            table = new DataTable();
        }

        public DataTable Table { get => table; set => table = value; }
        internal List<People> ListPeople { get => listPeople; set => listPeople = value; }

        public void readPeople()
        {
            listPeople.Add(new People("Neil", 42));
            listPeople.Add(new People("Jimi", 20));
            listPeople.Add(new People("Yara", 34));
        }
    }
}
