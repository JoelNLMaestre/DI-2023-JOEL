using Comunity_Proyect.Domain;
using ExampleMVCnoDatabase.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunity_Proyect.Persistence.Manage
{
    internal class PropietarioManage
    {
        private String[] nombres = {"Lucia","Sofia","Martina","Valeria","Maria","Martin","Mateo","Hugo","Alejandro","Pablo"};
        private String[] apellidos = { "Gonzalez", "Rodrigez", "Fernandez", "Lopez", "Garcia", "Martinez", "Sanchez", "Perez", "Martin", "Gomez"};
        Random rnd = new Random();
        public List<Propietario> propietarioList { get; set; }
        public PropietarioManage() { 
            propietarioList = new List<Propietario>();
        }
        public void insertPiso(Propietario p)
        {
            DBBroker dBbroker = DBBroker.obtenerAgente();
            dBbroker.modificar("Insert into pisos (name,surnmae,address,city,cp,province) values (" + p.name + " , " + p.surnames + " , " + p.dir_res + " , '" + p.city + "' , '" + p.cp + "','" + p.province + "')");
        }
        public void generarPropietarios(int num)
        {
            for (int i = 0; i < num; i++)
            {
                propietarioList.Add(new Propietario(nombres[rnd.Next(1, 11)], i.ToString(), apellidos[rnd.Next(1, 11)], "Altagracia", "Ciudad real", "13002", "Ciudad Real"));
            }
        }
    }
}
