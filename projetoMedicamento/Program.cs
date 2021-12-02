using System;

namespace projetoMedicamento
{
    class Program
    {
        static void Main(string[] args)
        {
            int opSelecionada;
            bool menuescolha;
            bool sair = false;

            Medicamentos medicamentos = new Medicamentos();

            while(!sair)
            {
                Console.WriteLine(
                        "|  0. Finalizar processo\n|" + "  1. Cadastrar medicamento\n|" + "  2. Consultar medicamento (sintético: informar dados)\n|" +
                        "  3. Consultar medicamento (analítico: informar dados1 + lotes)\n|" +
                        "  4. Comprar medicamento (cadastrar lote) \n|" +
                        "  5. Vender medicamento (abater do lote mais antigo)\n|" +
                        "  6. Listar medicamentos (informando dados sintéticos)\n" +
                        " \nDigite a opção:\n "
                 );
                opSelecionada = int.Parse(Console.ReadLine());

                switch (opSelecionada)
                {
                    case 0:
                        sair = true;
                        break;
                    case 1:
                        cadMedicamento(medicamentos);
                        break;
                    case 2:
                        consMedicamentoSint(medicamentos);
                        break;
                    case 3:
                        consMedicamentoAna(medicamentos);
                        break;
                    case 4:
                        compMedicamento(medicamentos);
                        break;
                    case 5:
                        vendMedicamento(medicamentos);
                        break;
                    case 6:
                        listMedicamento(medicamentos);
                        break;
                    default:
                        Console.WriteLine("Digite uma opção válida.");
                        break;
                }

            }

            void cadMedicamento(Medicamentos medicamentos)
            {
                Console.Clear();
                Console.WriteLine("CADASTRO DE MEDICAMENTOS");
                Console.Write("ID do medicamento: ");
                int Mid = int.Parse(Console.ReadLine());
                Console.WriteLine("Nome do medicamento: ");
                string Mnome = Console.ReadLine();
                Console.WriteLine("Laboratório: ");
                string Mlab = Console.ReadLine();
                Medicamento m1 = new Medicamento(Mid, Mnome, Mlab);
                medicamentos.adicionar(m1);
                Console.WriteLine("Medicamento cadastrado com sucesso! Aperte qualquer tecla para voltar ao menu inicial.");
                Console.ReadKey();
                Console.Clear();
            }

            void consMedicamentoSint(Medicamentos medicamentos)
            {
                Console.Clear();
                Console.WriteLine("CONSULTA DE MEDICAMENTOS (SINTÉTICO)");

                Console.WriteLine("ID:");
                int Mid = int.Parse(Console.ReadLine());
 
                Medicamento _medicamento = medicamentos.pesquisar(new Medicamento(Mid, "", ""));
                if (_medicamento.Id == 0)
                {
                    Console.WriteLine("O medicamento inserido não pode ser encontrado.");
                } else {
                    Console.WriteLine(_medicamento.ToString());
                }
                Console.ReadKey();
                Console.Clear();
            }

            void consMedicamentoAna(Medicamentos medicamentos)
            {
                Console.Clear();
                Console.WriteLine("CONSULTA DE MEDICAMENTOS (ANALÍTICO)");

                Console.WriteLine("ID: ");
                int Mid = int.Parse(Console.ReadLine());
                Medicamento _medicamento = medicamentos.pesquisar(new Medicamento(Mid, "", ""));
                if (_medicamento.Id == 0)
                {
                    Console.WriteLine("O medicamento inserido não pode ser encontrado.");
                }
                else
                {
                    Console.WriteLine(_medicamento.ToString());
                }

                foreach (Lote l in _medicamento.Lotes)
                {
                    Console.WriteLine(l.ToString());
                }
                Console.ReadKey();
                Console.Clear();
            }

            void compMedicamento(Medicamentos medicamentos)
            {
                Console.Clear();
                Console.WriteLine("COMPRAR MEDICAMENTO");
                DateTime venc = DateTime.Now;
                Console.WriteLine("ID: ");
                int Mid = int.Parse(Console.ReadLine());
                Medicamento _medicamento = medicamentos.pesquisar(new Medicamento(Mid, "", ""));
                Console.WriteLine("SOBRE O LOTE");
 
                Console.WriteLine("ID Lote ");
                int Lid = int.Parse(Console.ReadLine());
  
                Console.WriteLine("Quantidade");
                int qtd = int.Parse(Console.ReadLine());
                       

                Console.WriteLine("Data de vencimento em formato (DD/MM/AAAA)");
                venc = DateTime.Parse(Console.ReadLine());
       
                Console.WriteLine("Compra realizada! Aperte qualquer tecla para voltar ao menu inicial.");

                Lote nLote = new Lote(Lid, qtd, venc);
                _medicamento.comprar(nLote);

                Console.ReadKey();
                Console.Clear();
            }

            void vendMedicamento(Medicamentos medicamentos)
            {
                Console.Clear();
                Console.WriteLine("VENDER MEDICAMENTO");
                Console.WriteLine("ID:");
                int Mid = int.Parse(Console.ReadLine());
                Medicamento _medicamento = medicamentos.pesquisar(new Medicamento(Mid, "", ""));

                Console.WriteLine("Quantidade: ");
                int qtd = int.Parse(Console.ReadLine());

                _medicamento.vender(qtd);
                Console.WriteLine("Produto vendido! Aperte qualquer tecla para voltar ao menu inicial.");
                
                Console.ReadKey();
            }

            void listMedicamento(Medicamentos medicamentos)
            {
                foreach (Medicamento m in medicamentos.ListaMedicamentos)
                {
                    Console.WriteLine(m.ToString());
                }
                Console.ReadKey();
                Console.Clear();
            }

        }
    }
}
