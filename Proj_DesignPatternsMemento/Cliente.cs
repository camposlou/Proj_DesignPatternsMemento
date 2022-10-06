using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj_DesignPatternsMemento
{
    //Classe "Original" 
    public class Cliente
    {
       
        private readonly List<LembrancaCliente> lembrclientes = new List<LembrancaCliente>();

        //Objetos que queremos acompanhar seu histórico
        public int ID { get; }
        public string Nome { get; set; }
        public string Logradouro { get; set; }
        public string Cidade { get; set; }
        public string CEP { get; set; }
        
        public Cliente(int id, string nome, string logradouro, string cidade, string cep)
        {
            ID = id;
            Nome = nome;
            Logradouro = logradouro;
            Cidade = cidade;
            CEP = cep;

                       
            SalvarEstadoAtualLembranca();
        }  
        //Classe Memento - Clone
        private class LembrancaCliente
        {
            public string Nome { get; }
            public string Logradouro { get; }
            public string Cidade { get; }
            public string CEP { get; }

                        
            public LembrancaCliente(Cliente cliente)
            {
                Nome = cliente.Nome;
                Logradouro = cliente.Logradouro;
                Cidade = cliente.Cidade;
                CEP = cliente.CEP;
            }

        }
        #region Funções Caretaker(Zelador)          
        public void SalvarEstadoAtualLembranca()
        {
            
            lembrclientes.Add(new LembrancaCliente(this));      //Adicionar um novo objeto LembrancaCliente, passando o objeto atual (this) para a variável lembrancascliente, para fazer possíveis reversões.
        }                     
      
        public void VoltarAoValorAnterior()
        {
            var lastlembranca = lembrclientes.LastOrDefault();

            if(lastlembranca != null)
            {                
                DefinirValoresLembranca(lastlembranca);                 //Redefinir os valores da prop do objeto "Cliente atual" para os valores da última lembrança.
               
                if (lastlembranca != lembrclientes.First())             //Remove a última lembrança, a menos que ela seja a primeira.
                {
                    lembrclientes.Remove(lastlembranca);
                }

            }
           
        }
        public void ReverterVOriginal()
        {

            var primeiraLembranca = lembrclientes.FirstOrDefault();     //Obtém a primeira lembrança (sempre deve haver uma) de "lembrancacliente" - FirstOrDefault - Primeiro/Padrão

            //Verifica se há nulo apenas para ser seguro
            if (primeiraLembranca != null)
            {
                DefinirValoresLembranca(primeiraLembranca);                     //Definir os valores da propriedade de lembranca (memento), passando a lembranca


                if (lembrclientes.Count > 1)                                 //Remove todas as lembranças exceto a primeira
                {

                    lembrclientes.RemoveRange(1, lembrclientes.Count - 1);   //Limpa toda lembrança que for maior que a primeira, pois estamos revertendo o estado atual para a primeira lembrança,
                                                                             //voltamos para primeira alteração, por isso não precisamos de alterações extras.
                }
            }
        }
        private void DefinirValoresLembranca(LembrancaCliente lembranca)
        {
            Nome = lembranca.Nome;
            Logradouro = lembranca.Logradouro;
            Cidade = lembranca.Cidade;                        //Recebe uma lembrança (memento), lê os valores e os defini nas propriedades do objeto atual "Class Clone"
            CEP = lembranca.CEP;
        }
        #endregion

        public bool VerifContaminado
        {
            get
            {
                
                if (lembrclientes.Count == 0)                              
                {                                                                          
                    return false;

                }
                //EstadoAtual  !=  //EstadoOriginal
                return Nome != lembrclientes.First().Nome ||
                       Logradouro != lembrclientes.First().Logradouro ||
                       Cidade != lembrclientes.First().Cidade ||
                       CEP != lembrclientes.First().CEP;
            }
        }















    }
}










