import { Injectable } from '@angular/core'; 
@Injectable()
export class Configuration {
    public Server: string = "http://localhost:57130/";
    public ApiUrl: string = "api/";
    public ServerWithApiUrl = this.Server + this.ApiUrl;
}

http://offering.solutions/articles/angular/rest-api-angular2-http-typescript/