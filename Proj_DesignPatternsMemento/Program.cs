
using NUnit.Framework;
using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using Xunit;

namespace Proj_DesignPatternsMemento
{
    internal class Program
    {
        private const string Logradouro_Original = "Avenida Barroso 100";
        private const string Mudando_Logradouro1 = "Avenida Coração 200";
        private const string Mudando_Logradouro2 = "Avenida Santo Antônio 300";
        private const string Mudando_Logradouro3 = "Rua Nove de Julho 400";


        static void Test()
        {
            Cliente cliente = new Cliente(1, "Baratão", Logradouro_Original, "Araraquara", "14810110");

            Assert.False(cliente.VerifContaminado);
            Assert.AreEqual(Logradouro_Original, cliente.Logradouro);
            Console.WriteLine($"Logradouro_Original: " + cliente.Logradouro);
            
            cliente.Logradouro = Mudando_Logradouro1;
            cliente.SalvarEstadoAtualLembranca();
            Console.ReadKey();


            Assert.True(cliente.VerifContaminado);
            Assert.AreEqual(Mudando_Logradouro1, cliente.Logradouro);
            Console.WriteLine($"Logradouro_1: "+ cliente.Logradouro);
            cliente.Logradouro = Mudando_Logradouro2;
            cliente.SalvarEstadoAtualLembranca();
            Console.ReadKey();


            Assert.True(cliente.VerifContaminado);
            Assert.AreEqual(Mudando_Logradouro2, cliente.Logradouro);
            Console.WriteLine($"Logradouro_2: " + cliente.Logradouro);
            cliente.Logradouro = Mudando_Logradouro3;            
            Console.ReadKey();


            Assert.True(cliente.VerifContaminado);
            Assert.AreEqual(Mudando_Logradouro3, cliente.Logradouro);
            Console.WriteLine($"Logradouro_3: " + cliente.Logradouro);
            Console.WriteLine();
            Console.WriteLine("Volto do Logradouro_3 para Logradouro_2: ");
            cliente.VoltarAoValorAnterior();            
            


            Assert.True(cliente.VerifContaminado);
            Assert.AreEqual(Mudando_Logradouro2, cliente.Logradouro);
            Console.WriteLine(cliente.Logradouro);
            Console.WriteLine();
            Console.WriteLine("Volto do Logradouro_2 para Logradouro_1: "); 
            cliente.VoltarAoValorAnterior();


            Assert.True(cliente.VerifContaminado);
            Assert.AreEqual(Mudando_Logradouro1, cliente.Logradouro);
            Console.WriteLine(cliente.Logradouro);
            Console.WriteLine();
            Console.WriteLine("Volto do Logradouro_1 para Logradouro_Original: ");
            cliente.ReverterVOriginal();


            Assert.False(cliente.VerifContaminado);
            Assert.AreEqual(Logradouro_Original, cliente.Logradouro);
            Console.WriteLine(cliente.Logradouro);

        }

        static void Main(string[] args)
        {
            Test();

        }

    }
}