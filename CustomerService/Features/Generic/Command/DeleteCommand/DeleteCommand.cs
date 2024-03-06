using MediatR;
using System.Xml;

namespace CustomerService.Features.Generic.Command.DeleteCommand
{
    public class DeleteCommand<XEntity> : IRequest<XEntity> where XEntity : class
    {

        public DeleteCommand(XEntity entity)
        {

            this.entity = entity;
        }

        public XEntity entity { get; set; }
    }
}
