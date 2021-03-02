using System;
using App_Cadastro.classes;
using App_Cadastro.enums;

namespace App_Cadastro
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcao = ObterOpcaoUsuario();

            while(opcao != "X"){
                switch(opcao){
                    case "1":
                        ListaSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizaSerie();
                        break;
                    case "4":
                        ExcluiSerie();
                        break;
                    case "5":
                        VisualizaSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                }
                opcao = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado por utilizar nossos serviços!");
            Console.ReadLine();
        }

        #region METODOS_SERIES
        private static void ListaSeries(){
            Console.WriteLine("Listar séries:");
            Console.WriteLine("...");
            
            var lista = repositorio.Lista();

            if(lista.Count == 0) {Console.WriteLine("Nenhuma série cadastrada!"); return; }

            for(int i = 0; i < lista.Count; i++) 
                Console.WriteLine(
                    "{2}#ID {0}: - {1}.", lista[i].RetornaID(), lista[i].RetornaTitulo(), 
                    lista[i].RetornaExcluido() ? "(Excluido)" : ""
                );
        }
        private static void InserirSerie(){
            Console.WriteLine("Inserir série:");
            Console.WriteLine("...");
            repositorio.Insere(RetornaSerie(repositorio.ProximoID()));

            Console.WriteLine("...");
            Console.WriteLine("Série adicionada com sucesso!");
        }
        private static void AtualizaSerie(){
            Console.WriteLine("Atualizar série:");
            Console.WriteLine("...");
            Console.WriteLine("Digite o ID da série a ser atualizada: ");
            int inputID = int.Parse(Console.ReadLine());

            repositorio.Atualiza(inputID, RetornaSerie(inputID));
            Console.WriteLine("...");
            Console.WriteLine("Série atualizada com sucesso.");
        }
        private static void ExcluiSerie(){
            Console.WriteLine("Excluir série:");
            Console.WriteLine("...");
            Console.WriteLine("Digite o ID da série que deseja excluir: ");
            int inputID = int.Parse(Console.ReadLine());

            Console.WriteLine("Deseja mesmo excluir a série {0}-{1}?", inputID, repositorio.RetornaPorID(inputID).RetornaTitulo());
            Console.WriteLine("Digite S para confirmar a exclusão");
            if(Console.ReadLine().ToUpper() != "S"){
                Console.WriteLine("A série não foi excluída.");
                return;
            }
            repositorio.Exclui(inputID);
            Console.WriteLine("...");
            Console.WriteLine("Série excluida com sucesso.");
        }
        private static void VisualizaSerie(){
            Console.WriteLine("Visualizar série:");
            Console.WriteLine("...");
            Console.WriteLine("Digite o ID da série que deseja visualizar: ");
            int inputID = int.Parse(Console.ReadLine());

            Console.WriteLine("...");
            Console.WriteLine(repositorio.RetornaPorID(inputID));
        }
        private static Serie RetornaSerie(int _id){
            object[] input = new object[7];
            int[] generos = (int[])Enum.GetValues(typeof(Genero));
            
            for(int i = 0; i < generos.Length; i++)
                Console.WriteLine("{0}-{1}", generos[i], Enum.GetName(typeof(Genero), generos[i]));

            Console.WriteLine("Digite o genêro entre as opções acima: ");
            input[0] = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Digite o Título da série: ");
            input[1] = Console.ReadLine();

            Console.WriteLine("Digite a Descrição da série: ");
            input[2] = Console.ReadLine();

            Console.WriteLine("Digite o Ano de Estreia da série: ");
            input[3] = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a quantidade de episódios: ");
            input[4] = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a quantidade de temporadas: ");
            input[5] = int.Parse(Console.ReadLine());

            Console.WriteLine("A Série foi finalizada? (Digite S para Sim e N para Não) ");
            input[6] = Console.ReadLine().ToUpper() == "S";

            return new Serie(
                _id, (Genero)input[0], (string)input[1], (string) input[2], (int) input[3], 
                (int)input[4], (int)input[5], (bool)input[6]
            );
        }
        private static string ObterOpcaoUsuario(){
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada: ");
            Console.WriteLine("1 - Listar séries");
            Console.WriteLine("2 - Inserir nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");

            string opcao = Console.ReadLine().ToUpper();
            return opcao;
        }
        #endregion
    }
}
