using AutoMapper;
using CleanArquitecture.Application.Contracts.Infrastructure;
using CleanArquitecture.Application.Contracts.Persistence;
using CleanArquitecture.Application.Models;
using CleanArquitecture.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArquitecture.Application.Features.Streamers.Commands.CreateStreamer
{
    public class CreateStreamerCommandHandler : IRequestHandler<CreateStreamerCommand, int>
    {
        //private readonly IStreamerRepository _streamerRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<CreateStreamerCommandHandler> _logger;

        public CreateStreamerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IEmailService emailService, ILogger<CreateStreamerCommandHandler> logger)
        {
            //_streamerRepository = streamerRepository;
            _unitOfWork   = unitOfWork;
            _mapper       = mapper;
            _emailService = emailService;
            _logger       = logger;
        }

        public async Task<int> Handle(CreateStreamerCommand request, CancellationToken cancellationToken)
        {
            Streamer streamerEntity = _mapper.Map<Streamer>(request);
            _unitOfWork.StreamerRepository.AddEntity(streamerEntity);
            int result = await _unitOfWork.Complete();
            if (result <= 0) throw new Exception($"No se pudo insertar el record de streamer");
            _logger.LogInformation($"streamer {streamerEntity.Id} was created successfully");
            await SendEmail(streamerEntity);
            return streamerEntity.Id;
        }

        private async Task SendEmail(Streamer streamer)
        {
            Email email = new Email
            {
                To = "vaxi.drez.social@gmail.com",
                Body = "La compañia de streamer se creo correctamente",
                Subject = "Mensaje de alerta"
            };
            try
            {
                await _emailService.SendEmailAsync(email);
            }
            catch (Exception)
            {
                _logger.LogError($"Errores enviando el email de {streamer.Id}");
            }

        }
    }
}
