using MediatR;
using ProductService.Features.Generic.Query.GetCommand;
using ProductService.Interfaces.Repositories;

namespace ProductService.Features.Generic.Query.GetAllCommand
{
    public class GetAllCommandHanlder<TEntity> : IRequestHandler<GetAllCommand<TEntity>, List<TEntity>> where TEntity : class
    {
        private readonly IGenericRepository<TEntity> _gen;
        public GetAllCommandHanlder(IGenericRepository<TEntity> gen)
        {
            _gen = gen;
            
        }
        public async Task<List<TEntity>> Handle(GetAllCommand<TEntity> request, CancellationToken cancellationToken)
        {
            return await _gen.Get();
        }
    }
}
