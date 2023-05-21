using BusinessLayer.Abstract;
using DataLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AdvertManager : IAdvertService
    {
        private IAdvertRepository _advertRepository;

        public AdvertManager(IAdvertRepository advertRepository)
        {
            _advertRepository = advertRepository;
        }
        public async Task CreateAsync(Advert advert)
        {
            await _advertRepository.CreateAsync(advert);
        }

        public void Delete(Advert advert)
        {
            _advertRepository.Delete(advert);
        }

        public async Task<Advert> GetAdvertFullDataAsync(int id)
        {
            return await _advertRepository.GetAdvertFullDataAsync(id);
        }

        public async Task<List<Advert>> GetAdvertsFullDataAsync(string id, bool approvedStatus)
        {
            return await _advertRepository.GetAdvertsFullDataAsync(id, approvedStatus);
        }

        public async Task<List<Advert>> GetAllAdvertsAsync(bool approvedStatus)
        {
            return await _advertRepository.GetAllAdvertsAsync(approvedStatus);
        }

        public async Task<List<Advert>> GetAllAsync()
        {
            return await _advertRepository.GetAllAsync();
        }

        public async Task<Advert> GetByIdAsync(int id)
        {
            return await _advertRepository.GetByIdAsync(id);
        }

        public async Task<int> GetByUrlAsync(string url)
        {
            return await _advertRepository.GetByUrlAsync(url);
        }

        public void Update(Advert advert)
        {
            _advertRepository.Update(advert);
        }
    }
}
