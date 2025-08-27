using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Commands.AboutCommands
{
    public class CreateAboutCommand:IRequest
    {
        public string AboutDescription { get; set; }
        public string AboutSubDescription { get; set; }
        public string AboutArticle1 { get; set; }
        public string AboutArticle2 { get; set; }
        public string AboutArticle3 { get; set; }
        public string AboutIconURL { get; set; }
        public string AboutLayerTitle { get; set; }
        public string AboutLayerDescription { get; set; }
        public string AboutBigImageURL { get; set; }
        public string AboutCeoTitle { get; set; }
        public string AboutCeoFullName { get; set; }
        public string AboutCeoImageURL { get; set; }
    }
}
