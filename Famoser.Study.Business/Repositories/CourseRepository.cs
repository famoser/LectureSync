using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
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

        private ObservableCollection<Course> _courses;
        public ObservableCollection<Course> GetCoursesLazy()
        {
            if (_courses == null)
            {
                _courses = _repository.GetAllLazy();
                _courses.CollectionChanged += CoursesOnCollectionChanged;
            }
            return _courses;
        }

        private void CoursesOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs)
        {
            switch (notifyCollectionChangedEventArgs.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (var newItem in notifyCollectionChangedEventArgs.NewItems)
                    {
                        var course = newItem as Course;
                        if (course != null)
                            foreach (var courseLecture in course.Lectures)
                            {
                                courseLecture.Course = course;
                            }
                    }
                    break;
            }
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
