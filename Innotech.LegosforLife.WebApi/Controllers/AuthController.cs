using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InnoTech.LegosForLife.WebApi.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InnoTech.LegosForLife.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        public ActionResult<LoginDTO> Login([FromBody]LoginDTO dto)
        {
            //Peters kode goes here
            
            if (dto.Username == "123" && dto.Password == "123123123")
            {
                return Ok(new LoginDTO{Token = "token123"});
            }

            return Unauthorized();
        }
    }
}