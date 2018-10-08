using System;
using System.Threading.Tasks;
using JosenBug.Contracts;
using JosenBug.Dto;

namespace JosenBug.services
{
    public class ClassificacaoAppService : JosenBugAppServiceBase, IClassificacaoAppService
    {
        public Task<ClassificacaoInputDto> InserirClassificacao()
        {
            throw new NotImplementedException();
        }
    }
}
