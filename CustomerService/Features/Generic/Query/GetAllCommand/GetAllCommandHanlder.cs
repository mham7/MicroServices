using MediatR;
using CustomerService.Features.Generic.Query.GetCommand;
using CustomerService.Interfaces.Repositories;
using CustomerService.Features.Generic.Query.GetAllCommand;

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
