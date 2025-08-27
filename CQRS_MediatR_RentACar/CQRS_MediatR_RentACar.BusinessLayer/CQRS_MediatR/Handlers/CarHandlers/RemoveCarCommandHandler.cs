using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Commands.CarCommands;
using CQRS_MediatR_RentACar.DataAccessLayer.Abstract;
using CQRS_MediatR_RentACar.DataAccessLayer.EntityFramework;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Handlers.CarHandlers
{
    public class RemoveCarCommandHandler : IRequestHandler<RemoveCarCommand>
    {
        private readonly ICarDal _carDal;

        public RemoveCarCommandHandler(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public async Task Handle(RemoveCarCommand request, CancellationToken cancellationToken)
        {
            var values = await _carDal.GetByIdAsync(request.CarID);
            await _carDal.DeleteAsync(values);
        }
    }
}
