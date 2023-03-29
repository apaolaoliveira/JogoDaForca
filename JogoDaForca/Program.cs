using System.Globalization;
using System.Xml;

namespace JogoDaForca
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int erros = 0;
            bool acertou = false, enforcou = false;

            string palavraSecreta;
            char[] letrasEncontradas;

            DefinirPalavraSecreta(out palavraSecreta, out letrasEncontradas);

            while (erros < 5 && new string(letrasEncontradas) != palavraSecreta)
            {
                DesenharForca(erros);

                Console.WriteLine(letrasEncontradas);

                char chute = ObterChute();

                bool letraFoiEncontrada = false;
                for (int i = 0; i < palavraSecreta.Length; i++)
                {
                    if (chute == palavraSecreta[i])
                    {
                        letrasEncontradas[i] = chute;
                        letraFoiEncontrada = true;
                    }
                }

                if (letraFoiEncontrada == false)
                    erros++;

                string palavraEncontrada = new string(letrasEncontradas);

                acertou = palavraEncontrada == palavraSecreta;
                enforcou = erros == 5;

                if (acertou)
                    Console.WriteLine($"\nVocê acertou a palavra {palavraSecreta}, parabéns!");
                else if (enforcou)
                {
                    Console.WriteLine("\nQue azar! Tente novamente!");
                    Console.WriteLine($"\nA palavra secreta era {palavraSecreta}.");
                }

                Console.ReadLine();
            }
        }

        private static void DefinirPalavraSecreta(out string palavraSecreta, out char[] letrasEncontradas)
        {
            string[] palavras = {"ABACATE", "ABACAXI", "ACEROLA", "ACAI", "ARACA", "ABACATE", "BACABA", "BACURI", "BANANA", "CAJA", "CAJU",
            "CARAMBOLA","CUPUACU", "GRAVIOLA", "GOIABA", "JABUTICABA", "JENIPAPO", "MACA", "MANGABA", "MANGA", "MARACUJA", "MURICI", "PEQUI",
            "PITANGA", "PITAYA", "SAPOTI", "TANGERINA", "UMBU", "UVA", "UVAIA"};

            Random random = new Random();

            int indiceEscolhido = random.Next(palavras.Length);
            
            palavraSecreta = palavras[indiceEscolhido];
            
            letrasEncontradas = new char[palavraSecreta.Length];
            
            for (int caractere = 0; caractere < letrasEncontradas.Length; caractere++)
                letrasEncontradas[caractere] = '_';
        }

        static char ObterChute()
        {
            Console.Write("\nQual o seu chute? ");
            char chute = Convert.ToChar(Console.ReadLine());
            chute = char.ToUpper(chute);
            return chute;
        }

        static void DesenharForca(int quantidadeErros)
        {
            string cabecaDoBoneco = quantidadeErros >= 1 ? " o " : " ";
            string bracoEsquerdo = quantidadeErros >= 3 ? "/" : " ";
            string tronco = quantidadeErros >= 2 ? "x" : " ";
            string troncoBaixo = quantidadeErros >= 2 ? " x " : " ";
            string bracoDireito = quantidadeErros >= 3 ? @"\" : " ";
            string pernas = quantidadeErros >= 4 ? "/ \\" : " ";

            Console.Clear();
            Console.WriteLine("*************************");
            Console.WriteLine("      JOGO DA FORCA      ");
            Console.WriteLine("*************************");
            Console.WriteLine();
            Console.WriteLine("  ______________        ");
            Console.WriteLine("  |/           |        ");
            Console.WriteLine("  |           {0}       ", cabecaDoBoneco);
            Console.WriteLine("  |           {0}{1}{2} ", bracoEsquerdo, tronco, bracoDireito);
            Console.WriteLine("  |           {0}       ", troncoBaixo);
            Console.WriteLine("  |           {0}       ", pernas);
            Console.WriteLine("  |                     ");
            Console.WriteLine("  |                     ");
            Console.WriteLine("__|______               ");
            Console.WriteLine("\nDica: frutas.         ");
            Console.WriteLine();

        }
    }
 
}
