using Application.Repositories;
using Domain.Entities;
using Infrastructure.Persistence.Data;

namespace Infrastructure.Persistence.Repositories;

public class TransactionRepository(ApplicationContext context)
    : GenericRepository<Transaction>(context), ITransactionRepository;