using AppLight.Business.CustomExceptions.General;
using AppLight.Business.CustomExceptions.WorkerImage;
using AppLight.Business.Helpers;
using AppLight.Business.Services.Service;
using AppLight.Core.Entities;
using AppLight.Core.Repositories;
using Microsoft.AspNetCore.Hosting;
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
        private readonly IWebHostEnvironment _webHostEnvironment;

        public WorkerService(IWorkerRepository workerRepository, IWebHostEnvironment webHostEnvironment)
        {
            _workerRepository = workerRepository;
            _webHostEnvironment = webHostEnvironment;
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

            worker.CreatedDate = DateTime.UtcNow.AddHours(4);
            worker.UpdatedDate = DateTime.UtcNow.AddHours(4);
            worker.ImgUrl = await Helper.GetFileName(_webHostEnvironment.WebRootPath, "uploads/workers-images", worker.Image);

            await _workerRepository.CreateAsync(worker);
            await _workerRepository.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            if (id == null || id <= 0) throw new InvalidIdOrBelowThanZero();

            Worker wantedWorker = await _workerRepository.GetByIdAysnc(x => x.Id == id && !x.IsDeleted);
            if (wantedWorker == null) throw new InvalidEntityException("", "Entity is null here!");

            string deletedFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "uploads/workers-images", wantedWorker.ImgUrl);
            if(File.Exists(deletedFilePath))
            {
                File.Delete(deletedFilePath);   
            }


            _workerRepository.Delete(wantedWorker);
            await _workerRepository.SaveAsync();
        }

        public async Task<List<Worker>> GetAllWorkersAsync()
        {
            return await _workerRepository.GetAllAysnc(x => !x.IsDeleted);
        }

        public async Task<Worker> GetWorkerAsync(int id)
        {
            if (id == null || id <= 0) throw new InvalidIdOrBelowThanZero();

            return await _workerRepository.GetByIdAysnc(x => x.Id == id && !x.IsDeleted);
        }

        public async Task SoftDelete(int id)
        {
            if (id == null || id <= 0) throw new InvalidIdOrBelowThanZero();

            Worker wantedWorker = await _workerRepository.GetByIdAysnc(x => x.Id == id && !x.IsDeleted);
            if (wantedWorker == null) throw new InvalidEntityException();

            wantedWorker.IsDeleted = !wantedWorker.IsDeleted;

            await _workerRepository.SaveAsync();
        }

        public async Task UpdateAsync(Worker worker)
        {
            Worker wantedWorker = await _workerRepository.GetByIdAysnc(x => x.Id == worker.Id && !x.IsDeleted);
            if (wantedWorker == null) throw new InvalidEntityException();

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
                string oldFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "uploads/workers-images", wantedWorker.ImgUrl);

                wantedWorker.ImgUrl = await Helper.GetFileName(_webHostEnvironment.WebRootPath, "uploads/workers-images", worker.Image);

                if (File.Exists(oldFilePath))
                {
                    File.Delete(oldFilePath);
                }
            }

            wantedWorker.FullName = worker.FullName;
            wantedWorker.Position = worker.Position;
            wantedWorker.UpdatedDate = DateTime.UtcNow.AddHours(4);

            await _workerRepository.SaveAsync();
        }
    }
}
