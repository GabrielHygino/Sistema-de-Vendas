using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVendasPrj
{
    class Validacao_cpf
    {
        public static bool verificar(string cpf)
        {
            int[] VerificarDigito1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] VerificarDigito2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string CPF1, CPF2;
            int soma, resultado;

            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");

            if (cpf.Length != 11)
                return false;

            CPF1 = cpf.Substring(0, 10);
            soma = 0;

            for (int a = 0; a < 9; a++)
                soma += int.Parse(CPF1[a].ToString()) * VerificarDigito1[a];
            resultado = soma % 11;
            if (resultado < 2)
            {
                resultado = 0;
            }
            else
            {
                resultado = 11 - resultado;
            }

            CPF2 = resultado.ToString();
            CPF1 = CPF1 + CPF2;

            soma = 0;
            for (int b = 0; b < 10; b++)
                soma += int.Parse(CPF1[b].ToString()) * VerificarDigito2[b];
            resultado = soma % 11;
            if (resultado < 2)
            {
                resultado = 0;
            }
            else
            {
                resultado = 11 - resultado;
            }

            CPF2 = CPF2 + resultado.ToString();

            return cpf.EndsWith(CPF2);

        }
    }
}
