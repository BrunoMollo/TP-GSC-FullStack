using AutoMapper;
using Grpc.Core;
using TP_GSC_BackEnd.Dto.LoanDto;
using TP_GSC_BackEnd.Services.Loans;

namespace TP_GSC_BackEnd.Protos
{
    public class LoansGrpc : LoanGrpcGateway.LoanGrpcGatewayBase
    {
        private readonly ILoansService loansService;
        private readonly IMapper mapper;

        public LoansGrpc(ILoansService loansService, IMapper mapper) {
            this.loansService = loansService;
            this.mapper = mapper;
        }


  

        public override Task<Response> initLoan(NewLoanRequest request, ServerCallContext context)
        {
            var dto=mapper.Map<CreateLoanDto>(request);
            var result=loansService.create(dto);

            return Task.FromResult(new Response() {
                Message=result.error_message });
        }



        public override Task<Response> closeLoan(CloseLoanRequest request, ServerCallContext context)
        {
            var result = loansService.close(request.Id);

            return Task.FromResult(
                new Response()
                {
                    Message = result.isOK() ? $"Closed Loan {request.Id}" : result.error_message
                }
            );
        }



    }
}
