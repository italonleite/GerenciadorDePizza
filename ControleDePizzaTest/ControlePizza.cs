using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace GerenciadorPizzaTest
{
    public class ControlePizza
    {
        [Fact]
        public void Deve_ter_instancia_de_pessoa()
        {
            Pessoa p = new Pessoa("italo");

            var valorEsperado = typeof(Pessoa);

            Assert.Equal(valorEsperado, p.GetType());


        }

        [Fact]
        public void Deve_ser_possivel_adicionar_preferencias_de_pizzas()
        {
            var pessoa = new Pessoa("Italo");
            pessoa.AdicionarPreferencia(Sabor.Marguerita, 4);
            pessoa.AdicionarPreferencia(Sabor.Calabresa, 1);
            Assert.Equal(2, pessoa.Preferencias.Count);

        }

        [Fact]
        public void Deve_ser_possivel_adicionar_maximo_5_preferencias()
        {
            try
            {
                var pessoa = new Pessoa("Italo");
                pessoa.AdicionarPreferencia(Sabor.Marguerita, 4);
                pessoa.AdicionarPreferencia(Sabor.Calabresa, 1);
                pessoa.AdicionarPreferencia(Sabor.QuatroQueijos, 3);
                pessoa.AdicionarPreferencia(Sabor.Portuguesa, 5);
                pessoa.AdicionarPreferencia(Sabor.FrangoCatupiry, 2);
                pessoa.AdicionarPreferencia(Sabor.FrangoCatupiry, 2);

                Assert.True(false);
            }
            catch (System.InvalidOperationException)
            {
                Assert.True(true);

            }
            catch (System.Exception)
            {
                Assert.True(false);
            }
        }

        [Fact]
        public void Deve_dividir_pizza_com_uma_Pessoa()
        {
            var cardoso = new Pessoa("Cardoso");
            var italo = new Pessoa("Italo");
            var gabriel = new Pessoa("Gabriel");

            cardoso.AdicionarPreferencia(Sabor.Calabresa, 5);
            cardoso.AdicionarPreferencia(Sabor.FrangoCatupiry, 2);
            cardoso.AdicionarPreferencia(Sabor.Marguerita, 3);
            cardoso.AdicionarPreferencia(Sabor.Portuguesa, 2);
            cardoso.AdicionarPreferencia(Sabor.QuatroQueijos, 1);

            italo.AdicionarPreferencia(Sabor.Calabresa, 5);
            italo.AdicionarPreferencia(Sabor.FrangoCatupiry, 1);
            italo.AdicionarPreferencia(Sabor.Marguerita, 3);
            italo.AdicionarPreferencia(Sabor.Portuguesa, 4);
            italo.AdicionarPreferencia(Sabor.QuatroQueijos, 5);

            gabriel.AdicionarPreferencia(Sabor.Calabresa, 4);
            gabriel.AdicionarPreferencia(Sabor.FrangoCatupiry, 2);
            gabriel.AdicionarPreferencia(Sabor.Marguerita, 3);
            gabriel.AdicionarPreferencia(Sabor.Portuguesa, 4);
            gabriel.AdicionarPreferencia(Sabor.QuatroQueijos, 4);

            List<Pessoa> pessoas = new List<Pessoa>();
            pessoas.Add(italo);
            pessoas.Add(gabriel);
            pessoas.Add(cardoso);

            Pessoa p = new Pessoa();
            var minhasPreferencias = p.MinhaListaPreferencia(cardoso);
            var ListaMinhasPreferencias = minhasPreferencias.Item1;
            var Nome = minhasPreferencias.Item2;

            GerenciadorPizza gerenciador = new GerenciadorPizza();
            var pessoasFiltradas = gerenciador.RemoverPropriaPessoa(Nome, pessoas);
            var pessoaEscolhida = gerenciador.EncontrarPessoasComAfinidade(ListaMinhasPreferencias, pessoasFiltradas);

            Assert.Equal(italo.Nome, pessoaEscolhida[0].Nome);

        }


        [Fact]
        public void Deve_dividir_pizza_com_uma_Lista_Pessoa()
        {
            var cardoso = new Pessoa("Cardoso");
            var italo = new Pessoa("Italo");
            var gabriel = new Pessoa("Gabriel");

            cardoso.AdicionarPreferencia(Sabor.Calabresa, 5);
            cardoso.AdicionarPreferencia(Sabor.FrangoCatupiry, 2);
            cardoso.AdicionarPreferencia(Sabor.Marguerita, 3);
            cardoso.AdicionarPreferencia(Sabor.Portuguesa, 2);
            cardoso.AdicionarPreferencia(Sabor.QuatroQueijos, 1);

            italo.AdicionarPreferencia(Sabor.Calabresa, 5);
            italo.AdicionarPreferencia(Sabor.FrangoCatupiry, 1);
            italo.AdicionarPreferencia(Sabor.Marguerita, 3);
            italo.AdicionarPreferencia(Sabor.Portuguesa, 4);
            italo.AdicionarPreferencia(Sabor.QuatroQueijos, 5);

            gabriel.AdicionarPreferencia(Sabor.Calabresa, 5);
            gabriel.AdicionarPreferencia(Sabor.FrangoCatupiry, 2);
            gabriel.AdicionarPreferencia(Sabor.Marguerita, 3);
            gabriel.AdicionarPreferencia(Sabor.Portuguesa, 4);
            gabriel.AdicionarPreferencia(Sabor.QuatroQueijos, 4);

            List<Pessoa> pessoas = new List<Pessoa>();
            pessoas.Add(italo);
            pessoas.Add(gabriel);
            pessoas.Add(cardoso);

            Pessoa p = new Pessoa();
            var minhasPreferencias = p.MinhaListaPreferencia(cardoso);
            var ListaMinhasPreferencias = minhasPreferencias.Item1;
            var Nome = minhasPreferencias.Item2;

            GerenciadorPizza gerenciador = new GerenciadorPizza();
            var pessoasFiltradas = gerenciador.RemoverPropriaPessoa(Nome, pessoas);
            var pessoaEscolhida = gerenciador.EncontrarPessoasComAfinidade(ListaMinhasPreferencias, pessoasFiltradas);

            Assert.Collection(pessoaEscolhida,
                item => Assert.Equal(pessoas[0].Nome, item.Nome),
                item => Assert.Equal(pessoas[1].Nome, item.Nome)
            );



        }





    }
}




