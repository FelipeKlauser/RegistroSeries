using System.Collections.Generic;
using App_Cadastro.interfaces;

namespace App_Cadastro.classes
{
    public class SerieRepositorio : IRepositorio<Serie>
    {
        private List<Serie> Series = new List<Serie>();
        public void Atualiza(int id, Serie entidade)
        {
            Series[id] = entidade;
        }

        public void Exclui(int id)
        {
            Series[id].Exclui();
        }

        public void Insere(Serie entidade)
        {
            Series.Add(entidade);
        }

        public List<Serie> Lista()
        {
            return Series;
        }

        public int ProximoID()
        {
            return Series.Count;
        }

        public Serie RetornaPorID(int id)
        {
            return Series[id];
        }
    }
}