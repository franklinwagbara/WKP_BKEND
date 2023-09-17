using ErrorOr;
using MediatR;
using WKP.Application.Fee.Common;
using WKP.Domain.Repositories;

namespace WKP.Application.Fee.Commands.DeleteFee
{
    public class DeleteFeeCommandHandler : IRequestHandler<DeleteFeeCommand, ErrorOr<FeeResult>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteFeeCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<FeeResult>> Handle(DeleteFeeCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.FeeRepository.DeleteAsync(request.Id);
            return new FeeResult(null);
        }
    }
}