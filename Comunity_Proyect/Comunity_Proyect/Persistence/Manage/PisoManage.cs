using Comunity_Proyect.Domain;
using ExampleMVCnoDatabase.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunity_Proyect.Persistence.Manage
{
    internal class PisoManage
    {
        public List<Piso> listPisos { get; set; }

        public PisoManage(List<Piso> listPisos)
        {
            this.listPisos = listPisos;
        }
        public PisoManage()
        {
            
        }
        public void insertPiso(Piso p)
        {
            DBBroker dBbroker = DBBroker.obtenerAgente();
            dBbroker.modificar("Insert into pisos (entrance,stair,high,letter,parking,storage) values ("+ p.portal + " , " + p.stair + " , " + p.high +" , '" +p.letter+"' , "+1+","+2+ ")");
        }
    }
}
    