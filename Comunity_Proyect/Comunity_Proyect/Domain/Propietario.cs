using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunity_Proyect.Domain
{
    
    internal class Propietario
    {
        private String name { set; get; }
        private String dni { set; get; }
        private String surnames { set; get; }
        private String dir_res { set; get; }
        private String city { set; get; }
        private String cp { set; get; } 
        private String province { set; get; }

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
