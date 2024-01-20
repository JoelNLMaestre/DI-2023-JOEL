using Comunity_Proyect.Persistence.Manage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunity_Proyect.Domain
{
    internal class Comunidad
    {
        public String name { get; set; }
        public String address { get; set; }
        public String fundation { get; set; }
        public int leasable { get; set; }
        public bool pool { get; set; }
        public int entrances { get; set; }

        public ComunidadManage cm { get; set; }

        public Comunidad(string name, string address, String fundation, int leasable, bool pool, int entrances)
        {
            this.name = name;
            this.address = address;
            this.fundation = fundation;
            this.leasable = leasable;
            this.pool = pool;
            this.entrances = entrances;
            this.cm = new ComunidadManage();
        }

        public Comunidad()
        {
            this.cm = new ComunidadManage();
        }

        public override bool Equals(object? obj)
        {
            return obj is Comunidad comunidad &&
                   name == comunidad.name &&
                   address == comunidad.address &&
                   fundation == comunidad.fundation &&
                   leasable == comunidad.leasable &&
                   pool == comunidad.pool &&
                   entrances == comunidad.entrances;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(name, address, fundation, leasable, pool, entrances);
        }
    }
}
