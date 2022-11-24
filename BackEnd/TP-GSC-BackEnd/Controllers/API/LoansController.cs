using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TP_GSC_BackEnd.Data_Access.Uow;
using TP_GSC_BackEnd.Dto.LoanDto;
using TP_GSC_BackEnd.Services;
using TP_GSC_BackEnd.Services.Loans;

namespace TP_GSC_BackEnd.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoansController : ControllerBase
    {
        private ILoansService LoansService;
        private IMapper mapper;

        public LoansController(ILoansService loansService, IMapper mapper) { 
            this.LoansService = loansService;
            this.mapper = mapper;
        }


        [HttpPost]
        public IActionResult createloan([FromBody]CreateLoanDto CreateLoanDto) {
           
            var result=LoansService.Create(CreateLoanDto);


            switch (result.type) {
                case ServiceResultTypes.NotFound:
                    return NotFound(result.error_message);

                case ServiceResultTypes.InvalidInput:
                    return BadRequest(result.error_message);

                case ServiceResultTypes.BussinesLogicError:
                    return Conflict(result.error_message);
            }

            var arr = result.body;
            var dto = mapper.Map<ShowLoanDto>(arr);

            return CreatedAtAction(nameof(getLoanById), new { Id = dto.Id }, dto);
        
        }

        [HttpGet("{id}")]
        public IActionResult getLoanById(int id) {
            throw new NotImplementedException();
        }


        [HttpGet("pending")]
        public IActionResult getPendingLoans() {
            var result=LoansService.GetPendingLoans();
            var arr = result.body.ToArray();
            var dto = mapper.Map<ShowLoanDto[]>(arr);
            return Ok(dto);
        }


        [HttpPost("close/{id}")]
        public IActionResult closeLoan(int id) {
            var result=LoansService.Close(id);

            if(result.isNotFound())
                 return NotFound(result.error_message);

            if (result.isBussinesLogicError())
                return Conflict(result.error_message);

            return NoContent();
        
        }



    }
}
