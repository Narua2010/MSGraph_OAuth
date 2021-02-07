import { Component } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { AppConfig } from './appConfig';
import { GraphService } from '../app/api/api/graph.service';

var cryptObj = window.crypto;

@Component({
  providers: [ActivatedRoute]
})
export class Authentication {
  private tokenCacheKey: string = "token";

  constructor(private activatedRoute: ActivatedRoute, private graphService: GraphService) {

  }

  guid() {
    var buf = new Uint16Array(8);
    cryptObj.getRandomValues(buf);
    function s4(num: number) {
      var ret = num.toString(16);
      while (ret.length < 4) {
        ret = '0' + ret;
      }
      return ret;
    }
    return s4(buf[0]) + s4(buf[1]) + '-' + s4(buf[2]) + '-' + s4(buf[3]) + '-' + s4(buf[4]) + '-' + s4(buf[5]) + s4(buf[6]) + s4(buf[7]);
  }

  login() {
    sessionStorage.nonce = this.guid();


    sessionStorage.state = this.guid();


    window.location.href = "https://login.microsoftonline.com/" + AppConfig.TENANT_ID + "/oauth2/v2.0/authorize?"
      + "client_id=" + AppConfig.CLIENT_ID
      + "&response_type=code"
      + "&redirect_uri=" + AppConfig.REDIRECT_URI
      + "&response_mode=query"
      + "&scope=user.read"
      + "&state=" + sessionStorage.state;
  }

  public handleCallback(onSuccess: () => void, onFailure: () => void): void {
    this.activatedRoute.queryParams.subscribe((params: Params) => {
      console.log(params);
      if (params.code != null && params.code != "undefined") {
        this.graphService.apiGraphPost(JSON.stringify(params.code))
          .subscribe(response => {
            console.log(response);
          });
      }
    });
  }
}
