using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Queries.SendMessageQueries;
using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Results.ContactResults;
using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Results.SendMessageResults;
using CQRS_MediatR_RentACar.DataAccessLayer.Abstract;
using CQRS_MediatR_RentACar.DataAccessLayer.EntityFramework;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Handlers.SendMessageHandlers
{
    public class GetSendMessageQueryHandler : IRequestHandler<GetSendMessageQuery, List<GetSendMessageQueryResult>>
    {
        private readonly ISendMessageDal _sendMessageDal;

        public GetSendMessageQueryHandler(ISendMessageDal sendMessageDal)
        {
            _sendMessageDal = sendMessageDal;
        }

        public async Task<List<GetSendMessageQueryResult>> Handle(GetSendMessageQuery request, CancellationToken cancellationToken)
        {
            var values = await _sendMessageDal.GetListAsync();
            return values.Select(x => new GetSendMessageQueryResult
            {
                SenderMessage = x.SenderMessage,
                SenderName = x.SenderName,
                SenderSurname = x.SenderSurname,
                SenderPhone = x.SenderPhone,
                SenderSubject = x.SenderSubject,
                SendMessageID = x.SendMessageID
            }).ToList();
        }
    }
}
