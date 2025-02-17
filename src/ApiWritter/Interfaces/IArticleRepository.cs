﻿using ApiWritter.Models;

namespace ApiWritter.Interfaces
{
    public interface IArticleRepository
    {
        IEnumerable<Article> GetAll();

        Article? GetById(int id);

        Article Insert(Article article);
    }
}
