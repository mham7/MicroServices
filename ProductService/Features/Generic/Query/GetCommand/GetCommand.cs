using MediatR;

namespace ProductService.Features.Generic.Query.GetCommand
{
    public class GetCommand<XEntity> : IRequest<XEntity> where XEntity : class
    {
        public GetCommand(int Id)
        {
            this.Id = Id;
        }
        public int Id { get; set; }
    }
}
