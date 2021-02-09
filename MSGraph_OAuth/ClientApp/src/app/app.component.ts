import { Component } from '@angular/core';
import { Authentication } from '../graph/authentication';
import { DataService } from '../graph/data.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  providers: [Authentication, DataService]
})
export class AppComponent {
  title = 'app';

  constructor(private authentication: Authentication, private dataService: DataService) {
    if (this.dataService.getCached() == null) {
      this.dataService.setCached();
      this.authentication.login();
    }
  }
}
