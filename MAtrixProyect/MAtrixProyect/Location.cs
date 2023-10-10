using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAtrixProyect
{
    public class Location
    {
        int lat;
        int lon;
        String city;
        public Location(int lat, int lon, String city)
        {
            this.lat = lat;
            this.lon = lon; 
            this.city = city;
        }
        public void setLat(int lat)
        {
            this.lat = lat;
        }
        public void setLon(int lon)
        {
            this.lon = lon;
        }
        public void setCity(String city)
        {
            this.city = city;
        }
        public String getCity()
        {
            return this.city;
        }
        public int getLat()
        {
            return this.lat;
        }
        public int getLon()
        {
            return this.lon;
        }
    }
}
