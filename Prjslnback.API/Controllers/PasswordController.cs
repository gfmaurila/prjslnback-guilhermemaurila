using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Prjslnback.API.Utilities;
using Prjslnback.API.ViewModels;
using Prjslnback.Core.Exceptions;
using Prjslnback.Services.DTO;
using Prjslnback.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace Prjslnback.API.Controllers
{
    [ApiController]
    public class PasswordController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IEPasswordService _service;

        public PasswordController(IMapper mapper, IEPasswordService service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpPost]
        [Authorize]
        [Route("/api/v1/password/create")]
        public async Task<IActionResult> Create([FromBody] CreatePasswordViewModel viewModel)
        {
            try
            {
                var dto = _mapper.Map<EPasswordDTO>(viewModel);

                var passwordCreated = await _service.Create(dto);

                return Ok(new ResultViewModel
                {
                    Message = "Senha válida criada!",
                    Success = true,
                    Data = passwordCreated
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpPost]
        [Authorize]
        [Route("/api/v1/password/Validator")]
        public IActionResult Validator([FromBody] CreatePasswordViewModel viewModel)
        {
            try
            {
                var dto = _mapper.Map<EPasswordDTO>(viewModel);

                bool passwordCreated = _service.Validator(dto);

                return Ok(new ResultViewModel
                {
                    Message = "Senha válida!",
                    Success = true,
                    Data = passwordCreated
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }
    }
}
