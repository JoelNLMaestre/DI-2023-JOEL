using Community.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Community.Domain
{
    internal class Comunidad
    {
        public int id { get; set; }
        public String name { get; set; }
        public String address { get; set; }
        public String fundation { get; set; }
        public int leasable { get; set; }
        public String pool { get; set; }
        public int entrances { get; set; }

        public String gateKeeper { get; set; }
        public String showers { get; set; }
        public String play { get; set; }
        public String exercise { get; set; }
        public String meeting { get; set; }

        public String tennis { get; set; }
        public String padel { get; set; }

        public ComunidadManage cm { get; set; }

        public Comunidad(string name, string address, String fundation, int leasable, String pool, int entrances)
        {
            this.name = name;
            this.address = address;
            this.fundation = fundation;
            this.leasable = leasable;
            this.pool = pool;
            this.entrances = entrances;
            this.cm = new ComunidadManage();
            this.gateKeeper = "no";
            this.showers = "no";
            this.play = "no";
            this.exercise = "no";
            this.meeting = "no";
            this.tennis = "no";
            this.padel = "no";
        }

        public Comunidad()
        {
            this.cm = new ComunidadManage();
        }

        public Comunidad(int id)
        {
            this.id = id;
        }

        public override bool Equals(object obj)
        {
            return obj is Comunidad comunidad &&
                   name == comunidad.name &&
                   address == comunidad.address &&
                   fundation == comunidad.fundation &&
                   leasable == comunidad.leasable &&
                   pool == comunidad.pool &&
                   entrances == comunidad.entrances;
        }
    }
}
