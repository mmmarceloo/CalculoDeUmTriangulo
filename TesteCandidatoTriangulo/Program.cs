using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace TesteCandidatoTriangulo
{
    class Program
    {
        static void Main(string[] args)
        {
            string dadosTriangulo = "[[16],[3,5],[9,7,1],[4,6,8,4]]";

            Console.WriteLine($"O resultado é: {Triangulo.ResultadoTriangulo(dadosTriangulo)}");            
            
        }
    }
}
