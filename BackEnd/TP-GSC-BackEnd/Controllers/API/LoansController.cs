using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public LoansController(ILoansService loansService) { 
            this.LoansService = loansService;
        }


        [HttpPost]
        public IActionResult createloan([FromBody]CreateLoanDto CreateLoanDto) {
           
            var result=LoansService.create(CreateLoanDto);


            switch (result.type) {
                case ServiceResultTypes.NotFound:
                    return NotFound(result.error_message);

                case ServiceResultTypes.InvalidInput:
                    return BadRequest(result.error_message);

                case ServiceResultTypes.BussinesLogicError:
                    return Conflict(result.error_message);
            }

            return NoContent();
        
        }




    }
}
