using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VTM {
    public class Flow {
        public int FlowID { get; set; }
        public string Omschrijving { get; set; }

        public Flow(int FlowID, string Omschrijving) {
            this.FlowID = FlowID;
            this.Omschrijving = Omschrijving;
        }
    }
}
