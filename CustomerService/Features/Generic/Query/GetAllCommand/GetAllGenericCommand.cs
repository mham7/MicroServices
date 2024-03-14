using MediatR;
using CustomerService.Models;
using System.Xml;

namespace CustomerService.Features.Generic.Query.GetAllCommand
{
    public class GetAllGenericCommand<XEntity> : IRequest<List<XEntity>> where XEntity : class
    {
        public GetAllGenericCommand()
        {
            
        }
    }
}
