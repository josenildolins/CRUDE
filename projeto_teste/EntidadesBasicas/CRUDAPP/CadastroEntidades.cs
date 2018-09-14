using System;
using System.Collections.Generic;
using EntidadesBasicas;
using ProjetoNegocio;

namespace CRUDAPP
{
    class CadastroEntidades
    {
        private static PlanoNegocio _planoNegocio;
        private static string valor;
        //private static string nomePlano;

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
                    case "11":
                        AlterarPlano();
                        break;
                }

                ChamaTelaInicial();
            }


        }

        private static void AlterarPlano()
        {

            Console.WriteLine(new string('=', 50));
            Console.WriteLine("Digite a ID do Plano qque deseja Modificar");
            Console.WriteLine(new string('=', 50));

            Console.WriteLine("ID: ");
            int idPlano = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            Console.WriteLine(new string('=', 50));
            Console.WriteLine("Digite os dados do novo Plano");
            Console.WriteLine(new string('=', 50));
            Console.WriteLine("Nome: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Codigo ANS: ");
            string codigoANS = Console.ReadLine();
            Console.WriteLine("Cobertura: ");
            int idCobertura = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Classificação: ");
            int idClassificacaoPlano = Convert.ToInt32(Console.ReadLine());

            _planoNegocio.AlterarPlano(new Plano
            {
                IdPlano = idPlano,
                IdClassificacaoPlano = idClassificacaoPlano,
                Nome = nome,
                IdCobertura = idCobertura,
                CodigoAns = codigoANS
            });
        }

        private static void BuscarPlanoPornome()
        {
            Console.WriteLine("Digite o nome do Plano");
            string nome = Console.ReadLine();
            List<Plano> buscaPlanoPornome = _planoNegocio.ConsultarPlanosPorNome(nome);
            Console.Clear();

            foreach (Plano planos in buscaPlanoPornome)
            {
                Console.WriteLine(new string('=', 50));
                Console.WriteLine($"ID: {planos.IdPlano}");
                Console.WriteLine($"Nome: {planos.Nome}");
                Console.WriteLine($"Codigo ANS: {planos.CodigoAns}");
                Console.WriteLine($"Cobertura: {planos.IdCobertura}");
                Console.WriteLine($"Classificacao: {planos.IdClassificacaoPlano}");
                Console.WriteLine(new string('=', 50));
            }

            Console.WriteLine();
            Console.WriteLine(new string('=', 50));
            Console.WriteLine("Pressione Enter para Voltar pro Menu Principal");
            Console.WriteLine(new string('=', 50));
            Console.ReadLine();
        }

        private static void ListarTodasClassificacoes()
        {
            List<ClassificacaoPlano> todasClassificacoes = _planoNegocio.ConsultarClassificacoes();

            foreach (ClassificacaoPlano classificacoes in todasClassificacoes)
            {
                Console.WriteLine(new string('=', 50));
                Console.WriteLine($"ID: {classificacoes.IdClassificacaoPlano}");
                Console.WriteLine($"Nome: {classificacoes.Descricao}");
                Console.WriteLine(new string('=', 50));
            }

            Console.WriteLine();
            Console.WriteLine(new string('=', 50));
            Console.WriteLine("Pressione Enter para Voltar pro Menu Principal");
            Console.ReadLine();
        }

        private static void CadastrarClassificacao()
        {
            Console.WriteLine(new string('=', 50));
            Console.WriteLine("Digite os dados da Classificacao");
            Console.WriteLine(new string('=', 50));

            Console.WriteLine("ID: ");
            int idClassificacao = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Descricao: ");
            string descricao = Console.ReadLine();

            _planoNegocio.CadastrarClassificacaoPlano(new ClassificacaoPlano
            {
                IdClassificacaoPlano = idClassificacao,
                Descricao = descricao
            });
        }

        private static void ListarCobertura()
        {
            List<CoberturaPlano> todasCorbeturas = _planoNegocio.ConsultarCobertura();

            foreach (CoberturaPlano cobertura in todasCorbeturas)
            {

                Console.WriteLine(new string('=', 50));
                Console.WriteLine($"ID: {cobertura.IdCobertura}");
                Console.WriteLine($"Nome: {cobertura.Nome}");
                Console.WriteLine(new string('=', 50));
            }
            Console.WriteLine();
            Console.WriteLine(new string('=', 50));
            Console.WriteLine("Pressione Enter para Voltar pro Menu Principal");
            Console.ReadLine();
        }

        private static void CadastrarCobertura()
        {
            Console.WriteLine(new string('=', 50));
            Console.WriteLine("Digite os dados da Cobertura");
            Console.WriteLine(new string('=', 50));
            Console.WriteLine("Nome: ");
            string nomeCobertura = Console.ReadLine();


            _planoNegocio.CadastrarCobertura(new CoberturaPlano
            {
                Nome = nomeCobertura,

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
                Console.WriteLine(new string('=', 50));
                Console.WriteLine($"ID: {plano.IdPlano}");
                Console.WriteLine($"Nome: {plano.Nome}");
                Console.WriteLine($"Codigo ANS: {plano.CodigoAns}");
                Console.WriteLine($"Cobertura: {plano.IdCobertura}");
                Console.WriteLine($"Classificacao: {plano.IdClassificacaoPlano}");
                Console.WriteLine(new string('=', 50));
            }
            Console.WriteLine();
            Console.WriteLine(new string('=', 50));
            Console.WriteLine("Pressione Enter para Voltar pro Menu Principal");
            Console.WriteLine(new string('=', 50));
            Console.ReadLine();
        }

        private static void BuscarPlanosPorCobertura()
        {
            Console.WriteLine("Digite o código da Cobertura do plano");
            int idCobertura = Convert.ToInt32(Console.ReadLine());
            List<Plano> buscarPlanosPorCobertura = _planoNegocio.ConsultarPlanosPorCobertura(idCobertura);


            foreach (Plano cobertura in buscarPlanosPorCobertura)
            {
                Console.WriteLine(new string('=', 50));
                Console.WriteLine($"ID: {cobertura.IdPlano}");
                Console.WriteLine($"Nome: {cobertura.Nome}");
                Console.WriteLine($"Codigo ANS: {cobertura.CodigoAns}");
                Console.WriteLine($"Cobertura: {cobertura.IdCobertura}");
                Console.WriteLine($"Classificacao: {cobertura.IdClassificacaoPlano}");
                Console.WriteLine(new string('=', 50));
            }
            Console.WriteLine();
            Console.WriteLine(new string('=', 50));
            Console.WriteLine("Pressione Enter para Voltar pro Menu Principal");
            Console.WriteLine(new string('=', 50));
            Console.ReadLine();

        }


        private static void ListarTodosOsPlanos()
        {
            List<Plano> todosOsPlanos = _planoNegocio.ConsultarPlanos();

            foreach (Plano plano in todosOsPlanos)
            {
                Console.WriteLine(new string('=', 50));
                Console.WriteLine($"ID: {plano.IdPlano}");
                Console.WriteLine($"Nome: {plano.Nome}");
                Console.WriteLine($"Codigo ANS: {plano.CodigoAns}");
                Console.WriteLine($"Cobertura: {plano.IdCobertura} - {plano.Cobertura.Nome}");
                Console.WriteLine($"Classificacao: {plano.IdClassificacaoPlano} - {plano.ClassificacaoPlano.Descricao}");
                Console.WriteLine(new string('=', 50));
            }

            Console.WriteLine();
            Console.WriteLine(new string('=', 50));
            Console.WriteLine("Pressione Enter para Voltar pro Menu Principal");
            Console.WriteLine(new string('=', 50));
            Console.ReadLine();
        }
        private static void CadastrarPlano()
        {
            Console.WriteLine(new string('=', 50));
            Console.WriteLine("Digite os dados do Plano");
            Console.WriteLine(new string('=', 50));

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
                CodigoAns = codigoAns,
                IdClassificacaoPlano = idClassificacao,
                IdCobertura = idCobertura
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
            Console.WriteLine(" 11) Alterar Plano ");
            Console.WriteLine(" 0) Sair ");
            Console.WriteLine();

            Console.WriteLine("Digite uma Opção: ");
            valor = Console.ReadLine();
            Console.Clear();
        }
    }
}
