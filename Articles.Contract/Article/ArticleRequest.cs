namespace Articles.Contract.Article;
public record ArticleRequest(
    string Title,
    string Body,
    int UserId,
    int TopicId);