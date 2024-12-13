import { Component, OnInit } from '@angular/core';
import { HttpClient,  HttpClientModule, HttpHeaders} from "@angular/common/http";
import { Flight } from "../../models/Flight";
import { CommonModule } from '@angular/common';
import { Router, ActivatedRoute } from "@angular/router";

@Component({
  selector: 'app-edit',
  standalone: true, 
  imports: [ HttpClientModule, CommonModule],
  templateUrl: './edit.component.html',
  styleUrl: './edit.component.css'
})
export class EditComponent {
  flights: Flight[] = [];
  error: string | null = null;

  constructor(private http: HttpClient, private router:Router) {
  }

  onEdit() {
    console.log('Edit button clicked. Flight ID:', );
 
  }
}
