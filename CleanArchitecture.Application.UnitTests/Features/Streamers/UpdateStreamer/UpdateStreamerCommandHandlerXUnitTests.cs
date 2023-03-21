﻿using AutoMapper;
using CleanArchitecture.Application.UnitTests.Mocks;
using CleanArquitecture.Application.Contracts.Infrastructure;
using CleanArquitecture.Application.Features.Streamers.Commands.UpdateStreamer;
using CleanArquitecture.Application.Mappings;
using CleanArquitecture.Infrastructure.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;
using Xunit;

namespace CleanArchitecture.Application.UnitTests.Features.Streamers.UpdateStreamer
{
    public class UpdateStreamerCommandHandlerXUnitTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;
        private readonly Mock<IEmailService> _mailService;
        private readonly Mock<ILogger<UpdateStreamerCommandHandler>> _logger;

        public UpdateStreamerCommandHandlerXUnitTests()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c => c.AddProfile<MappingProfile>());
            _mapper = mapperConfig.CreateMapper();
            _mailService = new Mock<IEmailService>();
            _logger = new Mock<ILogger<UpdateStreamerCommandHandler>>();
            MockStreamerRepository.AddDataStreamerRepository(_unitOfWork.Object.StreamerDbContext);
        }

        [Fact]
        public async Task UpdateStreamerCommand_InputStreamer_ReturnsUnit()
        {
            var streamerInput = new UpdateStreamerCommand
            {
                Id = 1008,
                Name = "Vaxi Stream Max",
                Url = "https://maximo.com"
            };

            var handler = new UpdateStreamerCommandHandler(_unitOfWork.Object, _mapper, _logger.Object);
            var result = await handler.Handle(streamerInput, CancellationToken.None);
            result.ShouldBeOfType<Unit>();
        }
        
    }
}
