using AutoMapper;
using Paybble.Application.Features.Categories.Commands.CreateCategory;
using Paybble.Application.Features.Categories.Queries.GetCategoryDetail;
using Paybble.Application.Features.Categories.Queries.GetCategoriesList;
using Paybble.Application.Features.Savings.Commands.CreateSavings;
using Paybble.Application.Features.Savings.Queries.GetSavings;
using Paybble.Application.Features.Savings.Queries.GetSavingsList;
using Paybble.Application.Features.Transactions.Commands.CreateTransaction;
using Paybble.Application.Features.Transactions.Queries.GetTransactionDetail;
using Paybble.Application.Features.Transactions.Queries.GetTransactionsByYearMonth;
using Paybble.Application.Features.Transfers.Commands.CreateTransfer;
using Paybble.Application.Features.Transfers.Queries.GetTransfer;
using Paybble.Application.Features.Transfers.Queries.GetTrensferList;
using Paybble.Domain.Entities;

namespace Paybble.Application.Profiles
{
    internal class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Category, CreateCategoryDTO>();
            CreateMap<Category, CategoryDetailVm>();
            CreateMap<Category, CategoryListVm>();

            CreateMap<Saving, CreateSavingsResponse>();
            CreateMap<Saving, GetSavingsDTO>();
            CreateMap<List<Saving>, List<GetSavingsListDTO>>();

            CreateMap<Transaction, CreateTransactionDTO>();
            CreateMap<Transaction, TransactionDetailVm>();
            CreateMap<Transaction, TransactionsByYearMonthVm>();

            CreateMap<Transfer, CreateTransferDTO>();
            CreateMap<Transfer, GetTransferDTO>();
            CreateMap<List<Transfer>, List<GetTransferListDTO>>();
        }
    }
}
