
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetoMedicamento {
    class Medicamento {
        private int id;
        private string nome;
        private string laboratorio;
        private Queue<Lote> lotes;

        public int Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Laboratorio { get => laboratorio; set => laboratorio = value; }
        internal Queue<Lote> Lotes { get => lotes; set => lotes = value; }

        public Medicamento(int id, string nome, string laboratorio) {
            this.Id = id;
            this.Laboratorio = laboratorio;
            this.Nome = nome;
            Lotes = new Queue<Lote>();
        }

        public Medicamento() : this(0, "", "") { }

        public int qtDisponivel() {
            int qtdEstoque = 0;
            foreach (Lote lote in Lotes) {
                qtdEstoque += lote.Qtde;
            }
            return qtdEstoque;
        }

        public void comprar(Lote lote) {
            Lotes.Enqueue(lote);
        }

        public bool vender(int qtde) {
            if (qtDisponivel() >= qtde) {
                while (qtde > 0) {
                    if (qtde >= Lotes.Peek().Qtde - 1) {
                        qtde -= Lotes.Dequeue().Qtde;
                    }
                    else {
                        Lotes.Peek().Qtde -= qtde;
                    }
                }
                return true;
            }
            return false;
        }

        public override string ToString() {
            return "ID:" + Id + " \nNome: " + Nome + " \nLaboratorio: " + Laboratorio + " \nQuantidade: " + qtDisponivel();
        }
       
        public override bool Equals(object obj) {
            return ((Medicamento)obj).id.Equals(this.id);
        }
    }
}
