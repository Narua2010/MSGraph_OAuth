import { Authentication } from "../../graph/authentication";
import { Router } from '@angular/router';
import { Component } from "@angular/core";

@Component({
  templateUrl: './callback.component.html',
  styleUrls: ['./callback.component.css'],
  providers: [Authentication]
})

export class CallbackComponent {
  constructor(private router: Router, private authentication: Authentication) {
    
  }

  ngOnInit(): void {
    this.authentication.handleCallback(() => {
      this.router.navigate(["loggedIn"]);
    }, () => {
        this.authentication.login();
    });
  }

}
