using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Commands.AboutCommands;
using CQRS_MediatR_RentACar.DataAccessLayer.Abstract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Handlers.AboutHandlers
{
    public class UpdateAboutCommandHandler : IRequestHandler<UpdateAboutCommand>
    {
        private readonly IAboutDal _aboutDal;

        public UpdateAboutCommandHandler(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public async Task Handle(UpdateAboutCommand request, CancellationToken cancellationToken)
        {
            var values = await _aboutDal.GetByIdAsync(request.AboutID);
            values.AboutDescription = request.AboutDescription;
            values.AboutLayerDescription = request.AboutLayerDescription;
            values.AboutSubDescription = request.AboutSubDescription;
            values.AboutCeoFullName = request.AboutCeoFullName;
            values.AboutIconURL = request.AboutIconURL;
            values.AboutBigImageURL = request.AboutBigImageURL;
            values.AboutCeoImageURL = request.AboutCeoImageURL;
            values.AboutArticle1 = request.AboutArticle1;
            values.AboutArticle2 = request.AboutArticle2;
            values.AboutArticle3 = request.AboutArticle3;
            values.AboutLayerTitle = request.AboutLayerTitle;
            values.AboutCeoTitle = request.AboutCeoTitle;
            throw new NotImplementedException();
        }
    }
}
