namespace webAPI_day2.DTOs.Responses;

public class LoginSuccessResponse
{
    public LoginSuccessResponse() { }

    public LoginSuccessResponse(string token)
    {
        Token = token;
    }

    public string Token { get; set; }
}