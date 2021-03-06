﻿using System.Collections.Generic;
using System.Linq;
using EntidadesBasicas;
using Microsoft.EntityFrameworkCore;
using Repositorio.Contracts;
using Repositorio.EF;

namespace Repositorio
{
    public class PlanoRepositorio : IPlanoRepository
    {

        public void inserir(Plano plano)
        {
            using (var context = new CrudDbContext())
            {
                context.Planos.Add(plano);
                context.SaveChanges();
            }

        }

        public void Deletar(Plano entidade)
        {
            using (var context = new CrudDbContext())
            {
                context.Remove(entidade);
                context.SaveChanges();
            }
        }

        public void Deletar(int idPlano)
        {

            var planos = new Plano()
            {
                Id = idPlano
            };


            using (var context = new CrudDbContext())
            {
                context.Remove(planos);
                context.SaveChanges();
            }
        }

        public List<Plano> ConsultarTodos()
        {
            List<Plano> consultarPlanos;

            using (var context = new CrudDbContext())
            {

                consultarPlanos = context.Planos
                    .Include(x => x.ClassificacaoPlano)
                    .Include(x => x.Cobertura)
                    .ToList();

            }
            return consultarPlanos;
        }

        public void Atualizar(Plano entidade)
        {
            using (var context = new CrudDbContext())
            {

                context.Planos.Update(entidade);
                context.SaveChanges();

            }
        }

        public List<Plano> ConsultarPlanosPorNome(string nomePlano)
        {
            List<Plano> consultarPlanosPorNome;
            using (var context = new CrudDbContext())
            {

                consultarPlanosPorNome = context.Planos.Where(p => p.Nome.Contains(nomePlano)).ToList();

            }
            return consultarPlanosPorNome;

        }

        public List<Plano> ConsultarPlanosPorCobertura(int idCobertura)
        {
            List<Plano> consultarPlanoPorCobertura;

            using (var context = new CrudDbContext())
            {

                consultarPlanoPorCobertura = context.Planos
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
                    context.Planos
                        .Where(p => p.IdClassificacaoPlano == idClassificacao)
                        .ToList();
            }

            return consultarPlanosPorClassificacao;
        }


    }
}
