using Dhont_Proyect.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dhont_Proyect.Persistance.Manage
{
    class PartyManage
    {
        public DataTable table { get; set; }
        public List<Party> listParty { get; set; }

        public PartyManage()
        {
            table = new DataTable();
            listParty = new List<Party>();
        }

        public void readParty()
        { // los nombres son inventados cualquier parecido con la realidad es pura coincidencia
            listParty.Add(new Party("P.1","Party 10","Alejandro Serrano"));
            listParty.Add(new Party("P.2", "Party 11", "Alejandro Garcia"));
            listParty.Add(new Party("P.3", "Party 12", "Yara Vellon"));
            listParty.Add(new Party("P.4", "Party 13", "ALberto Zamora"));
            listParty.Add(new Party("P.5", "Party 14", "Joel Navajas"));
            listParty.Add(new Party("P.6", "Party 15", "Jaime ALba"));
            listParty.Add(new Party("P.7", "Party 16", "Silvia Gonzalez"));
            listParty.Add(new Party("P.8", "Party 17", "Javier Cafetero"));
            listParty.Add(new Party("P.9", "Party 18", "Irene Mora"));
        }
    }
}
