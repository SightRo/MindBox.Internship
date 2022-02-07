namespace MindBox.Geometry;

public class UserFriendlyException : Exception
{
    public string UserMessage { get; }

    public UserFriendlyException(string userMessage)
    {
        UserMessage = userMessage;
    }

    public UserFriendlyException(string userMessage, string developerMessage)
        : base(developerMessage)
    {
        UserMessage = userMessage;
    }

    public UserFriendlyException(string userMessage, string developerMessage, Exception inner)
        : base(developerMessage, inner)
    {
        UserMessage = userMessage;
    }
}

public class ValidationException : UserFriendlyException
{
    public string? ParameterName { get; }

    public ValidationException(string userMessage, string parameterName)
        : base(userMessage, $"Incorrect property value {parameterName}")
    {
        ParameterName = parameterName;
    }
    
    public ValidationException(string userMessage)
        : base(userMessage, "Validation failed")
    {
    }
}