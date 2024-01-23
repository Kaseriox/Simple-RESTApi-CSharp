namespace Articles.Contract.User;

public record UserResponse(
    int Id,
    string Username,
    string Password
    );