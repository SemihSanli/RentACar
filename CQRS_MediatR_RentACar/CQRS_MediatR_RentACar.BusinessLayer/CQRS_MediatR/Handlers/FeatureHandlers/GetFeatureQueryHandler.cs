using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Queries.FeatureQueries;
using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Results.AboutResults;
using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Results.FeatureResults;
using CQRS_MediatR_RentACar.DataAccessLayer.Abstract;
using CQRS_MediatR_RentACar.DataAccessLayer.EntityFramework;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Handlers.FeatureHandlers
{
    public class GetFeatureQueryHandler : IRequestHandler<GetFeatureQuery, List<GetFeatureQueryResult>>
    {
        private readonly IFeatureDal _featureDal;

        public GetFeatureQueryHandler(IFeatureDal featureDal)
        {
            _featureDal = featureDal;
        }

        public async Task<List<GetFeatureQueryResult>> Handle(GetFeatureQuery request, CancellationToken cancellationToken)
        {
            var values = await _featureDal.GetListAsync();
            return values.Select(x => new GetFeatureQueryResult
            {
               FeatureIconURL = x.FeatureIconURL,
               FeatureID = x.FeatureID,
               FeatureImageURL = x.FeatureImageURL,
               FeatureLayerDescription = x.FeatureLayerDescription,
               FeatureLayerTitle = x.FeatureLayerTitle,
               FeatureTitle = x.FeatureTitle,
            }).ToList();
        }
    }
}
