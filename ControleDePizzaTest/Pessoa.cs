using System;
using System.Collections.Generic;
using System.Linq;

namespace GerenciadorPizzaTest
{
    public class Pessoa
    {
        public string Nome { get; set; }
        public List<Preferencia> Preferencias { get; set; }

        public Pessoa()
        {

        }

        public Pessoa(string nome)
        {
            Nome = nome;
            this.Preferencias = new List<Preferencia>();
        }


        public void AdicionarPreferencia(Sabor pizza, int nota)
        {
            Preferencias.lancarErroAcimaDoLimitePermitido();
            Preferencias.Add(new Preferencia(pizza, nota));
        }

        public (List<Preferencia>, string) MinhaListaPreferencia(Pessoa p)
        {
            List<Preferencia> minhaLista = new List<Preferencia>();

            var maiorNota = p.Preferencias.Max(p => p.Nota);

            for (var i = 0; i < p.Preferencias.Count;)
            {
                if (p.Preferencias[i].Nota >= maiorNota)
                {

                    minhaLista.Add(p.Preferencias[i]);
                    i++;
                }
                else
                {
                    i++;
                }
            }
            return (minhaLista, p.Nome);
        }
    }
}