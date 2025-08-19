import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { StartComponent } from "./dashboard/start/start.component";

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, StartComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'TasksDaily.UI';
}
