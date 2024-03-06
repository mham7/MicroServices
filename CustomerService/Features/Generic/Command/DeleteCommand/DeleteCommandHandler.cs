using MediatR;
using CustomerService.Features.Generic.Command.CreateCommand;
using CustomerService.Interfaces.Repositories;

namespace CustomerService.Features.Generic.Command.DeleteCommand
{
    public class DeleteCommandHandler<TEntity> : IRequestHandler<DeleteCommand<TEntity>,TEntity> where TEntity : class
    {
        private IGenericRepository<TEntity> _repository;
        public DeleteCommandHandler(IGenericRepository<TEntity> repository)
        {
            _repository = repository;
            
        }
        public async Task<TEntity> Handle(DeleteCommand<TEntity> request, CancellationToken cancellationToken)
        {
            return await _repository.Delete(request.entity);
        }

        
    }
}
