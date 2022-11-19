using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace TP_GSC_BackEnd.Protos
{
    public class LoansGrpc : LoanService.LoanServiceBase
    {
        private readonly ILogger<LoansGrpc> logger;

        public LoansGrpc(ILogger<LoansGrpc> logger) {
            this.logger = logger;
        }


        public override Task<Response> closeLoan(Loan request, ServerCallContext context)
        {
            logger.LogInformation($"Se quiere cerrar el prestamo de id {request.Id}");

            return Task.FromResult(new Response() { Status = "OK" });
        }


    }
}
