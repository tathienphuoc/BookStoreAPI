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
            return repository.FindById(id);
        }

        public Publisher GetDetail(string name)
        {
            name = FormatString.Trim_MultiSpaces_Title(name);
            return repository.FindAll().Where(c => c.Name.Equals(name)).FirstOrDefault();
        }

        public Publisher Create(PublisherCreateDto dto)
        {
            // dto.Name = FormatString.Trim_MultiSpaces_Title(dto.Name, true);
            // var isExist = GetDetail(dto.Name);
            // if (isExist != null)
            // {
            //     throw new Exception(dto.Name + " existed");
            // }
            var entity = new Publisher
            {
                Name = dto.Name,
                Image = dto.Image,
                Books = dto.Books
            };

            return repository.Add(entity);
        }

        public Publisher Update(PublisherUpdateDto dto)
        {
            // var isExist = GetDetail(dto.Name);
            // if (isExist != null && dto.Id != isExist.Id)
            // {
            //     throw new Exception(dto.Name + " existed");
            // }

            var entity = new Publisher
            {
                Id = dto.Id,
                Name = dto.Name,
                Image = dto.Image,
                Books = dto.Books

        };
            return repository.Update(entity);
        }


        public Publisher Delete(int id)
        {
            var publisher = GetDetail(id);

            // if (publisher.Books != null)
            //     throw new Exception("Publisher has been used!");

            return repository.Delete(id);
        }


    }
}