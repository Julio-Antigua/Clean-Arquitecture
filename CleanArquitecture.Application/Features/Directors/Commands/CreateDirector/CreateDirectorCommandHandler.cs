﻿using AutoMapper;
using CleanArquitecture.Application.Contracts.Persistence;
using CleanArquitecture.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArquitecture.Application.Features.Directors.Commands.CreateDirector
{
    public class CreateDirectorCommandHandler : IRequestHandler<CreateDirectorCommand, int>
    {
        private readonly ILogger<CreateDirectorCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateDirectorCommandHandler(ILogger<CreateDirectorCommandHandler> logger, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateDirectorCommand request, CancellationToken cancellationToken)
        {
            var directorEntity = _mapper.Map<Director>(request);
            _unitOfWork.Repository<Director>().AddEntity(directorEntity);
            var result = await _unitOfWork.Complete();
            if (result <= 0)
            {
                _logger.LogError($"No se inserto el record del director {directorEntity}");
                throw new Exception("No se puedo insertar el record del director");
            }
            _logger.LogInformation($"Se inserto el record del dirctor {directorEntity} exitosamente");
            return directorEntity.Id;
        }
    }
}
