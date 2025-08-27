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
    public class RemoveSliderCommandHandler : IRequestHandler<RemoveSliderCommand>
    {
        private readonly ISliderDal _sliderDal;

        public RemoveSliderCommandHandler(ISliderDal sliderDal)
        {
            _sliderDal = sliderDal;
        }

        public async Task Handle(RemoveSliderCommand request, CancellationToken cancellationToken)
        {
            var values = await _sliderDal.GetByIdAsync(request.SliderID);
            await _sliderDal.DeleteAsync(values);
        }
    }
}
