import { Component, inject, OnInit, signal } from '@angular/core';
import { Client } from '../../../generated/nswag-client';
import { environment } from '../../../environments/environment';
import { OidcSecurityService } from 'angular-auth-oidc-client';

@Component({
  selector: 'td-start',
  imports: [],
  templateUrl: './start.component.html',
  styleUrl: './start.component.css',
  providers: [Client, OidcSecurityService]
})
export class StartComponent implements OnInit {
  client = inject(Client);
  authService = inject(OidcSecurityService);
  response = signal<string>('Waiting for API response...');

  ngOnInit() {



    this.client.dummy(environment.apiVersion).subscribe({
      next: (response) => {
        this.response.set(response.message);
      },
      error: (error) => {
        this.response.set('API error: ' + error);
      }
    });
  }

}
