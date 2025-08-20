import { Component, inject, OnInit, signal } from '@angular/core';
import { Client } from '../../../generated/nswag-client';

@Component({
  selector: 'td-start',
  imports: [],
  templateUrl: './start.component.html',
  styleUrl: './start.component.css',
  providers: [Client]
})
export class StartComponent implements OnInit {
  client = inject(Client);
  response = signal<string>('Waiting for API response...');

  ngOnInit() {
    this.client.dummy('1.0').subscribe({
      next: (response) => {
        this.response.set(response.message);
      },
      error: (error) => {
        this.response.set('API error: ' + error);
      }
    });
  }

}
