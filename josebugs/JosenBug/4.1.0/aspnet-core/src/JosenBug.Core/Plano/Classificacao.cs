using System;
using System.Collections.Generic;
using System.Text;
using Abp.Domain.Entities;

namespace JosenBug.Plano
{
    public class Classificacao : Entity
    {
        public Classificacao()
        {
            
        }
        public ClassificacaoOutputDto Nome { get; set; }
    }
}
