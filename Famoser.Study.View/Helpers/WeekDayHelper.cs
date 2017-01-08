using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Famoser.Study.Business.Models;
using Famoser.Study.View.Models;

namespace Famoser.Study.View.Helpers
{
    public class WeekDayHelper
    {
        private readonly ObservableCollection<Course> _courses;
        private readonly ObservableCollection<WeekDay> _weekDays = new ObservableCollection<WeekDay>();
        private readonly Dictionary<DayOfWeek, WeekDay> _weekDayDictionary = new Dictionary<DayOfWeek, WeekDay>();

        public WeekDayHelper(ObservableCollection<Course> courses)
        {
            _courses = courses;
            var today = new WeekDay("Today " + DateTime.Now.DayOfWeek, DateTime.Now.DayOfWeek);
            _weekDays.Add(today);
            _weekDayDictionary[DateTime.Now.DayOfWeek] = today;
            foreach (var course in courses)
            {
                AddCourse(course);
            }
            courses.CollectionChanged += CoursesOnCollectionChanged;
        }

        private void CoursesOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs)
        {
            switch (notifyCollectionChangedEventArgs.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (var newItem in notifyCollectionChangedEventArgs.NewItems)
                    {
                        AddCourse(newItem as Course);
                    }
                    break;
                case NotifyCollectionChangedAction.Remove:
                    foreach (var oldItem in notifyCollectionChangedEventArgs.OldItems)
                    {
                        RemoveCourse(oldItem as Course);
                    }
                    break;
                case NotifyCollectionChangedAction.Replace:
                    foreach (var oldItem in notifyCollectionChangedEventArgs.OldItems)
                    {
                        RemoveCourse(oldItem as Course);
                    }
                    foreach (var newItem in notifyCollectionChangedEventArgs.NewItems)
                    {
                        AddCourse(newItem as Course);
                    }
                    break;
                case NotifyCollectionChangedAction.Reset:
                    foreach (var value in _weekDayDictionary.Values)
                    {
                        value.Lectures.Clear();
                    }
                    foreach (var course in _courses)
                    {
                        AddCourse(course);
                    }
                    break;
            }
        }

        private void AddCourse(Course course)
        {
            foreach (var courseLecture in course.Lectures)
            {
                courseLecture.Course = course;
                if (!_weekDayDictionary.ContainsKey(courseLecture.DayOfWeek))
                {
                    var weekDay = new WeekDay(DateTime.Now.DayOfWeek.ToString(), DateTime.Now.DayOfWeek);
                    _weekDayDictionary[courseLecture.DayOfWeek] = weekDay;
                    var found = false;
                    for (int i = 0; i < _weekDays.Count && !found; i++)
                    {
                        if (_weekDays[i].DayOfWeek > weekDay.DayOfWeek)
                        {
                            _weekDays.Insert(i, weekDay);
                            found = true;
                        }
                    }
                    if (!found)
                    {
                        _weekDays.Add(weekDay);
                    }
                }

                _weekDayDictionary[courseLecture.DayOfWeek].AddLecture(courseLecture);
            }
        }

        private void RemoveCourse(Course course)
        {
            foreach (var courseLecture in course.Lectures)
            {
                courseLecture.Course = course;
                if (_weekDayDictionary.ContainsKey(courseLecture.DayOfWeek))
                {
                    _weekDayDictionary[courseLecture.DayOfWeek].RemoveLecture(courseLecture);
                    if (_weekDayDictionary[courseLecture.DayOfWeek].Lectures.Count == 0)
                    {
                        _weekDays.Remove(_weekDayDictionary[courseLecture.DayOfWeek]);
                        _weekDayDictionary.Remove(courseLecture.DayOfWeek);
                    }
                }
            }
        }

        public ObservableCollection<WeekDay> GetWeekDays()
        {
            return _weekDays;
        }

        public WeekDay GetToday()
        {
            return _weekDayDictionary[DateTime.Now.DayOfWeek];
        }
    }
}
