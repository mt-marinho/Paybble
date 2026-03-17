using Paybble.Domain.Enums;

namespace Paybble.Application.Features.Transfers.Commands.CreateTransfer
{
    public class CreateTransferDTO
    {
        public int Id { get; private set; }
        public string Description { get; private set; } = string.Empty;
        public int Value { get; private set; }
        public int Year { get; private set; }
        public int Month { get; private set; }
        public TransferType Type { get; set; }
    }
}
