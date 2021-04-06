using System;
using System.Collections.Generic;
using Entities;
using Microsoft.AspNetCore.Http;
using Repositories;
using Repositories.Generic;

namespace Services
{
    public class HouseServiceX : IHouseService
    {

        private readonly IHouseRepository _houseRepository;
        private readonly IFileService _fileService;

        public HouseServiceX(IHouseRepository houseRepository, IFileService fileService)
        {
            this._houseRepository = houseRepository ?? throw new ArgumentNullException(nameof(houseRepository));
            this._fileService = fileService ?? throw new ArgumentNullException(nameof(fileService));
        }
        public IEnumerable<House> GetAll()
        {
            return _houseRepository.GetAll();
        }

        public House GetById(int id)
        {
            return _houseRepository.GetById(id);
        }

        public void Insert(House house, IFormFile image)
        {
            var imageName = _fileService.UploadImage(image);
            house.ImageName = imageName;
            _houseRepository.Insert(house);

        }

        public void Update(House house, IFormFile image)
        {
            if (image != null)
            {
                house.ImageName = _fileService.UploadImage(image);
            }
            _houseRepository.Update(house);
        }
        public void Save()
        {
            _houseRepository.Save();
        }

        public bool HouseExists(int houseId)
        {
            return _houseRepository.HouseExists(houseId);
        }

        public IEnumerable<House> GetByAvailability(bool availability = true)
        {
            return _houseRepository.GetByAvailability(availability);
        }
    }
}