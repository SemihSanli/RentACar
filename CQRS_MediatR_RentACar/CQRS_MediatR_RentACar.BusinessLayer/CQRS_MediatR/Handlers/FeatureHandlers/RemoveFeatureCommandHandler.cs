using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Commands.FeatureCommands;
using CQRS_MediatR_RentACar.DataAccessLayer.Abstract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Handlers.FeatureHandlers
{
    public class RemoveFeatureCommandHandler : IRequestHandler<RemoveFeatureCommand>
    {
        private readonly IFeatureDal _featureDal;

        public RemoveFeatureCommandHandler(IFeatureDal featureDal)
        {
            _featureDal = featureDal;
        }

        public async Task Handle(RemoveFeatureCommand request, CancellationToken cancellationToken)
        {
            var values = await _featureDal.GetByIdAsync(request.FeatureID);
            await _featureDal.DeleteAsync(values);
        }
    }
}
