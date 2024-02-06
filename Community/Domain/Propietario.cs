﻿using Community.Persistence;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Community.Domain
{
    internal class Propietario
    {
        public int Id { get; set; }
        public String name { set; get; }
        public String dni { set; get; }
        public String surnames { set; get; }
        public String dir_res { set; get; }
        public String city { set; get; }
        public int cp { set; get; }
        public String province { set; get; }
        public PropietarioManage pm { set; get; }

        public Propietario(string name, string dni, string surnames, string dir_res, string city, int cp, string province)
        {
            this.name = name;
            this.dni = dni;
            this.surnames = surnames;
            this.dir_res = dir_res;
            this.city = city;
            this.cp = cp;
            this.province = province;
            this.pm = new PropietarioManage();
        }
        public Propietario()
        {
            this.pm = new PropietarioManage();
        }
        public Propietario(int Id)
        {
            this.Id = Id;
            this.pm = new PropietarioManage();
        }

        public override bool Equals(object obj)
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
        public DataTable getPro()
        {
            return pm.getPropietarios();
        }
    }
}