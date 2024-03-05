using MediatR;
using ProductService.Features.Generic.Command.DeleteCommand;
using ProductService.Interfaces.Repositories;

namespace ProductService.Features.Generic.Command.UpdateCommand
{
    public class UpdateCommandHandler<TEntity> : IRequestHandler<UpdateCommand<TEntity>,TEntity> where TEntity : class
    {
        private readonly IGenericRepository<TEntity> _gen;
        public UpdateCommandHandler(IGenericRepository<TEntity> gen)
        {
            _gen = gen;
        }
        public async Task<TEntity> Handle(UpdateCommand<TEntity> request, CancellationToken cancellationToken)
        {
            return await _gen.Put(request.Entity);
        }
    }
}
