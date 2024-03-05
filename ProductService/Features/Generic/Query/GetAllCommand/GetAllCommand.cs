using MediatR;
using ProductService.Model;
using System.Xml;

namespace ProductService.Features.Generic.Query.GetAllCommand
{
    public class GetAllCommand<XEntity> : IRequest<List<XEntity>> where XEntity : class
    {
        public GetAllCommand()
        {
            
        }
    }
}
