using MediatR;

namespace ProductService.Features.Generic.Command.UpdateCommand
{
    public class UpdateCommand<XEntity> : IRequest<XEntity> where XEntity : class
    {
        public UpdateCommand(XEntity entity)
        {

            Entity = entity;

        }
        public XEntity Entity { get; set; }
    }
}
