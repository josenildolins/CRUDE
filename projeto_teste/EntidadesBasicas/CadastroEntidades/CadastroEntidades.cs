using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using EntidadesBasicas;
using ProjetoNegocio;

namespace CadastroEntidades
{
    class CadastroEntidades
    {
        private static PlanoNegocio _planoNegocio;
        private static string valor;
        private static string nomePlano;

        static void Main(string[] args)
        {
            CadastroEntidades._planoNegocio = new PlanoNegocio();
            ChamaTelaInicial();

            while (valor != "0")
            {
                switch (valor)
                {
                    case "1":
                        CadastrarPlano();
                        break;
                    case "2":
                        ListarTodosOsPlanos();
                        break;
                    case "3":
                        BuscarPlanoPornome();
                        break;
                    case "4":
                        BuscarPlanosPorCobertura();
                        break;
                    case "5":
                        BuscarPlanosPorClassificacao();
                        break;
                    case "6":
                        RemoverPlano();
                        break;
                    case "7":
                        CadastrarCobertura();
                        break;
                    case "8":
                        ListarCobertura();
                        break;
                    case "9":
                        CadastrarClassificacao();
                        break;
                    case "10":
                        ListarTodasClassificacoes();
                        break;
                }

                Console.Clear();
                ChamaTelaInicial();
            }
            

        }

        private static void BuscarPlanoPornome()
        {
            Console.WriteLine("Digite o nome do Plano");
            string nome = Console.ReadLine();
            List<Plano> buscaPlanoPornome = _planoNegocio.ConsultarPlanosPorNome(nome);
            Console.Clear();

            foreach (Plano planos in buscaPlanoPornome )
            {
                Console.WriteLine($"ID: {planos.Id}");
                Console.WriteLine($"Nome: {planos.Nome}");
                Console.WriteLine($"Codigo ANS: {planos.CodigoANS}");
                Console.WriteLine($"Cobertura: {planos.IDCobertura}");
                Console.WriteLine($"Classificacao: {planos.IDClassificacaoPlano}");
                Console.WriteLine("=======================================");
                
            }

            Console.WriteLine();
            Console.WriteLine("===============================================");
            Console.WriteLine("Pressione Enter para Voltar pro Menu Principal");
            Console.ReadLine();
        }

        private static void  ListarTodasClassificacoes()
        {
            List<ClassificacaoPlano> todasClassificacoes = _planoNegocio.ConsultarClassificacoes();

            foreach (ClassificacaoPlano classificacoes in todasClassificacoes )
            {
                Console.WriteLine("=======================================");
                Console.WriteLine($"ID: {classificacoes.IDClassificacaoPlano}");
                Console.WriteLine($"Nome: {classificacoes.Descricao}");
                Console.WriteLine("=======================================");
            }

            Console.WriteLine();
            Console.WriteLine("===============================================");
            Console.WriteLine("Pressione Enter para Voltar pro Menu Principal");
            Console.ReadLine();
        }

        private static void CadastrarClassificacao()
        {
            Console.WriteLine(new string('=', 20));
            Console.WriteLine("Digite os dados da Classificacao");
            Console.WriteLine(new string('=', 20));

            Console.WriteLine("ID: ");
            int idClassificacao= Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Descricao: ");
            string descricao = Console.ReadLine();

            _planoNegocio.CadastrarClassificacaoPlano(new ClassificacaoPlano
            {
                IDClassificacaoPlano = idClassificacao,
                Descricao = descricao
            });
        }

        private static void ListarCobertura()
        {
            List<CoberturaPlano> todasCorbeturas = _planoNegocio.ConsultarCobertura();

            foreach (CoberturaPlano cobertura in todasCorbeturas)
            {

                Console.WriteLine("=======================================");
                Console.WriteLine($"ID: {cobertura.IDCorbetura}");
                Console.WriteLine($"Nome: {cobertura.Nome}");
                Console.WriteLine("=======================================");
            }
            Console.WriteLine();
            Console.WriteLine("===============================================");
            Console.WriteLine("Pressione Enter para Voltar pro Menu Principal");
            Console.ReadLine();
        }

        private static void CadastrarCobertura()
        {
            Console.WriteLine(new string('=', 20));
            Console.WriteLine("Digite os dados da Cobertura");
            Console.WriteLine(new string('=', 20));
            Console.WriteLine("Nome: ");
            string nomeCobertura = Console.ReadLine();
            Console.WriteLine("ID: ");
            int idCobertura = Convert.ToInt32(Console.ReadLine());

            _planoNegocio.CadastrarCobertura(new CoberturaPlano
            {
                 Nome = nomeCobertura,
                IDCorbetura = idCobertura
            });
            
        }

        private static void RemoverPlano()
        {
            Console.WriteLine("Digite a ID do plano");
            int idPlano = Convert.ToInt32(Console.ReadLine());
             _planoNegocio.Deletar(idPlano);

        }

