using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VTM {
    public class Container {
        public int ContainerId { get; set; }
        public string ContainerNummer { get; set; }

        public Container(int ContainerId, string ContainerNummer) {
            this.ContainerId = ContainerId;
            this.ContainerNummer = ContainerNummer;
        }
    }
}
