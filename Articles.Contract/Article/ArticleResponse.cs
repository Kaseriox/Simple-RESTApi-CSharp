
namespace Articles.Contract.Article;
public record ArticleResponse(
    int Id,
    string Title,
    string Body,
    int UserId,
    int TopicId
    );