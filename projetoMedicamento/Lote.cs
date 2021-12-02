using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace projetoMedicamento {
    class Lote {
        private int id;
        private int qtde;
        private DateTime venc;

        public int Id { get => id; set => id = value; }
        public int Qtde { get => id; set => id = value; }
        public DateTime Venc { get => venc; set => venc = value; }

        public Lote(int id, int qtde, DateTime venc) {
            this.Id = id;
            this.Qtde = qtde;
            this.Venc = venc;
        }

        public Lote() : this(0, 0, new DateTime()) { }

        public override string ToString() {
            return this.Id.ToString() + " - " + this.qtde.ToString() + " - " + this.venc.ToShortDateString();
        }


    }
}
