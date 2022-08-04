import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/Models/User';
import { UserDataService } from 'src/app/Services/user-data.service';

declare var window: any;

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {

  addorupdatemodal: any;

  userForm: User = {
    firstName: '',
    lastName: '',
  };

  users:User[] = [];
  constructor(private userService:UserDataService) { }
 
  ngOnInit(): void {
    this.getUsers();

    this.addorupdatemodal = new window.bootstrap.Modal(
      document.getElementById('addOrUpdateModal')
    );
  }
 
  getUsers(){
    this.userService.getUsers()
    .subscribe({
      next:(data) => {
        this.users = data;
      },
      error:(err) => {
        console.log(err);
      }
    })
  }

  openAddOrUpdateModal() {
      this.addorupdatemodal.show();
  }

  createorUpdateUser() {
      this.userService.createUser(this.userForm).subscribe({
        next: (data) => {
          this.users.unshift(data);
           this.addorupdatemodal.hide();
        },
        error: (error) => {
          console.log(error);
        },
      });
    }

}
