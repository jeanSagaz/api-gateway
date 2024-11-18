using ApiArticle.Interfaces;
using ApiArticle.Models;

namespace ApiArticle.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly static List<Article> _articles = Populate();

        private static List<Article> Populate()
        {
            return new List<Article>()
            {
                new Article()
                {
                    Id = 1,
                    Name = ".Net Core"
                },
                new Article()
                {
                    Id = 2,
                    Name = "Angular"
                },
                new Article()
                {
                    Id = 3,
                    Name = "GoLang"
                }
            };
        }

        public IEnumerable<Article> GetAll() => _articles.ToList();

        public Article? GetById(int id) => _articles.FirstOrDefault(x => x.Id == id);

        public Article Insert(Article writer)
        {
            _articles.Add(writer);

            return writer;
        }
    }
}
