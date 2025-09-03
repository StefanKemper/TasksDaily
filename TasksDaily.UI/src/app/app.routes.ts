import { Routes } from '@angular/router';
import { StartComponent } from './dashboard/start/start.component';
import { LoggedinComponent } from './loggedin/loggedin.component';

export const routes: Routes = [
  { path: '', component: StartComponent },
  { path: 'loggedin', component: LoggedinComponent }
];
