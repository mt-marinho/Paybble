using MediatR;

namespace Paybble.Application.Features.Transfers.Queries.GetTrensferList
{
    public record GetTransferListQuery() : IRequest<GetTransferListResponse>;
}
