import { Component, inject, OnInit } from '@angular/core';
import { Client } from '../../generated/nswag-client';
import { OidcSecurityService } from 'angular-auth-oidc-client';
import { JsonPipe } from '@angular/common';

@Component({
  selector: 'td-loggedin',
  imports: [],
  templateUrl: './loggedin.component.html',
  styleUrl: './loggedin.component.css',
  providers: [OidcSecurityService]
})
export class LoggedinComponent implements OnInit {


 ngOnInit() {

  }
}
