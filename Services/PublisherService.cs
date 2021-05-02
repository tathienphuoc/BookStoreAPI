using BookStoreAPI.Repository;
using BookStoreAPI.Models;
using System.Collections.Generic;
using BookStoreAPI.Utils;
using System.Linq;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookStoreAPI.Service
{
    public class PublisherService
    {
        private PublisherRepository repository;
        public PublisherService(PublisherRepository PublisherRepository)
        {
            this.repository = PublisherRepository;
        }

        public List<Publisher> GetAll()
        {
            return repository.FindAll();
        }

        public Publisher GetDetail(int id)
        {
            return repository.context.Publishers.FirstOrDefault(x=>x.Id == id);
        }

        public Publisher GetDetail(string name)
        {
            name = FormatString.Trim_MultiSpaces_Title(name);
            return repository.FindAll().Where(c => c.Name.Equals(name)).FirstOrDefault();
        }

        public Publisher Create(PublisherCreateDto dto)
        {
            dto.Name = FormatString.Trim_MultiSpaces_Title(dto.Name, true);
            var isExist = GetDetail(dto.Name);
            if (isExist != null)
            {
                throw new Exception(dto.Name + " existed");
            }

            var entity = new Publisher
            {
                Name = dto.Name,
                Image = FormatString.Trim_MultiSpaces_Title(dto.Image, true)
            };
            return repository.Add(entity);


        }

        public Publisher Update(PublisherUpdateDto dto)
        {
            var isExist = GetDetail(dto.Name);
            if (isExist != null && dto.Id != isExist.Id)
            {
                throw new Exception(dto.Name + " existed");
            }

            var entity = new Publisher
            {
                Id = dto.Id,
                Name = FormatString.Trim_MultiSpaces_Title(dto.Name, true),
                Image = FormatString.Trim_MultiSpaces_Title(dto.Image)

            };
            return repository.Update(entity);
        }

        public Publisher Delete(int id)
        {

            var publisher = GetDetail(id);
            return repository.Delete(id);
        }


    }
}