import { Component, OnInit } from '@angular/core';
import {HttpClient, HttpClientModule, HttpHeaders} from "@angular/common/http";
import {Flight} from "../../models/Flight";
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [ HttpClientModule, CommonModule],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.css'
})
export class DashboardComponent implements OnInit {

  flights: Flight[] = [];
  error: string | null = null;

  constructor(private http: HttpClient) {
  }


  ngOnInit() {
    this.fetchFlights();
  }

  fetchFlights() {
    const token = localStorage.getItem('apiToken'); // Adjust token retrieval as needed
    console.log(token);
    const headers = new HttpHeaders({
      'Authorization': `Bearer ${token}`,
    });
    console.log('Making request with headers:', headers);

    this.http.get<Flight[]>('http://localhost:5222/v1/flights', { headers })
      .subscribe({
        next: (result) => {
          console.log('Fetched Flights:', result);
          this.flights = result.map(flight => new Flight(flight.id, flight.airCraft, flight.availableSits, flight.landing, flight.takeOff));
        },
        error: (err) => {
          this.error = err.message;
        },
      });




    /*onRegister()
    {
      debugger;


      this.flight.landing = 'sometinh';
      this.flight.takeOff = 'sometinh';
      this.flight.availableSits = 11;
      this.flight.airCraft = 'sometinh';

      this.http.post('http://localhost:5222/v1/flight', this.flight).subscribe((res:any) => {
        this.flight = res.data;
      } , error => {
        alert("Error From API")
      })
    }*/
  }
}
