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
    [Route("[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRep departmentRep;
        private readonly IMapper mapper;

        public DepartmentController(IDepartmentRep departmentRep , IMapper mapper)
        {
            this.departmentRep = departmentRep;
            this.mapper = mapper;
        }
        #region APIS
        [HttpGet]
        [Route("~/api/getdepartments")]
        public IActionResult GetDepartments()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var model = mapper.Map<IEnumerable<DepartmentVM>>(departmentRep.Get());

                    return Ok(new ApiResponse<IEnumerable<DepartmentVM>>()
                    {
                        Code = "200",
                        Status = "OK",
                        Message = "Department Data",
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
        [Route("~/api/getdepartment/{id}")]
        public IActionResult GetDepartment(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var model = mapper.Map<DepartmentVM>(departmentRep.GetById(id));

                    return Ok(new ApiResponse<DepartmentVM>()
                    {
                        Code = "200",
                        Status = "OK",
                        Message = "Department Data",
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
        [Route("~/api/CreateDepartment")]
        public IActionResult CreateDepartment(DepartmentVM departmentVM)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var data = mapper.Map<Department>(departmentVM);
                    var model = departmentRep.Create(data);
                    return Ok(new ApiResponse<Department>()
                    {
                        Code = "200",
                        Status = "OK",
                        Message = "Department Created",
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
        [Route("~/api/EditDepartment")]
        public IActionResult EditDepartment(DepartmentVM departmentVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = mapper.Map<Department>(departmentVM);
                    var model = departmentRep.Edit(data);
                    return Ok(new ApiResponse<Department>()
                    {
                        Code = "200",
                        Status = "OK",
                        Message = "Department Edited",
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
        [Route("~/api/DeleteDepartment")]
        public IActionResult DeleteDepartment(DepartmentVM departmentVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = mapper.Map<Department>(departmentVM);
                    var model = departmentRep.Delete(data);
                    return Ok(new ApiResponse<Department>()
                    {
                        Code = "200",
                        Status = "OK",
                        Message = "Department Deleted",
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
