using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_MediatR_RentACar.BusinessLayer.Interfaces
{
    public interface IOpenAIService
    {
        Task<string> GenerateAutoReply(string userMessage);
    }
}
