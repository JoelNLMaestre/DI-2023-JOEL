using Community.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Community.Persistence
{
    internal class PropietarioManage
    {
        private string[] nombres = {
            "Antonio", "Manuel", "José", "Francisco", "David",
            "Juan", "Javier", "José Antonio", "José Manuel", "Francisco Javier",
            "Francisco José", "Jesús", "Ángel", "Miguel Ángel", "Pedro",
            "Juan José", "Rafael", "Miguel", "José María", "Fernando",
            "Luis", "Alberto", "Enrique", "Diego", "Carlos",
            "Ricardo", "Víctor", "Sergio", "Rubén", "Ignacio",
            "Adrián", "Jorge", "Alejandro", "Raúl", "Félix",
            "Pablo", "Alvaro", "Mario", "Ismael", "Julio",
            "Manuel Jesús", "Emilio", "Gonzalo", "Roberto", "Eduardo",
            "Óscar", "Daniel", "Jaime", "Héctor", "Nicolás"
        };
        string[] apellidos = {
            "García", "Fernández", "López", "Martínez", "Sánchez",
            "Pérez", "González", "Rodríguez", "López", "Martín",
            "Gómez", "Jiménez", "Ruiz", "Hernández", "Díaz",
            "Moreno", "Álvarez", "Romero", "Navarro", "Torres",
            "Domínguez", "Vázquez", "Ramos", "Cortés", "Castro",
            "Serrano", "Ortega", "Fuentes", "Núñez", "Reyes",
            "Molina", "Iglesias", "Santos", "Giménez", "Ortiz",
            "Rubio", "Morales", "Ramírez", "Marín", "Aguilar",
            "Carrasco", "Herrera", "Montero", "Cabrera", "Méndez",
            "León", "Gálvez", "Vidal", "Moya"
        };
        Random rnd = new Random();
        public List<Propietario> propietarioList { get; set; }
        public PropietarioManage()
        {
            this.propietarioList = new List<Propietario>();
        }
        public void readPropietarios()
        {
            List<Object> lPropietarios;
            lPropietarios = DBBroker.obtenerAgente().leer("select * from propietarios order by idPropietarios");
            Propietario p = null;
            foreach (List<Object> aux in lPropietarios)
            {
                p = new Propietario(Int32.Parse(aux[0].ToString()));
                p.name = aux[1].ToString();
                p.surnames = aux[2].ToString();
                p.dir_res = aux[3].ToString();
                p.city = aux[4].ToString();
                p.cp = Int32.Parse(aux[5].ToString());
                p.province = aux[6].ToString();
                p.dni = aux[7].ToString();
                this.propietarioList.Add(p);
            }
        }
        public void insertPropietario(Propietario p)
        {
            DBBroker dBbroker = DBBroker.obtenerAgente();
            dBbroker.modificar("Insert into propietarios (name,surname,address,city,cp,province,dni) values ('" + p.name + "' , '" + p.surnames + "' , '" + p.dir_res + "' , '" + p.city + "' , " + p.cp + ",'" + p.province + "','" + p.dni + "')");
        }
        public void insertPropietarios()
        {
            foreach (Propietario p in this.propietarioList)
            {
                insertPropietario(p);
            }
        }
        public void generarPropietario()
        {
            Propietario p = new Propietario(nombres[rnd.Next(0, 49)], GenerarDNI(), apellidos[rnd.Next(0, 49)], "Altagracia", "Ciudad real", 13002, "Ciudad Real");
            this.propietarioList.Add(p);
        }
        public void generarPropietariosPorPortal(Portal p)
        {
            Random rnd = new Random();
            int propi;
            int numletras = p.finalLetter - p.initialLetter;
            char letra = p.initialLetter;
            for (int i = 1; i <= p.stairs; i++)
            {
                for (int j = 1; j <= p.highs; j++)
                {
                    for (int k = 0; k <= numletras; k++)
                    {
                        propi = rnd.Next(1, 3);
                        for (int l = 1; l <= propi; l++)
                        {
                            generarPropietario();
                        }
                    }
                }
            }
        }
        static string GenerarDNI()
        {
            Random random = new Random();

            // Generar un número aleatorio de 8 dígitos para el número del DNI
            int numeroDNI = random.Next(10000000, 99999999);

            // Calcular la letra del DNI usando el algoritmo de módulo 23
            char letraDNI = CalcularLetraDNI(numeroDNI);

            // Formatear el DNI completo
            string dniCompleto = $"{numeroDNI}{letraDNI}";

            return dniCompleto;
        }

        static char CalcularLetraDNI(int numeroDNI)
        {
            // Array con las letras del DNI en orden
            char[] letrasDNI = { 'T', 'R', 'W', 'A', 'G', 'M', 'Y', 'F', 'P', 'D', 'X', 'B', 'N', 'J', 'Z', 'S', 'Q', 'V', 'H', 'L', 'C', 'K', 'E' };

            // Calcular la letra usando el módulo 23
            int indiceLetra = numeroDNI % 23;

            return letrasDNI[indiceLetra];
        }

        public DataTable getPropietarios()
        {
            List<Object> col = DBBroker.obtenerAgente().leer("select * from Propietarios order by idPropietarios");
            DataTable dt = new DataTable();
            DataColumn c1 = new DataColumn("name");
            DataColumn c2 = new DataColumn("surname");
            dt.Columns.Add(c1);
            dt.Columns.Add(c2);

            DataRow row = null;
            foreach (List<Object> aux in col)
            {
                row = dt.NewRow();
                row[0] = aux[1];
                row[1] = aux[2];
                dt.Rows.Add(row);
            }

            return dt;
        }
    }
}
