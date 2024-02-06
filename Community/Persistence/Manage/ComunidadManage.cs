using Community.Domain;
using Community.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Community.Persistence
{
    internal class ComunidadManage
    {
        public List<Comunidad> lista;
        public ComunidadManage()
        {
            lista = new List<Comunidad>();
        }
        public void insertComunidad(Comunidad d)
        {
            DBBroker dBbroker = DBBroker.obtenerAgente();
            dBbroker.modificar("Insert into comunidades (name,address,fundation,leasable,entrances,pool,gateKeeper,showers,play,exercise,meeting,tennis,padel) values ('" + d.name + "' , '" + d.address + "' , '" + d.fundation + "' , " + d.leasable + " , " + d.entrances + ",'" + d.pool + "','" + d.gateKeeper + "','" + d.showers + "','" + d.play + "','" + d.exercise + "','" + d.meeting + "','" + d.tennis + "','" + d.padel + "')");
        }
        public void readComunidad()
        {
            List<Object> lPisos;
            lPisos = DBBroker.obtenerAgente().leer("select * from comunidades order by idCommunity");
            Comunidad p = null;
            foreach (List<Object> aux in lPisos)
            {
                p = new Comunidad(Int32.Parse(aux[0].ToString()));
                p.name = aux[1].ToString();
                p.address = aux[2].ToString();
                p.fundation = aux[3].ToString();
                p.leasable = Int32.Parse(aux[4].ToString());
                p.pool = aux[6].ToString();
                p.entrances = Int32.Parse(aux[5].ToString());
                p.gateKeeper = aux[7].ToString();
                p.showers = aux[8].ToString();
                p.play = aux[9].ToString();
                p.exercise = aux[10].ToString();
                p.meeting = aux[11].ToString();
                p.tennis = aux[12].ToString();
                p.padel = aux[13].ToString();
                this.lista.Add(p);
            }
        }
        public void ModuficarComunidad(Comunidad d)
        {
            DBBroker dBbroker = DBBroker.obtenerAgente();
            dBbroker.modificar("Insert into comunidades (name,address,fundation,leasable,entrances,pool,gateKeeper,showers,play,exercise,meeting,tennis,padel) values ('" + d.name + "' , '" + d.address + "' , '" + d.fundation + "' , " + d.leasable + " , " + d.entrances + ",'" + d.pool + "','" + d.gateKeeper + "','" + d.showers + "','" + d.play + "','" + d.exercise + "','" + d.meeting + "','" + d.tennis + "','" + d.padel + "')");
        }
    }
}
