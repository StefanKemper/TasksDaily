import { Component, inject, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { StartComponent } from "./dashboard/start/start.component";
import { OidcSecurityService } from 'angular-auth-oidc-client';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  authService = inject(OidcSecurityService);
  test = 'Test';

  title = 'TasksDaily.UI';

  ngOnInit() {
    this.test = 'Init';

    //if(!this.authService.authenticated().isAuthenticated) {
    this.authService.checkAuth().subscribe({next: (response) => {
        const { isAuthenticated, accessToken, errorMessage } = response;
          this.test = isAuthenticated ? 'Authenticated' : 'Not Authenticated';

        if (!isAuthenticated && accessToken?.length < 1 && (errorMessage?.length ?? 0) < 1) {
          this.authService.authorize();
        }
      }});
    //}
  }

  login() {

  }
}
