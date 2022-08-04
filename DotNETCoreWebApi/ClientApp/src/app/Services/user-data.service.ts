import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {User} from 'src/app/Models/User';
import { Observable } from 'rxjs';



@Injectable({
  providedIn: 'root'
})
export class UserDataService {

  readonly apiUrl = "https://localhost:7104/api";

  constructor(private httpClient: HttpClient) { }

  getUsers(): Observable<any> {
    return this.httpClient.get<User[]>(this.apiUrl + '/UsersData/GetAllUsers');
  }

  createUser(payload: User) {
    return this.httpClient.post<User>(this.apiUrl + '/UsersData/CreateUser',payload);
    
  }
}
