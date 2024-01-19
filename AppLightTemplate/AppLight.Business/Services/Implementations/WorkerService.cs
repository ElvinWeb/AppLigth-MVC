using AppLight.Business.CustomExceptions.WorkerImage;
using AppLight.Business.Services.Service;
using AppLight.Core.Entities;
using AppLight.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLight.Business.Services.Implementations
{
    public class WorkerService : IWorkerService
    {
        private readonly IWorkerRepository _workerRepository;

        public WorkerService(IWorkerRepository workerRepository)
        {
            _workerRepository = workerRepository;
        }
        public async Task CreateAsync(Worker worker)
        {
            if (worker.Image != null)
            {
                if (worker.Image.ContentType != "image/png" && worker.Image.ContentType != "image/jpeg")
                {
                    throw new InvalidImageContentTypeOrSize("Image", "image content type is not correct!");
                }
                if (worker.Image.Length > 2097152)
                {
                    throw new InvalidImageContentTypeOrSize("Image", "image size should less than 2mb!");
                }
            }
            else
            {
                throw new ImageRequired("Image", "image must be choosed!");
            }

            await _workerRepository.CreateAsync(worker);
            await _workerRepository.SaveAsync();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Worker>> GetAllWorkersAsync()
        {
            return await _workerRepository.GetAllAysnc(x => !x.IsDeleted);
        }

        public async Task<Worker> GetWorkerAsync(int id)
        {
            return await _workerRepository.GetByIdAysnc(x => x.Id == id && !x.IsDeleted);
        }

        public Task SoftDelete(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Worker worker)
        {
            throw new NotImplementedException();
        }
    }
}
