using AutoMapper;
using Paybble.Application.Features.Expenses.Commands.CreateExpense;
using Paybble.Application.Features.Expenses.Queries.GetExpense;
using Paybble.Application.Features.Expenses.Queries.GetExpensesByYearMonth;
using Paybble.Domain.Entities;

namespace Paybble.Application.Profiles
{
    internal class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Expense, CreateExpenseDTO>();
            CreateMap<Expense, ExpenseDetailVm>();
            CreateMap<List<Expense>, List<ExpensesByYearMonthVm>>();
        }
    }
}
