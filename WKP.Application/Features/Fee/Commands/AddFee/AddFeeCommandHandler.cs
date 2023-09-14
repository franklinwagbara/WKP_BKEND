using ErrorOr;
using MapsterMapper;
using MediatR;
using WKP.Application.Fee.Common;
using WKP.Domain.Repositories;

namespace WKP.Application.Fee.Commands
{
    public class AddFeeCommandHandler : IRequestHandler<AddFeeCommand, ErrorOr<FeeResult>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddFeeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ErrorOr<FeeResult>> Handle(AddFeeCommand request, CancellationToken cancellationToken)
        {
            var fee = _mapper.Map<Domain.Entities.Fee>(request);
            var result = await _unitOfWork.FeeRepository.AddAsync(fee);
            await _unitOfWork.SaveChangesAsync();
            return new FeeResult(result);
        }
    }
}