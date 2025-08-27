using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Commands.SliderCommands;
using CQRS_MediatR_RentACar.DataAccessLayer.Abstract;
using CQRS_MediatR_RentACar.DataAccessLayer.EntityFramework;
using CQRS_MediatR_RentACar.EntityLayer;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Handlers.SliderHandlers
{
    public class CreateSliderCommandHandler : IRequestHandler<CreateSliderCommand>
    {
        private readonly ISliderDal _sliderDal;

        public CreateSliderCommandHandler(ISliderDal sliderDal)
        {
            _sliderDal = sliderDal;
        }

        public async Task Handle(CreateSliderCommand request, CancellationToken cancellationToken)
        {
            await _sliderDal.InsertAsync(new Slider
            {
                SliderSubTitle = request.SliderSubTitle,
                SliderTitle = request.SliderTitle
            });
        }
    }
}
