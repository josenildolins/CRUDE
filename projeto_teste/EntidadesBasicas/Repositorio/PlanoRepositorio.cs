using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using EntidadesBasicas;
using Microsoft.EntityFrameworkCore;
using Remotion.Linq.Clauses;
using Repositorio.EF;

namespace Repositorio
{
    public class PlanoRepositorio
    {
        private static  readonly  List<Plano> PlanosMemoriaBd = new List<Plano>();

        public void Inserir(Plano plano) 
        {
            using (var context = new CrudDbContext()) 
            {
                context.plano.Add(plano);
                context.SaveChanges();
            }
           
        }

        public void Deletar(int idPlano) 
        {
            
          
            var planos = new Plano()
            {
                IdPlano = idPlano
            };

            
            using (var context = new CrudDbContext())
            {
                context.Remove<Plano>(planos);
                context.SaveChanges();
            }
        }

        public void AlterarPlano(Plano plano)
        {
           
            
                using (var context = new CrudDbContext())
                {

                    context.plano.Update(plano);
                    context.SaveChanges();

                }
        }

        public List<Plano> ConsultarPlanos() 
        {
            List<Plano> consultarPlanos;
            
            using (var context = new CrudDbContext())
            {
                var query = from plano in context.plano
                                join classificacao in context.ClassificacaoPlano on plano.IdClassificacaoPlano equals classificacao
                                    .IdClassificacaoPlano
                                join cobertura in context.CoberturaPlano on plano.IdCobertura equals cobertura.IdCobertura
                                select plano;

                consultarPlanos = query
                    .Include(x => x.ClassificacaoPlano)
                    .Include(x => x.Cobertura)
                    .ToList();

            }
            return consultarPlanos;

        }

        public List<Plano> ConsultarPlanosPorNome(string nomePlano) 
        {
            List<Plano> consultarPlanosPorNome;
            using (var context = new CrudDbContext())
            {
                consultarPlanosPorNome = context.plano.Where(p => p.Nome == nomePlano).ToList();
                
            }

            return consultarPlanosPorNome;
           
        }

        public List<Plano> ConsultarPlanosPorCobertura(int idCobertura) 
        {
            List<Plano> consultarPlanoPorCobertura ;
           
            using (var context = new CrudDbContext())
            {
                
                consultarPlanoPorCobertura = context.plano
                    .Where(p => p.IdCobertura == idCobertura)
                    .ToList();
            }

            return consultarPlanoPorCobertura;

        }

        public List<Plano> ConsultarPlanosPorClassificacao(int idClassificacao)
        {
            List<Plano> consultarPlanosPorClassificacao;

            using (var context = new CrudDbContext())
            {
                consultarPlanosPorClassificacao =
                    context.plano
                        .Where(p => p.IdClassificacaoPlano == idClassificacao)
                        .ToList();
            }

                return consultarPlanosPorClassificacao;
        }

        
    }
}