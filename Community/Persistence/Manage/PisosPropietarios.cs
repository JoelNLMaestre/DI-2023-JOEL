using Community.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Community.Persistence
{
    internal class PisosPropietarios
    {
        public int limitePisos { get; set; }
        public int limitePropietarios { get; set; }
        public List<int> pisos { get; set; }


        public PisosPropietarios(int limitePisos, int limitePropietarios)
        {
            this.limitePisos = limitePisos;
            this.limitePropietarios = limitePropietarios;
        }
        public void enlazarPisosYPorpietarios()
        {
            int numeroPiso;
            int numeroPropietario;
            Random rnd = new Random();
            int[] pisosOcupados = new int[limitePisos];
            for (int i = 0; i < limitePisos; i++)
            {
                pisosOcupados[i] = 0;
            }
            int[] propietariosDisponibles = new int[limitePropietarios];
            for (int i = 1; i <= propietariosDisponibles.Length; i++)
            {
                numeroPiso = rnd.Next(0, limitePisos);
                if (pisosOcupados[numeroPiso] < 4)
                {

                    DBBroker dBbroker = DBBroker.obtenerAgente();
                    dBbroker.modificar("Insert into pisos_propietarios (idPisos,idPropietarios) values (" + (numeroPiso + 1) + " , " + i + ")");
                    pisosOcupados[numeroPiso]++;
                }
            }
            for (int i = 0; i < limitePisos; i++)
            {
                if (pisosOcupados[i] == 0)
                {
                    DBBroker dBbroker = DBBroker.obtenerAgente();
                    dBbroker.modificar("Insert into pisos_propietarios (idPisos,idPropietarios) values (" + (i + 1) + " , " + 1 + ")");
                }
            }
        }
        public void generapisos()
        {
            for (int i = 1; i <= limitePisos; i++)
            {
                this.pisos.Add(i);
            }
        }
    }
}
