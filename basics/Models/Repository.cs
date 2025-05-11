using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace basics.Models
{
    public class Repository
    {
        private static readonly List<Course> _courses = new List<Course>();

        static Repository()
        {
            _courses = new List<Course>{
                new Course(){
                Id=1,
                Title="Aspnet Course",
                Description=".net hoş geldiniz",
                Image="pic1.jpg",
                Tags = new string[]{"aspnet", "web geliştirme"},
                IsActive=true,
                IsHome=true
                },
            new Course(){Id=2, Title="Flutter Course", Description="dart hoş geldiniz", Image="pic2.jpg", Tags = new string[]{"dart", "uygulama geliştirme"},IsActive=true, IsHome=false},
            new Course(){Id=3, Title="Pyhton Course", Description="veri hoş geldiniz", Image="pic3.jpg", Tags = new string[]{"python", "veri bilimi"},IsActive=false, IsHome=true},
            };
        }

        public static List<Course> Courses
        {
            get
            {
                return _courses;
            }
        }

        public static Course? GetById(int? id)
        {
            return _courses.FirstOrDefault(c => c.Id == id);
        }
    }
}