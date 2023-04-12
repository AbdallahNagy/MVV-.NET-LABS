namespace LastLec.MVC.DTOs;

public record LoginDTO(string username, string password);
public record RegisterDTO(string username, string password, string email, DateTime birthDate);