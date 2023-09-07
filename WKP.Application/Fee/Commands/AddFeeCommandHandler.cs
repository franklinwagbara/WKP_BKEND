using MediatR;
using WKP.Application.Fee.Common;

namespace WKP.Application.Fee.Commands
{
    public class AddFeeCommandHandler : IRequestHandler<AddFeeCommand, FeeResult>
    {
        public Task<FeeResult> Handle(AddFeeCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}