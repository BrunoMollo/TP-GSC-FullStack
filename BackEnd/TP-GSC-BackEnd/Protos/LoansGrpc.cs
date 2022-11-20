using Grpc.Core;
using System.Security.Permissions;
using TP_GSC_BackEnd.Dto.LoanDto;
using TP_GSC_BackEnd.Services.Loans;

namespace TP_GSC_BackEnd.Protos
{
    public class LoansGrpc : LoanGrpcGateway.LoanGrpcGatewayBase
    {
        private readonly ILogger<LoansGrpc> logger;
        private readonly ILoansService loansService;

        public LoansGrpc(ILogger<LoansGrpc> logger, ILoansService loansService) {
            this.logger = logger;
            this.loansService = loansService;
        }


        public override Task<Response> closeLoan(LoanId request, ServerCallContext context)
        {
            logger.LogInformation($"Se quiere cerrar el prestamo de id {request.Id}"); 

            return Task.FromResult(new Response() { Message="OK" });
        }

        public override Task<Response> initLoan(loanCreateRequest request, ServerCallContext context)
        {
            var dto = new CreateLoanDto()
            {
                PersonId = request.PersonId,
                ThingId = request.ThingId,
                AgreedReturnDate = request.AgreedReturnDate.ToDateTime(),
            };

            var result=loansService.create(dto);

            return Task.FromResult(new Response() { Message=result.error_message });
        }


    }
}
