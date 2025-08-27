using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Commands.SliderCommands;
using CQRS_MediatR_RentACar.DataAccessLayer.Abstract;
using CQRS_MediatR_RentACar.DataAccessLayer.EntityFramework;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Handlers.SliderHandlers
{
    public class UpdateSliderCommandHandler : IRequestHandler<UpdateSliderCommand>
    {
        private readonly ISliderDal _sliderDal;

        public UpdateSliderCommandHandler(ISliderDal sliderDal)
        {
            _sliderDal = sliderDal;
        }

        public async Task Handle(UpdateSliderCommand request, CancellationToken cancellationToken)
        {
            var values = await _sliderDal.GetByIdAsync(request.SliderID);
            values.SliderSubTitle = request.SliderSubTitle;
            values.SliderTitle = request.SliderTitle;
        }
    }
}
