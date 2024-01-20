using Comunity_Proyect.Domain;
using ExampleMVCnoDatabase.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace Comunity_Proyect.Persistence.Manage
{
    internal class PisoManage
    {
        public List<Piso> listPisos { get; set; }

        public PisoManage(List<Piso> listPisos)
        {
            this.listPisos = listPisos;
        }
        public PisoManage()
        {
            listPisos = new List<Piso>();
        }
        public void readPisos()
        {
            List<Object> lPisos;
            lPisos = DBBroker.obtenerAgente().leer("select * from pisos order by idPisos");
            Piso p = null;
            foreach (List<Object> aux in lPisos)
            {
                p = new Piso(Int32.Parse(aux[0].ToString()));
                p.portal = Int32.Parse(aux[2].ToString());
                p.stair = Int32.Parse(aux[3].ToString());
                p.high = Int32.Parse(aux[4].ToString());
                p.letter = aux[5].ToString()[0];
                p.parking = Int32.Parse(aux[6].ToString());
                p.storageroom = Int32.Parse(aux[7].ToString());
                this.listPisos.Add(p);
            }
        }
        public void insertPiso(Piso p)
        {
            DBBroker dBbroker = DBBroker.obtenerAgente();
            dBbroker.modificar("Insert into pisos (entrance,stair,high,letter,parking,storage) values ("+ p.portal + " , " + p.stair + " , " + p.high +" , '" +p.letter+"' , "+p.parking+","+p.storageroom+ ")");
        }
        public void insertPisos()
        {
            foreach (Piso p in this.listPisos)
            {
               insertPiso(p);
            }
        }
        public Piso generarPiso(int portal, int stair, int high, char letter)
        {
            Piso p = new Piso(portal,stair, high, letter);
            this.listPisos.Add(p);
            return p;
        }
        public void generarPisosPorPortal(Portal p)
        {
            int numletras = p.finalLetter - p.initialLetter;
            char letra = p.initialLetter;
            for (int i = 1; i <= p.stairs; i++)
            {
                for (int j = 1; j <= p.highs; j++)
                {
                    for (int k = 0; k <= numletras; k++)
                    {
                        Piso piso = new Piso((p.numeroPortal), i, j, (char)(letra + k));
                        this.listPisos.Add(piso);

                    }
                }
            }
        }

        public void reparteParking()
        {
            int numeroPlazas = this.listPisos.Count();
            Random random = new Random();
            List<int> plazasEntregadas = new List<int>();
            int num;
            foreach(Piso p in listPisos)
            {
                num = random.Next(1, numeroPlazas+1);
                while (plazasEntregadas.Contains(num))
                {
                    num = random.Next(1, numeroPlazas + 1);
                }
                p.parking = num;
                plazasEntregadas.Add(num);
            }
        }
        public void reparteAlmacen()
        {
            int numeroAlmacen = this.listPisos.Count();
            Random random = new Random();
            List<int> almacenesEntregadas = new List<int>();
            int num;
            foreach (Piso p in listPisos)
            {
                num = random.Next(1, numeroAlmacen+1);
                while (almacenesEntregadas.Contains(num))
                {
                    num = random.Next(1, numeroAlmacen+1);
                }
                p.storageroom= num;
                almacenesEntregadas.Add(num);
            }
        }
    }
}
    