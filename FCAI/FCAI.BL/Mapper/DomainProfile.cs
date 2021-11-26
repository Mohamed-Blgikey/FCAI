using AutoMapper;
using FCAI.BL.Model;
using FCAI.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCAI.BL.Mapper
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<Department, DepartmentVM>();
            CreateMap<DepartmentVM, Department>();


            CreateMap<Student, StudentVM>();
            CreateMap<StudentVM, Student>();

            CreateMap<Instractor, InstractorVM>();
            CreateMap<InstractorVM, Instractor>();

            CreateMap<Course, CourseVM>();
            CreateMap<CourseVM, Course>();

            CreateMap<Topic, TopicVM>();
            CreateMap<TopicVM, Topic>();

            CreateMap<CourseInst, CourseInstVM>();
            CreateMap<CourseInstVM, CourseInst>();

        }
    }
}
