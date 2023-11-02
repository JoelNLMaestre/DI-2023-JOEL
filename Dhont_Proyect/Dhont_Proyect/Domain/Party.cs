using Dhont_Proyect.Persistance.Manage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dhont_Proyect.Domain
{
    class Party
    {
        public String name { get; set; }
        public String acronym { get; set; }

        public String president { get; set; }
        public PartyManage pm { get; set; }

        public int votes { get; set; }
        public int seats { get; set; }
        public Party() {
            pm = new PartyManage();
        }

        public Party(String acronym, String name, String president)
        {
            this.acronym = acronym;
            this.name = name;
            this.president = president;
            pm = new PartyManage();
        }

        public void readP()
        {
            pm.readParty();
        }
        public List<Party> getListPeople()
        {
            return pm.listParty;
        }

    }
}
