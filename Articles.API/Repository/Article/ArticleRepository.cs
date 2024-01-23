using Database.Data;

namespace Articles.API.Repository.Article;
using Database.Models;
public class ArticleRepository : GenericRepository<Article> , IArticleRepository
{
    public ArticleRepository(ArticleContext articleContext) : base(articleContext)
    {
    }
}