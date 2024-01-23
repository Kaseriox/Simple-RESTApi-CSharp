using Database.Data;

namespace Articles.API.Repository.Topic;
using Database.Models;
public class TopicRepository : GenericRepository<Topic> , ITopicRepository
{
    public TopicRepository(ArticleContext articleContext) : base(articleContext)
    {
    }
    
}