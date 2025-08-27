using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_MediatR_RentACar.EntityLayer
{
    public class CarRecommendationAI
    {
        public int CarRecommendationAIID { get; set; }
        public string CustomerPrompt { get; set; }
        public string AIResponse1 { get; set; }
        public string AIResponse2 { get; set; }
        public string AIResponse3 { get; set; }
        public DateTime ResponseDate { get; set; }
    }
}
