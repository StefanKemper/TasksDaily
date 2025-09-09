namespace TasksDaily.Core.BLL.Dto
{
  public class UserDto
  {
    public Guid Id { get; set; } = Guid.Empty;
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? FirstName { get; set; }
    public string? LastName { get; set; }

    public UserDto(System.Security.Claims.ClaimsPrincipal user)
    {
      if (user == null) 
        throw new ArgumentNullException(nameof(user));
      
      var idClaim = user.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
      
      if (idClaim == null) 
        throw new InvalidOperationException("User ID claim not found.");
      
      Id = Guid.Parse(idClaim);
      Username = user.FindFirst("preferred_username")?.Value ?? throw new InvalidOperationException("Username not found.");     
      Email = user.FindFirst(System.Security.Claims.ClaimTypes.Email)?.Value
              ?? throw new InvalidOperationException("Email claim not found.");

      FirstName = user.FindFirst("given_name")?.Value;
      LastName = user.FindFirst("family_name")?.Value;

      if (FirstName == null || LastName == null)
      {
        var fullName = user.FindFirst("name")?.Value;
        if (!string.IsNullOrEmpty(fullName) && fullName.Contains(' '))
        {
          var names = fullName.Split(' ', 2);
          if (names.Length > 0 && FirstName == null) FirstName = names[0];
          if (names.Length > 1 && LastName == null) LastName = names[1];
        }
      }
    }
  }
}
