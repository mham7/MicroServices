using MediatR;

namespace ProductService.Features.Generic.Command.CreateCommand
{
    public class CreateCommand<XEntity> : IRequest<XEntity> where XEntity : class
    {
        public CreateCommand(XEntity entity)
        {
            Entity = entity;    
        }

        public XEntity Entity { get; set; }
        
    }
}
