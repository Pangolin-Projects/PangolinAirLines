import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Organization } from '../../models/Organization';
import {HttpClient} from "@angular/common/http";
import {HttpClientModule} from "@angular/common/http";
import {Router} from "@angular/router";
@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule, HttpClientModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  organization: Organization;

  constructor(private http: HttpClient, private router : Router) {
    this.organization = new Organization();
  }
  onLogin() {
    this.organization.email = 'latam';
    this.organization.password = 'latam'; 
    console.log(this.organization.email);
    console.log(this.organization.password);
    this.http.post('http://localhost:5222/v1/Login', this.organization).subscribe((res: any)=>
    {
      if(res.result)
      {
        localStorage.setItem('apiToken', res.data.token);
        this.router.navigate(['/dashboard']);
      }else{
        alert(res.message);
      }
    })
  }
}

