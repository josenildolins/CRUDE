﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;

namespace JosenBug.Contracts
{
   public interface ICoberturaAppService: IApplicationService
   {
       Task<int> inserirCobertura();
   }
}
