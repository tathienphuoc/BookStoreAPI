using BookStoreAPI.Repository;
using BookStoreAPI.Models;
using System.Collections.Generic;
using BookStoreAPI.Utils;
using System.Linq;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookStoreAPI.Service
{
    public class AuthorService
    {
        private AuthorRepository repository;
        private AuthorBookService authorBookService;
        public AuthorService(AuthorRepository repository)
        {
            this.repository = repository;

        }

        public List<Author> GetAll()
        {
            return repository.FindAll();
        }

        public Author GetDetail(int id)
        {
            return repository.FindById(id);
        }

        public Author GetDetail(string fullName)
        {
            fullName = FormatString.Trim_MultiSpaces_Title(fullName, true);
            return repository.FindAll().Where(c => c.FullName.Equals(fullName)).FirstOrDefault();
        }

        public bool Exist(List<Author> authors)
        {
            foreach (var author in authors)
            {
                if (GetDetail(author.Id) == null)
                {
                    return false;
                }
            }
            return true;
        }

        public Author Create(AuthorCreateDto dto)
        {

            var entity = new Author
            {
                FullName = dto.FullName,
                Biography = dto.Biography,
                Image = dto.Image

            };


            return repository.Add(entity);
        }

        public Author Update(AuthorUpdateDto dto)
        {
            // var isExist = GetDetail(dto.Name);
            // if (isExist != null && dto.Id != isExist.Id)
            // {
            //     throw new Exception(dto.Name + " existed");
            // }

            var entity = new Author
            {
                Id = dto.Id,
                FullName = dto.FullName,
                Biography = dto.Biography,
                Image = dto.Image,

            };
            return repository.Update(entity);
        }

        public Author Delete(int id)
        {
            var author = GetDetail(id);

            if (author.AuthorBooks != null)
                throw new Exception("Author has been used!");

            return repository.Delete(id);
        }


    }
}