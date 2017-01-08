using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Famoser.SyncApi.Models;
using Famoser.SyncApi.Models.Interfaces;
using Famoser.SyncApi.Repositories.Interfaces;

namespace Famoser.Study.Business.Services.Interfaces
{
    public interface IApiService
    {
        IApiRepository<T> ResolveRepository<T>() where T : ISyncModel;
    }
}
