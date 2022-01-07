using CadastroSeries_GRUD.Models;
using CadastroSeries_GRUD.Src;

namespace CadastroSeries_GRUD.Web
{
    public class SerieModel
    {
        //Atributos
        public int Id { get;  set; }
        public Genero Genero { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int Ano { get; set; }

        public SerieModel() { 
        }

        public SerieModel(Serie serie)
        {
            Id = serie.Id;
            Genero = serie.retornaGenero();
            Titulo = serie.retornaTitulo();
            Descricao = serie.retornaDescricao();
            Ano = serie.retornaAno();
        }

        public Serie ToSerie() {
            return new Serie(Id, Genero, Titulo, Descricao, Ano);
        }
    }
}
