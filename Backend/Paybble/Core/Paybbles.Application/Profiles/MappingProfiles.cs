using AutoMapper;
using Paybble.Application.Features.Expenses.Commands.CreateExpense;
using Paybble.Domain.Entities;

namespace Paybble.Application.Profiles
{
    internal class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Expense, CreateExpenseDTO>();
        }
    }
}
