using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunity_Proyect.Domain
{
    
    internal class Propietario
    {
        public int Id { get; set; }
        public String name { set; get; }
        public String dni { set; get; }
        public String surnames { set; get; }
        public String dir_res { set; get; }
        public String city { set; get; }
        public String cp { set; get; } 
        public String province { set; get; }

        public Propietario(string name, string dni, string surnames, string dir_res, string city, string cp, string province)
        {
            this.name = name;
            this.dni = dni;
            this.surnames = surnames;
            this.dir_res = dir_res;
            this.city = city;
            this.cp = cp;
            this.province = province;
        }
        public Propietario() { }
        public Propietario(int Id)
        {
            this.Id = Id;
        }

        public override bool Equals(object? obj)
        {
            return obj is Propietario propietario &&
                   name == propietario.name &&
                   dni == propietario.dni &&
                   surnames == propietario.surnames &&
                   dir_res == propietario.dir_res &&
                   city == propietario.city &&
                   cp == propietario.cp &&
                   province == propietario.province;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(name, dni, surnames, dir_res, city, cp, province);
        }
    }
}
