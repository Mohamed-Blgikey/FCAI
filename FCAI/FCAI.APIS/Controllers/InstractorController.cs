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
    public class InstractorController : ControllerBase
    {
        private readonly IInstractorRep instractorRep;
        private readonly IMapper mapper;

        public InstractorController(IInstractorRep instractorRep, IMapper mapper)
        {
            this.instractorRep = instractorRep;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("~/api/getinstractors")]
        public IActionResult GetInstractors()
        {
            try
            {
                var model = mapper.Map<IEnumerable<InstractorVM>>(instractorRep.Get());

                return Ok(new ApiResponse<IEnumerable<InstractorVM>>()
                {
                    Code = "200",
                    Status = "OK",
                    Message = "Data Retrieved",
                    Data = model
                });
            }
            catch (Exception ex)
            {

                return NotFound(new ApiResponse<string>()
                {
                    Code = "404",
                    Status = "Not Found",
                    Message = "Data Not Retrieved",
                    Error = ex.Message
                }) ;
            }
        }

        [HttpGet]
        [Route("~/api/getinstractor/{id}")]
        public IActionResult GetInstractorById(int id)
        {
            try
            {
                var model = mapper.Map<InstractorVM>(instractorRep.GetById(id));

                return Ok(new ApiResponse<InstractorVM>()
                {
                    Code = "200",
                    Status = "OK",
                    Message = "Data Retrieved",
                    Data = model
                });
            }
            catch (Exception ex)
            {

                return NotFound(new ApiResponse<string>()
                {
                    Code = "404",
                    Status = "Not Found",
                    Message = "Data Not Retrieved",
                    Error = ex.Message
                });
            }
        }

        [HttpPost]
        [Route("~/api/creatrinstractor")]
        public IActionResult createInstractor(InstractorVM instractorVM)
        {
            try
            {
                var model = mapper.Map<Instractor>(instractorVM);
                var data = instractorRep.Create(model);
                return Ok(new ApiResponse<Instractor>()
                {
                    Code = "200",
                    Status = "OK",
                    Message = "Data Created and Retrieved",
                    Data = data
                });
            }
            catch (Exception ex)
            {

                return NotFound(new ApiResponse<string>()
                {
                    Code = "404",
                    Status = "Not Found",
                    Message = "Data Not Retrieved",
                    Error = ex.Message
                });
            }
        }


        [HttpPut]
        [Route("~/api/editinstractor")]
        public IActionResult editInstractor(InstractorVM instractorVM)
        {
            try
            {
                var model = mapper.Map<Instractor>(instractorVM);
                var data = instractorRep.Edit(model);
                return Ok(new ApiResponse<Instractor>()
                {
                    Code = "200",
                    Status = "OK",
                    Message = "Data Edit And Retrieved",
                    Data = data
                });
            }
            catch (Exception ex)
            {

                return NotFound(new ApiResponse<string>()
                {
                    Code = "404",
                    Status = "Not Found",
                    Message = "Data Not Retrieved",
                    Error = ex.Message
                });
            }
        }


        [HttpDelete]
        [Route("~/api/Deleteinstractor")]
        public IActionResult deleteInstractor(InstractorVM instractorVM)
        {
            try
            {
                var model = mapper.Map<Instractor>(instractorVM);
                var data = instractorRep.Delete(model);
                return Ok(new ApiResponse<Instractor>()
                {
                    Code = "200",
                    Status = "OK",
                    Message = "Data deleted And Retrieved",
                    Data = data
                });
            }
            catch (Exception ex)
            {

                return NotFound(new ApiResponse<string>()
                {
                    Code = "404",
                    Status = "Not Found",
                    Message = "Data Not Retrieved",
                    Error = ex.Message
                });
            }
        }

    }
}
