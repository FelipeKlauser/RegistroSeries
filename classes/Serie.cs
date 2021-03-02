using System;
using App_Cadastro.enums;

namespace App_Cadastro
{
    public class Serie : EntidadeBase
    {
        private Genero Genero { get; set; }
        private string Titulo { get; set;}
        private string Descricao {get; set;}
        private int Ano {get; set;}
        private int Episodios {get; set;}
        private int Temporadas {get; set;}
        private bool Finalizada {get; set;}
        private bool Excluido {get; set;}

        public Serie(int _id, Genero _genero, string _titulo, string _descricacao, int _ano, int _eps, int _temps, bool _fim){
            ID = _id;
            Genero = _genero;
            Titulo = _titulo;
            Descricao = _descricacao;
            Ano = _ano;
            Episodios = _eps;
            Temporadas = _temps;
            Finalizada = _fim;
            Excluido = false;
        }

        public override string ToString(){
            string r = "";
            r += "Titulo: " + Titulo + Environment.NewLine;
            r += "Gênero: " + Genero + Environment.NewLine;
            r += "Descrição: " + Descricao + Environment.NewLine;
            r += "Ano de Estreia: " + Ano + Environment.NewLine;
            r += "Episódios: " + Episodios + Environment.NewLine;
            r += "Temporadas: " + Temporadas + Environment.NewLine;
            r += Finalizada ? "Série Finalizada." : "Série em Andamento";
            r += Environment.NewLine;

            r += "Excluido: ";
            r += Excluido ? "Sim" : "Não";
            return r;
        }

        public string RetornaTitulo(){
            return Titulo;
        }

        public int RetornaID(){
            return this.ID;
        }

        public bool RetornaExcluido(){
            return Excluido;
        }
        public void Exclui(){
            Excluido = true;
        }
    }
}