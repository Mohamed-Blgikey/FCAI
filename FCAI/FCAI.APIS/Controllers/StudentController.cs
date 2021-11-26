using AutoMapper;
using FCAI.BL.Helper;
using FCAI.BL.Interface;
using FCAI.BL.Model;
using FCAI.DAL.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FCAI.APIS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRep studentRep;
        private readonly IMapper mapper;

        public StudentController(IStudentRep studentRep, IMapper mapper)
        {
            this.studentRep = studentRep;
            this.mapper = mapper;
        }
        #region APIS
        [HttpGet]
        [Route("~/api/getStudents")]
        public IActionResult GetStudents()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var model = mapper.Map<IEnumerable<StudentVM>>(studentRep.Get());

                    return Ok(new ApiResponse<IEnumerable<StudentVM>>()
                    {
                        Code = "200",
                        Status = "OK",
                        Message = "Student Data",
                        Data = model
                    });
                }
                else
                {
                    return NotFound(new ApiResponse<string>()
                    {
                        Code = "404",
                        Status = "Error",
                        Message = "Error Occured",
                        Error = "Not Found "
                    });
                }
            }
            catch (Exception ex)
            {

                return NotFound(new ApiResponse<string>()
                {
                    Code = "404",
                    Status = "Error",
                    Message = "Error Occured",
                    Error = ex.Message
                });
            }
        }
        [HttpGet]
        [Route("~/api/getStudent/{id}")]
        public IActionResult GetStudent(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var model = mapper.Map<StudentVM>(studentRep.GetById(id));

                    return Ok(new ApiResponse<StudentVM>()
                    {
                        Code = "200",
                        Status = "OK",
                        Message = "Student Data",
                        Data = model
                    });
                }
                else
                {
                    return NotFound(new ApiResponse<string>()
                    {
                        Code = "404",
                        Status = "Error",
                        Message = "Error Occured",
                        Error = "Not Found "
                    });
                }
            }
            catch (Exception ex)
            {

                return NotFound(new ApiResponse<string>()
                {
                    Code = "404",
                    Status = "Error",
                    Message = "Error Occured",
                    Error = ex.Message
                });
            }
        }


        [HttpPost]
        [Route("~/api/CreateStudent")]
        public IActionResult CreateStudent(StudentVM studentVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = mapper.Map<Student>(studentVM);
                    var model = studentRep.Create(data);
                    return Ok(new ApiResponse<Student>()
                    {
                        Code = "200",
                        Status = "OK",
                        Message = "Student Created",
                        Data = model
                    });
                }
                else
                {
                    return NotFound(new ApiResponse<string>()
                    {
                        Code = "404",
                        Status = "Error",
                        Message = "Error Occured",
                        Error = "Not found"
                    });
                }
            }
            catch (Exception ex)
            {
                return NotFound(new ApiResponse<string>()
                {
                    Code = "404",
                    Status = "Error",
                    Message = "Error Occured",
                    Error = ex.Message
                });
            }
        }


        [HttpPut]
        [Route("~/api/EditStudent")]
        public IActionResult EditStudent(StudentVM studentVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = mapper.Map<Student>(studentVM);
                    var model = studentRep.Edit(data);
                    return Ok(new ApiResponse<Student>()
                    {
                        Code = "200",
                        Status = "OK",
                        Message = "Student Edited",
                        Data = model
                    });
                }
                else
                {
                    return NotFound(new ApiResponse<string>()
                    {
                        Code = "404",
                        Status = "Error",
                        Message = "Error Occured",
                        Error = "Not found"
                    });
                }
            }
            catch (Exception ex)
            {
                return NotFound(new ApiResponse<string>()
                {
                    Code = "404",
                    Status = "Error",
                    Message = "Error Occured",
                    Error = ex.Message
                });
            }
        }


        [HttpDelete]
        [Route("~/api/DeleteStudent")]
        public IActionResult DeleteStudent(StudentVM studentVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = mapper.Map<Student>(studentVM);
                    var model = studentRep.Delete(data);
                    return Ok(new ApiResponse<Student>()
                    {
                        Code = "200",
                        Status = "OK",
                        Message = "Student Deleted",
                        Data = model
                    });
                }
                else
                {
                    return NotFound(new ApiResponse<string>()
                    {
                        Code = "404",
                        Status = "Error",
                        Message = "Error Occured",
                        Error = "Not found"
                    });
                }
            }
            catch (Exception ex)
            {
                return NotFound(new ApiResponse<string>()
                {
                    Code = "404",
                    Status = "Error",
                    Message = "Error Occured",
                    Error = ex.Message
                });
            }
        }



        #endregion
    }
}
