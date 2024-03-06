using MediatR;
using CustomerService.Interfaces.Repositories;

namespace CustomerService.Features.Generic.Command.CreateCommand
{
    public class CreateCommandHandler<TEntity> : IRequestHandler<CreateCommand<TEntity>,TEntity> where TEntity : class
    {
        private readonly IGenericRepository<TEntity> _repository;
        public CreateCommandHandler(IGenericRepository<TEntity> repository)
        {
            _repository=repository;
        }
        public async Task<TEntity> Handle(CreateCommand<TEntity> request, CancellationToken cancellationToken)
        {
            return await _repository.Post(request.Entity);
        }
    }
}
