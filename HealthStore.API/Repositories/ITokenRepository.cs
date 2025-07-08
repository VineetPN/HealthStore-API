using Microsoft.AspNetCore.Identity;

namespace HealthStore.API.Repository;

public interface ITokenRepository {
    string CreateJWTToken(IdentityUser userName, List<string> roles);
}