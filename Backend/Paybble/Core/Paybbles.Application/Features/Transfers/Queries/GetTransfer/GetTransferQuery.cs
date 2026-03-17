using MediatR;

namespace Paybble.Application.Features.Transfers.Queries.GetTransfer
{
    public record GetTransferQuery(int id) : IRequest<GetTransferResponse>;
}
