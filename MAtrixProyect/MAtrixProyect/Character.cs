﻿using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pathfinder;

namespace MAtrixProyect
{
    internal class Character : Interface1
    {
        String name;
        Location city;
        int pdeath;
        Cell cell;
        readonly static String[] CITIES = {"New York","Boston",  "Baltimore", "Atlanta", "Detroit","Dallas","Denver"};
        readonly static String[] NAMES = { "Michelle", "Alexander", "James", "Caroline", "Claire", "Jessica", "Erik","Mike" };
        public Character(String name, Location city)
        {
            this.name = name;
            this.city = city;
            this.pdeath = RandomNumber.random_Number(0,100);
        }
        public void setName(String name)
        {
            this.name = name;
        }
        public void setCity(Location city)
        {
            this.city = city;
        }
        public void setPDeath(int pDeath)
        {
            this.pdeath = pDeath;
        }
        public String getName()
        {
            return this.name;
        }
        public Location getCity()
        {
            return this.city;
        }
        public int getPdeath() { 
            return this.pdeath;
        }
        public void setCell(int x, int y) {
            this.cell.setX(x);
            this.cell.setY(y);
        }
        public Cell getCell()
        {
            return this.cell;
        }

        public void print()
        {
            throw new NotImplementedException();
        }

        public void prompt()
        {
            throw new NotImplementedException();
        }

        public void Generate()
        {
            throw new NotImplementedException();
        }
    }
}
