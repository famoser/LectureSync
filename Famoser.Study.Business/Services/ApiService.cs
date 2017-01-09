using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Famoser.FrameworkEssentials.Services.Interfaces;
using Famoser.Study.Business.Services.Interfaces;
using Famoser.SyncApi.Helpers;
using Famoser.SyncApi.Models;
using Famoser.SyncApi.Models.Interfaces;
using Famoser.SyncApi.Repositories.Interfaces;

namespace Famoser.Study.Business.Services
{
    public class ApiService : IApiService
    {
        private readonly SyncApiHelper _helper;
        public ApiService(IStorageService storageService)
        {
            _helper = new SyncApiHelper(storageService, "mass_pass", "https://testing.syncapi.famoser.ch");
        }

        public IApiRepository<T> ResolveRepository<T>() where T : ISyncModel
        {
            return _helper.ResolveRepository<T>();
        }
    }
}
