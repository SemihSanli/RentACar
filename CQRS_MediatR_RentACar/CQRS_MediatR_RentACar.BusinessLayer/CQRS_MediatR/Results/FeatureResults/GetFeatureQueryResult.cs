using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Results.FeatureResults
{
    public class GetFeatureQueryResult
    {
        public int FeatureID { get; set; }
        public string FeatureTitle { get; set; }
        public string FeatureLayerTitle { get; set; }
        public string FeatureLayerDescription { get; set; }
        public string FeatureImageURL { get; set; }
        public string FeatureIconURL { get; set; }
    }
}
