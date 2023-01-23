using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteCandidatoTriangulo
{
    public static class Triangulo
    {
        /// <summary>
        ///    6
        ///   3 5
        ///  9 7 1
        /// 4 6 8 4
        /// Um elemento somente pode ser somado com um dos dois elementos da próxima linha. Como o elemento 5 na Linha 2 pode ser somado com 7 e 1, mas não com o 9.
        /// Neste triangulo o total máximo é 6 + 5 + 7 + 8 = 26
        /// 
        /// Seu código deverá receber uma matriz (multidimensional) como entrada. O triângulo acima seria: [[6],[3,5],[9,7,1],[4,6,8,4]]
        /// </summary>
        /// <param name="dadosTriangulo"></param>
        /// <returns>Retorna o resultado do calculo conforme regra acima</returns>
       
        public static int ResultadoTriangulo(string dadosTriangulo)
        {
            string x = dadosTriangulo;//"[[10],[3,5],[9,7,1],[4,6,8,4]]";
            int soma = 0;

           
            x = x.Replace("[","");
            x = x.Replace("]", "");

            string[] xFormatado = x.Split(',');

            int[] xInt = new int[xFormatado.Length];

            for (int i = 0; i < xFormatado.Length; i++)
            {
                xInt[i] = int.Parse(xFormatado[i]);
            }
           

            if (xInt[1] > xInt[2]) // primeiro nivel 
            {
                soma = xInt[0] + xInt[1];
                if(xInt[3] > xInt[4])
                {
                    soma += xInt[3];
                    if (xInt[6] > xInt[7])
                        soma += xInt[6];
                    else
                        soma += xInt[7];
                }
                else
                {
                    soma += xInt[4];
                    if(xInt[7] > xInt[8])
                    {
                        soma += xInt[7];
                    }
                    else
                    {
                        soma += xInt[8];
                    }
                }

            }
            else
            {

                soma = xInt[0] + xInt[2];
                if(xInt[4] > xInt[5])
                {
                    soma += xInt[4];
                    if(xInt[7] > xInt[8])
                        soma += xInt[7];
                    else
                        soma += xInt[8];
                }
                else
                {
                    soma += xInt[5];
                    if(xInt[8] > xInt[9])
                        soma += xInt[8];
                    else
                        soma += xInt[9];
                }
            }
            return soma;
        }
    }
}
