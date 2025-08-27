using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Commands.FeatureCommands
{
    public class RemoveFeatureCommand:IRequest
    {
        public int FeatureID { get; set; }

        public RemoveFeatureCommand(int featureID)
        {
            FeatureID = featureID;
        }
    }
}
