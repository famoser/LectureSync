using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Famoser.Study.Business.Models;
using Famoser.Study.Business.Repositories.Interfaces;
using Famoser.Study.Business.Services.Interfaces;
using Famoser.SyncApi.Repositories;
using Famoser.SyncApi.Repositories.Interfaces;

namespace Famoser.Study.Business.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly IApiRepository<Course> _repository;

        public CourseRepository(IApiService apiService)
        {
            _repository = apiService.ResolveRepository<Course>();
        }

        public ObservableCollection<Course> GetCoursesLazy()
        {
            return _repository.GetAllLazy();
        }

        public Task<bool> SaveCourseAsync(Course course)
        {
            return _repository.SaveAsync(course);
        }

        public Task<bool> RemoveCourseAsync(Course course)
        {
            return _repository.RemoveAsync(course);
        }

        public Task<bool> SyncAsnyc()
        {
            return _repository.SyncAsync();
        }
    }
}
