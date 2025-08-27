using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Commands.AboutCommands;
using CQRS_MediatR_RentACar.DataAccessLayer.Abstract;
using CQRS_MediatR_RentACar.EntityLayer;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Handlers.AboutHandlers
{
    public class CreateAboutCommandHandler : IRequestHandler<CreateAboutCommand>
    {
        private readonly IAboutDal _aboutDal;

        public CreateAboutCommandHandler(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public async Task Handle(CreateAboutCommand request, CancellationToken cancellationToken)
        {
            await _aboutDal.InsertAsync(new About
            {
                AboutArticle1 = request.AboutArticle1,
                AboutArticle2 = request.AboutArticle2,
                AboutArticle3 = request.AboutArticle3,
                AboutBigImageURL = request.AboutBigImageURL,
                AboutCeoFullName = request.AboutCeoFullName,
                AboutCeoImageURL = request.AboutCeoImageURL,
                AboutCeoTitle = request.AboutCeoTitle,
                AboutDescription = request.AboutDescription,
                AboutIconURL = request.AboutIconURL,
                AboutLayerDescription = request.AboutLayerDescription,
                AboutLayerTitle = request.AboutLayerTitle,
                AboutSubDescription = request.AboutSubDescription,
            });
        }
    }
}
