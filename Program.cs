using System;
using Interfaces.Models;
using Classes.Models;
using Series.Genero;
using System.Collections.Generic;

namespace CadastroDeSeries
{
    class Program
    {
        static SeriesRepositorio repositorio = new SeriesRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();
            
            while(opcaoUsuario.ToUpper() != "X"){
                switch(opcaoUsuario){
                    case "1": ListarSeries(); break;
                    case "2": InserirSerie(); break;
                    case "3": AtualizarSerie(); break;
                    case "4": ExcluirSerie(); break;
                    case "5": VisualizarSerie(); break;
                    case "C": Console.Clear(); break;
                    default: throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            
            
        }

        private static void ListarSeries(){
            System.Console.WriteLine("Listar Séries");
            System.Console.WriteLine("");
            var lista = repositorio.Lista();

            if(lista.Count() == 0){
                System.Console.WriteLine("Nenhuma Série Cadastrada");
                return;   
            }
            
            foreach(var serie in lista){
                var excluido = serie.RetornaExcluido();
                System.Console.WriteLine($"#ID {serie.RetornaId()} - {serie.RetornaTitulo()} - {(excluido ? "Excluido" : "Disponível")}");        
            }
        }

        private static void InserirSerie(){
            System.Console.WriteLine("Inserir Série");
            System.Console.WriteLine("");

            foreach(int i in Enum.GetValues(typeof(Genero))){
                System.Console.WriteLine($"{i} - {Enum.GetName(typeof(Genero),i)}");
            }

            System.Console.WriteLine("Digite o ID do gênero: ");
            int EntradaIdGenero = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite o título da série: ");
            string EntradaTitulo = Console.ReadLine();

            System.Console.WriteLine("Digite o ano de início da série: ");
            int EntradaAno = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite a descrição da série: ");
            string EntradaDescricao = Console.ReadLine();

            Serie NovaSerie = new Serie(id: repositorio.ProximoId(),
                                        genero: (Genero)EntradaIdGenero,
                                        titulo: EntradaTitulo,
                                        ano: EntradaAno,
                                        descricao: EntradaDescricao);

            repositorio.Insere(NovaSerie);
            System.Console.WriteLine("");

            System.Console.WriteLine($"ID {NovaSerie.Id} - {NovaSerie}");   
            
        }

        private static void AtualizarSerie(){
            System.Console.WriteLine("Atualizar Série");
            System.Console.WriteLine("");

            System.Console.WriteLine("Digite o ID da série: ");
            int idEntrada = int.Parse(Console.ReadLine());

            foreach(int i in Enum.GetValues(typeof(Genero))){
                System.Console.WriteLine($"{i} - {Enum.GetName(typeof(Genero),i)}");
            }

            System.Console.WriteLine("Digite o ID do gênero: ");
            int EntradaIdGenero = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite o título da série: ");
            string EntradaTitulo = Console.ReadLine();

            System.Console.WriteLine("Digite o ano de início da série: ");
            int EntradaAno = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite a descrição da série: ");
            string EntradaDescricao = Console.ReadLine();

            Serie NovaSerie = new Serie(id: idEntrada,
                                        genero: (Genero)EntradaIdGenero,
                                        titulo: EntradaTitulo,
                                        ano: EntradaAno,
                                        descricao: EntradaDescricao);

            repositorio.Atualiza(idEntrada, NovaSerie);
            }

            private static void ExcluirSerie(){
                System.Console.WriteLine("Digite o ID da série: ");
                int idEntrada = int.Parse(Console.ReadLine());

                repositorio.Exclui(idEntrada);
            }

            private static void VisualizarSerie(){
                System.Console.WriteLine("Digite o ID da série: ");
                int idEntrada = int.Parse(Console.ReadLine());

                var serie = repositorio.RetornaPorId(idEntrada);
                System.Console.WriteLine(serie);
            }

            private static string ObterOpcaoUsuario()
            {
                System.Console.WriteLine("");
                System.Console.WriteLine("Olá, Seja Bem-Vindo(a) ao Localiza Séries");
                System.Console.WriteLine("");

                System.Console.WriteLine("1 - Listar Séries");
                System.Console.WriteLine("2 - Inserir Nova Série");
                System.Console.WriteLine("3 - Atualizar Série");
                System.Console.WriteLine("4 - Excluir Série");
                System.Console.WriteLine("5 - Visualizar Série");
                System.Console.WriteLine("C - Limpar Tela");
                System.Console.WriteLine("X - Sair");
                System.Console.WriteLine("");

                System.Console.Write("Informe a opção desejada: ");
                string opcaoUsuario = Console.ReadLine().ToUpper();
                System.Console.WriteLine("");
                return opcaoUsuario;
                
            }
    }
}
