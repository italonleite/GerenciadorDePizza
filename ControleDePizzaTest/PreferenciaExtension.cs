using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciadorPizzaTest
{
    //toda classe Extension deve ser static e deve referenciar o THIS no parametro para identificar o contexto
    public static class PreferenciaExtension
    {
        const int LIMITEPREFEENCIA = 5;

        public static void lancarErroAcimaDoLimitePermitido(this List<Preferencia> preferencias) {

            if (preferencias.Count >= LIMITEPREFEENCIA)
                throw new InvalidOperationException();
        }

    }
}
