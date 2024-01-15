using Comunity_Proyect.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunity_Proyect.Persistence.Manage
{
    internal class PropietarioManage
    {
        public List<Propietario> propietarioList { get; set; }
        public PropietarioManage() { 
            propietarioList = new List<Propietario>();
        }

    }
}
