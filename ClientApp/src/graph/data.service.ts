import { Injectable, Component, Inject } from "@angular/core";

@Injectable()
export class DataService {
  constructor() {
  }

  // cache
  public setCached(): void {
    sessionStorage.setItem("MSGraphDemo", "logIn");
  }

  public getCached(): string | null {
    var cached: string | null = sessionStorage.getItem("MSGraphDemo");
    if (cached === null || cached === undefined) {
      return null;
    }
    return cached;
  }

  public unloadCached(): void {
    sessionStorage.removeItem("MSGraphDemo");
  }
}
