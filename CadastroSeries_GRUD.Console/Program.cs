﻿using System;
using CadastroSeries_GRUD.Src;
using CadastroSeries_GRUD.Models;

namespace CadastroSeries_GRUD
{
	public class Program
	{
		static private SerieRepository SerieRepository { get; set; } = new SerieRepository();

		static void Main(string[] args)
		{
			string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarSeries();
						break;
					case "2":
						InserirSerie();
						break;
					case "3":
						AtualizarSerie();
						break;
					case "4":
						ExcluirSerie();
						break;
					case "5":
						VisualizarSerie();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
		}

		private static void ListarSeries()
		{
			Console.WriteLine("Listar séries");

			var lista = SerieRepository.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma série cadastrada.");
				return;
			}

			foreach (var serie in lista)
			{
				var excluido = serie.retornaExcluido();

				Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

		private static void VisualizarSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine()!);

			var serie = SerieRepository.RetornaPorId(indiceSerie);

			Console.WriteLine(serie);
		}

		private static Serie BuildByUser(int? id)
		{

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine()!);

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine()!;

			Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine()!);

			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine()!;

			return new Serie(id: (id is null) ? SerieRepository.ProximoId() : id.Value,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);
		}

		private static void AtualizarSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine()!);

			SerieRepository.Atualiza(indiceSerie, BuildByUser(indiceSerie));
		}

		private static void InserirSerie()
		{
			Console.WriteLine("Inserir nova série");

			SerieRepository.Insere(BuildByUser(null));
		}
		private static void ExcluirSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine()!);

			SerieRepository.Exclui(indiceSerie);
		}


		private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("DIO Séries a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar séries");
			Console.WriteLine("2- Inserir nova série");
			Console.WriteLine("3- Atualizar série");
			Console.WriteLine("4- Excluir série");
			Console.WriteLine("5- Visualizar série");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			var opcaoUsuario = Console.ReadLine();
			Console.WriteLine();

			if (opcaoUsuario is null)
				return "NULL";

			return opcaoUsuario;
		}
	}
}
