using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GerenciadorPizzaTest
{
    public class GerenciadorPizza
    {
        private List<Pessoa> pessoas { get; set; }
        private List<Preferencia> preferencias { get; set; }
        public string Pizza { get; private set; }

        public GerenciadorPizza()
        {

        }

        public List<Pessoa> RemoverPropriaPessoa(string nome, List<Pessoa> pessoas)
        {

            var filtrados = new List<Pessoa>();
            foreach (var p in pessoas)
            {
                if (p.Nome != nome)
                {
                    filtrados.Add(p);
                }

            }
            return filtrados;
        }

        public List<Pessoa> EncontrarPessoasComAfinidade(List<Preferencia> ListaMinhasPreferencias, List<Pessoa> filtrados)
        {
            List<Pessoa> pessoasEscolhidas = new List<Pessoa>();

            foreach (var p in filtrados)
            {
                int j = 0;
                for (int i = 0; i < 5;)
                {
                    if (p.Preferencias[i].Pizza == ListaMinhasPreferencias[j].Pizza && p.Preferencias[i].Nota >= ListaMinhasPreferencias[j].Nota)
                    {

                        pessoasEscolhidas.Add(p);


                        if (ListaMinhasPreferencias.Count > 1)
                        {
                            j++;
                            i++;
                        }
                        else
                        {
                            i++;
                        }

                    }
                    else
                    {
                        i++;
                   }                    
                }
            }

            return pessoasEscolhidas;
        }
    }
}
