using AutoMapper;
using Paybble.Application.Features.CreditCardPurchases.Commands.CreateCreditCardPurchase;
using Paybble.Application.Features.Categories.Commands.CreateCategory;
using Paybble.Application.Features.Categories.Queries.GetCategoryDetail;
using Paybble.Application.Features.Categories.Queries.GetCategoriesList;
using Paybble.Application.Features.Savings.Commands.CreateSavings;
using Paybble.Application.Features.Savings.Queries.GetSavings;
using Paybble.Application.Features.Savings.Queries.GetSavingsList;
using Paybble.Application.Features.Transactions.Commands.CreateTransaction;
using Paybble.Application.Features.Transactions.Queries.GetTransactionDetail;
using Paybble.Application.Features.CreditCardPurchases.Queries.GetCreditCardPurchaseList;
using Paybble.Application.Features.CreditCardPurchases.Queries.GetCreditCardPurchaseDetail;
using Paybble.Application.Features.Transactions.Queries.GetTransactionsByYearMonth;
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

            CreateMap<CreditCardPurchase, CreateCreditCardPurchaseDTO>();
            CreateMap<CreditCardPurchase, CreditCardPurchaseListDTO>();
            CreateMap<CreditCardPurchase, CreditCardPurchaseDetailDTO>();
        }
    }
}
