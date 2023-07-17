using Microsoft.AspNetCore.Mvc;
using Premedia.Applications.Imaging.Dashboard.Application.Contracts;
using Premedia.Applications.Imaging.Dashboard.Application.ReadModels;
using Premedia.Applications.Imaging.Dashboard.Persistence;
using Premedia.Applications.Imaging.Dashboard.Persistence.Contracts;
using AutoMapper;
using Premedia.Applications.Imaging.Dashboard.Core.Entities;
using Premedia.Applications.Imaging.Dashboard.Application.Commands;

namespace Premedia.Applications.Imaging.Dashboard.Application.Services
{
    public class ClientApplicationService : BaseApplicationService, IClientApplicationService
    {
        private readonly ImagingDashboardDbContext _dbContext;
        private readonly IMapper _mapper;

        public ClientApplicationService(IUnitOfWork unitOfWork, ImagingDashboardDbContext dbContext, IMapper mapper) : base(unitOfWork)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ActionResult<List<ClientReadModel>>> GetAllClients()
        {
            var client = await _unitOfWork.ClientRepository.GetAllAsync();
            return _mapper.Map<List<ClientReadModel>>(client);
        }

        public async Task<ActionResult<ClientReadModel>> GetClientById(Guid id)
        {
            var client = await _unitOfWork.ClientRepository.GetFirstOrDefaultAsync(x => x.Id==id);
            return _mapper.Map<ClientReadModel>(client);
        }

        public async Task<ActionResult<ClientReadModel>> CreateClient(CreateClientCommand command)
        {
            var client = _mapper.Map<Client>(command);
            await _unitOfWork.ClientRepository.AddAsync(client);
            await _unitOfWork.SaveChangesAsync();

            var createdModel = _mapper.Map<ClientReadModel>(client);
            return createdModel;
        }

        public async Task<ActionResult<ClientReadModel>> UpdateClient(Guid id, UpdateClientCommand command)
        {
            var existingClient = await _unitOfWork.ClientRepository.GetFirstOrDefaultAsync(x => x.Id == id);
            if (existingClient == null)
            {
                return null;
            }

            _mapper.Map(command, existingClient);
            await _unitOfWork.SaveChangesAsync();

            var updatedModel = _mapper.Map<ClientReadModel>(existingClient);
            return updatedModel;
        }
    }
}