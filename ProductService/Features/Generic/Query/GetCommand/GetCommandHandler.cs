using MediatR;
using ProductService.Features.Generic.Command.UpdateCommand;
using ProductService.Interfaces.Repositories;

namespace ProductService.Features.Generic.Query.GetCommand
{
    public class GetCommandHandler<TEntity> : IRequestHandler<GetCommand<TEntity>,TEntity> where TEntity : class
    {
        private readonly IGenericRepository<TEntity> _gen;
        public GetCommandHandler(IGenericRepository<TEntity> gen)
        {
            _gen=gen;
        }
        public async Task<TEntity> Handle(GetCommand<TEntity> request, CancellationToken cancellationToken)
        {
              return await _gen.Get(request.Id);
        }
    }
}
