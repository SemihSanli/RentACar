using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Commands.CarRecommendationAICommands
{
    public class CreateCarRecommendationAICommand:IRequest
    {
        public string CustomerPrompt { get; set; }
    }
}
