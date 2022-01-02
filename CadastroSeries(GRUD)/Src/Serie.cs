using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CadastroSeries_GRUD.Models;

namespace CadastroSeries_GRUD.Src
{
     public class Serie:EntitiesBase
    {
        //Atributos
        private Genero Genero { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }
        private bool isAlive { get; set; }

        public Serie(int id, Genero genero, string titulo, string descricao, int ano)
        { 
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao; 
            this.Ano = ano;
            this.isAlive = true;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Gênero: " + this.Genero + Environment.NewLine;
            retorno += "Titulo: " + this.Titulo + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Ano de Início: " + this.Ano + Environment.NewLine;
            retorno += "Excluido: " + !this.isAlive + Environment.NewLine;
            return retorno;
        }

        public string retornaTitulo()
        {
            return Titulo;
        }

        public int retornaId() {
        
            return Id;
        }
        public void Excluir() {
            this.isAlive = false;
        }
        public bool retornaExcluido()
        {
            return !this.isAlive;
        }
    }
}
