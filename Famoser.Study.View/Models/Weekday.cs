using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Famoser.Study.Business.Models;

namespace Famoser.Study.View.Models
{
    public class WeekDay
    {
        public WeekDay(string name, DayOfWeek dayOfWeek)
        {
            Name = name;
            DayOfWeek = dayOfWeek;
        }

        public string Name { get; }
        public DayOfWeek DayOfWeek { get; }

        public ObservableCollection<Lecture> Lectures { get; } = new ObservableCollection<Lecture>();

        public void AddLecture(Lecture lecture)
        {
            var found = false;
            for (int i = 0; i < Lectures.Count && !found; i++)
            {
                if (Lectures[i].StartTime > lecture.StartTime)
                {
                    Lectures.Insert(i, lecture);
                    found = true;
                }
            }
            if (!found)
            {
                Lectures.Add(lecture);
            }
        }

        public void RemoveLecture(Lecture lecture)
        {
            if (Lectures.Contains(lecture))
            {
                Lectures.Remove(lecture);
            }
        }
    }
}
