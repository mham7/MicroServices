using MediatR;
using CustomerService.Models;
using System.Xml;

namespace CustomerService.Features.Generic.Query.GetAllCommand
{
    public class GetAllCommand<XEntity> : IRequest<List<XEntity>> where XEntity : class
    {
        public GetAllCommand()
        {
            
        }
    }
}
