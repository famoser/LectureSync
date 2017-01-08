using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Famoser.Study.Business.Models;
using Famoser.SyncApi.Properties;

namespace Famoser.Study.Business.Repositories.Interfaces
{
    public interface ICourseRepository
    {
        ObservableCollection<Course> GetCoursesLazy();
        Task<bool> SaveCourseAsync(Course course);
        Task<bool> RemoveCourseAsync(Course course);
        Task<bool> SyncAsnyc();
    }
}
