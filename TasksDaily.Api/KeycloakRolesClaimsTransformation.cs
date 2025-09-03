using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace TasksDaily.Api
{
  public class KeycloakRolesClaimsTransformation : IClaimsTransformation
  {
    public Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
    {
      var identity = (ClaimsIdentity)principal.Identity!;

      // Realm-Rollen
      var realmRoles = principal.FindFirst("realm_access")?.Value;
      if (realmRoles != null)
      {
        var roles = System.Text.Json.JsonDocument.Parse(realmRoles)
            .RootElement.GetProperty("roles")
            .EnumerateArray()
            .Select(r => r.GetString());

        foreach (var role in roles!)
          identity.AddClaim(new Claim(identity.RoleClaimType, role!));
      }

      // Client-Rollen
      var resourceAccess = principal.FindFirst("resource_access")?.Value;
      if (resourceAccess != null)
      {
        var clients = System.Text.Json.JsonDocument.Parse(resourceAccess).RootElement;
        foreach (var client in clients.EnumerateObject())
        {
          if (client.Value.TryGetProperty("roles", out var clientRoles))
          {
            foreach (var role in clientRoles.EnumerateArray())
              identity.AddClaim(new Claim(identity.RoleClaimType, role.GetString()!));
          }
        }
      }

      return Task.FromResult(principal);
    }
  }
}
