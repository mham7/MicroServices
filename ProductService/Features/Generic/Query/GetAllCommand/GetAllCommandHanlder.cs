using MediatR;
using ProductService.Features.Generic.Query.GetAllCommand;
using ProductService.Interfaces.Repositories;

namespace ProductService.Features.Generic.Query.GetAllCommandHandler
{
    public class GetAllCommandHandler<TEntity> : IRequestHandler<GetAllCommand<TEntity>, List<TEntity>> where TEntity : class
    {
        private readonly IGenericRepository<TEntity> _gen;
        public GetAllCommandHandler(IGenericRepository<TEntity> gen)
        {
            _gen = gen;
            
        }
        public async Task<List<TEntity>> Handle(GetAllCommand<TEntity> request, CancellationToken cancellationToken)
        {
            return await _gen.Get();
        }
    }
}
