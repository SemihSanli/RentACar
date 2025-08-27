using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Commands.FeatureCommands;
using CQRS_MediatR_RentACar.DataAccessLayer.Abstract;
using CQRS_MediatR_RentACar.DataAccessLayer.EntityFramework;
using CQRS_MediatR_RentACar.EntityLayer;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Handlers.FeatureHandlers
{
    public class CreateFeatureCommandHandler : IRequestHandler<CreateFeatureCommand>
    {
        private readonly IFeatureDal _featureDal;

        public CreateFeatureCommandHandler(IFeatureDal featureDal)
        {
            _featureDal = featureDal;
        }

        public async Task Handle(CreateFeatureCommand request, CancellationToken cancellationToken)
        {
            await _featureDal.InsertAsync(new Feature
            {
                FeatureTitle = request.FeatureTitle,
                FeatureLayerTitle = request.FeatureLayerTitle,
                FeatureIconURL = request.FeatureIconURL,
                FeatureImageURL = request.FeatureImageURL,
                FeatureLayerDescription = request.FeatureLayerDescription
            });
        }
    }
}
