using Comunity_Proyect.Domain;
using ExampleMVCnoDatabase.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunity_Proyect.Persistence.Manage
{
    internal class ComunidadManage
    {
        public ComunidadManage() { }
        public void insertComunidad(Comunidad d)
        {
            DBBroker dBbroker = DBBroker.obtenerAgente();
            dBbroker.modificar("Insert into comunidades (name,address,fundation,leasable,entrances) values (" + d.name + " , " + d.address + " , " + d.fundation + " , '" + d.leasable+ "' , " + d.entrances + ")");
        }
    }
}
