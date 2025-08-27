using CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Commands.SendMessageCommands;
using CQRS_MediatR_RentACar.BusinessLayer.Interfaces;
using CQRS_MediatR_RentACar.DataAccessLayer.Abstract;
using CQRS_MediatR_RentACar.EntityLayer;
using MediatR;


namespace CQRS_MediatR_RentACar.BusinessLayer.CQRS_MediatR.Handlers.SendMessageHandlers
{
    public class CreateSendMessageCommandHandler : IRequestHandler<CreateSendMessageCommand>
    {
        private readonly ISendMessageDal _sendMessageDal;
        private readonly IOpenAIService _openAiService;
        private readonly IEmailService _emailService;
        public CreateSendMessageCommandHandler(ISendMessageDal sendMessageDal, IEmailService emailService, IOpenAIService openAiService)
        {
            _sendMessageDal = sendMessageDal;
            _emailService = emailService;
            _openAiService = openAiService;
        }

        public async Task Handle(CreateSendMessageCommand request, CancellationToken cancellationToken)
        {
            await _sendMessageDal.InsertAsync(new SendMessage
            {
                SenderMessage = request.SenderMessage,
                SenderName = request.SenderName,
                SenderPhone = request.SenderPhone,
                SenderSubject = request.SenderSubject,
                SenderSurname = request.SenderSurname,
                SenderEmail = request.SenderEmail,
            });

            var aiResponse = await _openAiService.GenerateAutoReply(request.SenderMessage);

            await _emailService.SendEmailAsync(request.SenderEmail, "Bu bir otomatik yanıttır", aiResponse);
        }
    }

  
   
 

  
}
