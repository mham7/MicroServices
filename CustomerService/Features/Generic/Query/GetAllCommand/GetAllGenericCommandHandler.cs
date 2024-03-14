using MediatR;
using CustomerService.Features.Generic.Query.GetCommand;
using CustomerService.Interfaces.Repositories;
using CustomerService.Features.Generic.Query.GetAllCommand;

namespace ProductService.Features.Generic.Query.GetAllCommand
{
    public class GetAllGenericCommandHandler<TEntity> : IRequestHandler<GetAllGenericCommand<TEntity>, List<TEntity>> where TEntity : class
    {
        private readonly IGenericRepository<TEntity> _gen;
        public GetAllGenericCommandHandler(IGenericRepository<TEntity> gen)
        {
            _gen = gen;
            
        }
        public async Task<List<TEntity>> Handle(GetAllGenericCommand<TEntity> request, CancellationToken cancellationToken)
        {
            return await _gen.Get();
        }
    }
}