        private static void BuscarPlanosPorClassificacao()
        {
           Console.WriteLine("Digite a ID da Classificacao do plano");
            int idClassificacao = Convert.ToInt32(Console.ReadLine());

            List<Plano> classificacao = _planoNegocio.ConsultarPlanosPorClassificacao(idClassificacao);


            foreach (Plano plano in classificacao)
            {
                Console.WriteLine("=======================================");
                Console.WriteLine($"ID: {plano.Id}");
                Console.WriteLine($"Nome: {plano.Nome}");
                Console.WriteLine($"Codigo ANS: {plano.CodigoANS}");
                Console.WriteLine($"Cobertura: {plano.IDCobertura}");
                Console.WriteLine($"Classificacao: {plano.IDClassificacaoPlano}");
                Console.WriteLine("=======================================");
            }
            Console.WriteLine();
            Console.WriteLine("===============================================");
            Console.WriteLine("Pressione Enter para Voltar pro Menu Principal");
            Console.ReadLine();
        }

        private static void BuscarPlanosPorCobertura()
        {
            Console.WriteLine("Digite o código da Cobertura do plano");
            int idCobertura = Convert.ToInt32(Console.ReadLine());
            List<Plano> buscarPlanosPorCobertura = _planoNegocio.ConsultarPlanosPorCobertura(idCobertura);


            foreach (Plano cobertura in  buscarPlanosPorCobertura)
            {
                Console.WriteLine("=======================================");
                Console.WriteLine($"ID: {cobertura.Id}");
                Console.WriteLine($"Nome: {cobertura.Nome}");
                Console.WriteLine($"Codigo ANS: {cobertura.CodigoANS}");
                Console.WriteLine($"Cobertura: {cobertura.IDCobertura}");
                Console.WriteLine($"Classificacao: {cobertura.IDClassificacaoPlano}");
                Console.WriteLine("=======================================");
            }
            Console.WriteLine();
            Console.WriteLine("===============================================");
            Console.WriteLine("Pressione Enter para Voltar pro Menu Principal");
            Console.ReadLine();

        }

        
        private static void ListarTodosOsPlanos()
        {
            List<Plano> todosOsPlanos = _planoNegocio.ConsultarPlanos();

            foreach (Plano plano in todosOsPlanos)
            {
                Console.WriteLine("=======================================");
                Console.WriteLine($"ID: {plano.Id}");
                Console.WriteLine($"Nome: {plano.Nome}");
                Console.WriteLine($"Codigo ANS: {plano.CodigoANS}");
                Console.WriteLine($"Cobertura: {plano.IDCobertura}");
                Console.WriteLine($"Classificacao: {plano.IDClassificacaoPlano}");
                Console.WriteLine("=======================================");
            }

            Console.WriteLine();
            Console.WriteLine("===============================================");
            Console.WriteLine("Pressione Enter para Voltar pro Menu Principal");
            Console.ReadLine();
        }
       private static void CadastrarPlano()
        {
            Console.WriteLine(new string('=', 20));
            Console.WriteLine("Digite os dados do Plano");
            Console.WriteLine(new string('=', 20));

            Console.WriteLine("Nome: ");
            string nomePlano = Console.ReadLine();
            Console.WriteLine("Codigo ANS: ");
            string codigoAns = Console.ReadLine();
            Console.WriteLine("Cobertura: ");
            int idCobertura = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Classificação: ");
            int idClassificacao = Convert.ToInt32(Console.ReadLine());

            _planoNegocio.CadastrarPlano(new Plano
            {
                Nome = nomePlano,
                CodigoANS = codigoAns,
                IDClassificacaoPlano = idClassificacao,
                IDCobertura = idCobertura
            });
        }

        public static void ChamaTelaInicial()
        {
            Console.WriteLine("+-----------------------------------------------------+\r\n| " +
                              "Seja bem-vindo ao Josebugs" +
                              "\r\n+-----------------------------------------------------+");
            Console.WriteLine(" ");
            Console.WriteLine("Escolha uma das opções");
            Console.WriteLine(" ");
            Console.WriteLine("Menu:");
            Console.WriteLine(" ");
            Console.WriteLine(" 1) Cadastrar Plano ");
            Console.WriteLine(" 2) Listar Todos os Planos ");
            Console.WriteLine(" 3) Buscar Planos por Nome");
            Console.WriteLine(" 4) Buscar Planos por Cobertura ");
            Console.WriteLine(" 5) Buscra Planos por Classificação");
            Console.WriteLine(" 6) Remover Plano");
            Console.WriteLine("----------------------------------------------------- ");
            Console.WriteLine(" 7) Cadastrar Cobertura ");
            Console.WriteLine(" 8) Listar Todas as Coberturas");
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine(" 9) Cadastrar Classificação ");
            Console.WriteLine(" 10) Listar Todas as Classificações ");
            Console.WriteLine(" 0) Sair ");
            Console.WriteLine();

            Console.WriteLine("Digite uma Opção: ");
            valor = Console.ReadLine();
            Console.Clear();
        }
    }
}