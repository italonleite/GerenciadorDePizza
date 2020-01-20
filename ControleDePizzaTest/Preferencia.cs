namespace GerenciadorPizzaTest
{
    public class Preferencia
    {
        
        public Sabor Pizza { get; set; }
        public int Nota { get; set; }
       
        
        public Preferencia(Sabor pizza, int nota)
        {
            Pizza = pizza;
            Nota = nota;
          
        }

      
    }
}