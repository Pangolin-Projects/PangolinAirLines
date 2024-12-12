import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClient, HttpClientModule, HttpHeaders } from "@angular/common/http";
import { Flight } from '../../models/Flight';
import { Router } from "@angular/router";

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [FormsModule, HttpClientModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {
  flight: Flight = new Flight('','',0,'',''); // Inicializa vazio para ser preenchido no formulário
  error: string | null = null;

  constructor(private http: HttpClient, private router: Router) {}
 
    onRegister() {
      console.log(this.flight)
      const token = localStorage.getItem("apiToken")

      const headers = new HttpHeaders({
        'Authorization': `Bearer ${token}`,
      });
  
      this.http.post<Flight[]>('http://localhost:5222/v1/flight/',this.flight,{headers})
      .subscribe({
        next: (result) => {
         console.log(result)
        },
        error: (err) => {
          this.error = err.message;
        },
      });
   }

}