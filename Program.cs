using System;

namespace DIO.Series {
    class Program {
        static SerieRepositorio repositorio = new SerieRepositorio();

        static void Main(string[] args) {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X") {
                switch (opcaoUsuario) {
                    case "1":
                        Console.Clear();
                        ListarSeries();
                        break;
                    case "2":
                        Console.Clear();
                        InserirSeries();
                        break;
                    case "3":
                        Console.Clear();
                        AtualizarSeries();
                        break;
                    case "4":
                        Console.Clear();
                        ExcluirSeries();
                        break;
                    case "5":
                        Console.Clear();
                        VisualizarSeries();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                Console.Clear();
                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();
        }

        private static void VisualizarSeries()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);

            Console.Clear();
            Console.Write("*** Dados da série ***");
            Console.WriteLine(serie);
            PauseEnterContinue();
        }

        private static void ExcluirSeries()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());
            repositorio.Excluir(indiceSerie);
        }

        private static void AtualizarSeries()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            int entradaGenero, entradaAno;
            string entradaTitulo, entradaDescricao;
            InserirAtualizar(out entradaGenero, out entradaTitulo, out entradaAno, out entradaDescricao);

            Serie atualizarSerie = new Serie(
                id: indiceSerie,
                genero: (Genero)entradaGenero,
                titulo: entradaTitulo,
                ano: entradaAno,
                descricao: entradaDescricao
            );

            repositorio.Atualizar(indiceSerie, atualizarSerie);
        }

        private static void InserirAtualizar(
            out int entradaGenero, 
            out string entradaTitulo, 
            out int entradaAno, 
            out string entradaDescricao
        ) {
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}: - {1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.Write("Digite o gênero entre as opções acima: ");
            entradaGenero = int.Parse(Console.ReadLine());
            Console.Write("Digite o título da série: ");
            entradaTitulo = Console.ReadLine();
            Console.Write("Digite o ano de início da série: ");
            entradaAno = int.Parse(Console.ReadLine());
            Console.Write("Digite a descrição da série: ");
            entradaDescricao = Console.ReadLine();
        }

        private static void InserirSeries() {
            Console.WriteLine("Inserir nova série");
            
            int entradaGenero, entradaAno;
            string entradaTitulo, entradaDescricao;
            InserirAtualizar(out entradaGenero, out entradaTitulo, out entradaAno, out entradaDescricao);

            Serie novaSerie = new Serie(
                id: repositorio.ProximoId(),
                genero: (Genero)entradaGenero,
                titulo: entradaTitulo,
                ano: entradaAno,
                descricao: entradaDescricao
            );

            repositorio.Inserir(novaSerie);
        }

        private static void ListarSeries() {
            Console.WriteLine("Listar séries");

            var lista = repositorio.Lista();
            
            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                PauseEnterContinue();
                return;
            }

            foreach (var serie in lista) {
                var excluido = serie.retornaExcluido();
                
                Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), excluido ? "*Excluído*" : "");
            }

            PauseEnterContinue();             
        }

        private static void PauseEnterContinue()
        {
            Console.Write("\nPressione 'Enter' para continuar...");
            while (Console.ReadKey().Key != ConsoleKey.Enter) { }
        }

        private static string ObterOpcaoUsuario() {
            Console.WriteLine("DIO Bank a seu dispor!!!");
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Listar séries");
            Console.WriteLine("2- Inserir nova séries");
            Console.WriteLine("3- Atualizar séries");
            Console.WriteLine("4- Excluir séries");
            Console.WriteLine("5- Visualizar séries");
            Console.WriteLine("C- Limpar tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }        
    }
}
