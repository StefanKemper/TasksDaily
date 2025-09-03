import { ApplicationConfig, provideZoneChangeDetection } from '@angular/core';
import { provideRouter } from '@angular/router';

import { routes } from './app.routes';
import { provideHttpClient } from '@angular/common/http';
import { API_BASE_URL } from '../generated/nswag-client';
import { environment } from '../environments/environment';
import { provideAuth } from 'angular-auth-oidc-client';

export const appConfig: ApplicationConfig = {
  providers: [
    provideZoneChangeDetection({ eventCoalescing: true }),
    provideRouter(routes),
    provideHttpClient(),
    { provide: API_BASE_URL, useValue: environment.apiBaseUrl },
    provideAuth({
      config: {
        authority: 'https://auth.stefan-kemper.de/realms/Apps',
        redirectUrl: `${environment.applicationBaseUrl}/loggedin`,
        postLogoutRedirectUri: window.location.origin,
        clientId: environment.oidcClintId,
        scope: 'openid profile email todo',
        responseType: 'code',
        silentRenew: true,
        useRefreshToken: true,
      }
    })
  ]
};
