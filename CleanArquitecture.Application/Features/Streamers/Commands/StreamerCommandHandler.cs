﻿using AutoMapper;
using CleanArquitecture.Application.Contracts.Infrastructure;
using CleanArquitecture.Application.Contracts.Persistence;
using CleanArquitecture.Application.Models;
using CleanArquitecture.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArquitecture.Application.Features.Streamers.Commands
{
    public class StreamerCommandHandler : IRequestHandler<StreamerCommand, int>
    {
        private readonly IStreamerRepository _streamerRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<StreamerCommandHandler> _logger;

        public StreamerCommandHandler(IStreamerRepository streamerRepository, IMapper mapper, IEmailService emailService, ILogger<StreamerCommandHandler> logger)
        {
            _streamerRepository = streamerRepository;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<int> Handle(StreamerCommand request, CancellationToken cancellationToken)
        {
            Streamer streamerEntity = _mapper.Map<Streamer>(request);
            Streamer newStreamer  = await _streamerRepository.AddAsync(streamerEntity);

            _logger.LogInformation($"streamer {newStreamer} was created successfully");
            await SendEmail(newStreamer);
            return newStreamer.Id;
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
            catch(Exception ex)
            {
                _logger.LogError($"Errores enviando el email de {streamer.Id}");
            }
            
        }
    }
}
