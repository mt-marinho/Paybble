using AutoMapper;
using Paybble.Application.Features.Expenses.Commands.CreateExpense;
using Paybble.Application.Features.Expenses.Queries.GetExpense;
using Paybble.Application.Features.Expenses.Queries.GetExpensesByYearMonth;
using Paybble.Application.Features.Incomes.Commands.CreateIncome;
using Paybble.Application.Features.Incomes.Queries.GetIncomeDetail;
using Paybble.Application.Features.Incomes.Queries.GetIncomesByYearMonth;
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
            CreateMap<Income, CreateIncomeDTO>();
            CreateMap<Income, IncomeDetailVm>();
            CreateMap<List<Income>, List<IncomesByYearMonthVm>>();
        }
    }
}
