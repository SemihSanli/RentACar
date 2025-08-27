using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Commands.FeatureCommands;
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
    public class UpdateFeatureCommandHandler : IRequestHandler<UpdateFeatureCommand>
    {
        private readonly IFeatureDal _featureDal;

        public UpdateFeatureCommandHandler(IFeatureDal featureDal)
        {
            _featureDal = featureDal;
        }

        public async Task Handle(UpdateFeatureCommand request, CancellationToken cancellationToken)
        {
            var values = await _featureDal.GetByIdAsync(request.FeatureID);
            values.FeatureIconURL = request.FeatureIconURL;
            values.FeatureLayerDescription = request.FeatureLayerDescription;
            values.FeatureImageURL = request.FeatureImageURL;
            values.FeatureLayerTitle = request.FeatureLayerTitle;
            values.FeatureTitle = request.FeatureTitle;
        }
    }
}
