using StreamingApp.Data.Entities;
using StreamingApp.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamingApp.Services
{
    public class ProducerService : IProducerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProducerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        
        public async Task<IEnumerable<Producer>> GetAllProducersAsync()
        {
            return await _unitOfWork.Producers.GetAllAsync();
        }

        public async Task<Producer> GetProducersByIdAsync(int id)
        {
            return await _unitOfWork.Producers.GetByIdAsync(id);
        }

        public async Task AddProducerAsync(Producer producer)
        {
            await _unitOfWork.Producers.AddAsyc(producer);
            await _unitOfWork.CompleteAsync();

        }

        public async Task UpdateProducerAsync(Producer producer)
        {
            _unitOfWork.Producers.Update(producer);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteProducerAsync(int id)
        {
            var producer = await _unitOfWork.Producers.GetByIdAsync(id);
            if(producer != null)
            {
                _unitOfWork.Producers.Remove(producer);
                await _unitOfWork.CompleteAsync();
            }
        }

    }
}
