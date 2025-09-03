import { HttpHeaders } from "@angular/common/http";
import { inject } from "@angular/core";
import { OidcSecurityService } from 'angular-auth-oidc-client';
import { firstValueFrom, map } from "rxjs";

export class AuthorizationHeaderProvider {
  private oidcSecurityService = inject(OidcSecurityService);

  getAuthorizationHeader(options: any): Promise<any> {
    let headers = options.headers || new HttpHeaders();

    const obs = this.oidcSecurityService.getAccessToken().pipe(map(token => {
      const authHeader = `Bearer ${token}`;
      options.headers = headers.set('Authorization', authHeader);

      return options;
    }));

    return firstValueFrom(obs);
  }
}
