using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using ExampleMVCnoDatabase.Domain;
using ExampleMVCnoDatabase.Persistence;

namespace ExampleMVCnoDatabase.Persistence.Manages
{
    internal class PeopleManage
    {
        public DataTable table { get; set; }
        public List<People> listPeople { get; set; }


        public PeopleManage()
        {
            table=new DataTable();
            listPeople=new List<People>();
        }

        public void readPeople()
        {
            //listPeople.Add(new People("Neil",42));
            //listPeople.Add(new People("Jimi", 20));
            //listPeople.Add(new People("Valverde", 19));
            List<Object> lPeople;
            lPeople = DBBroker.obtenerAgente().leer("select * from people order by idPeople");
            People people = null;
            foreach(List<Object> aux in lPeople)
            {
                people = new People(Int32.Parse(aux[0].ToString()));
                people.name = aux[1].ToString();
                people.age = Int32.Parse(aux[2].ToString());
                this.listPeople.Add(people);
            }
        }
        public void insertPeople(People p)
        {
            DBBroker dBbroker=DBBroker.obtenerAgente();
            dBbroker.modificar("Insert into people (name,age) values ('"+p.name+"' , '"+p.age+"')");
        }

        public void lastId(People p)
        {
            List<Object> lPeople;
            lPeople = DBBroker.obtenerAgente().leer("select MAX(idPeople) from people");
            foreach (List<Object> aux in lPeople)
            {
                p.Id = Convert.ToInt32(aux[0]);
            }
        }
        public void delete(People p)
        {
            List<Object> lPeople;
            DBBroker dBbroker = DBBroker.obtenerAgente();

            dBbroker.modificar("delete from people where idPeople=" + p.Id);
        }
    }
}
