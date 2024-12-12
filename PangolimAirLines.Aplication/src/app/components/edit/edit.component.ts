import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Flight } from "../../models/Flight";
import { Router, ActivatedRoute } from "@angular/router";

@Component({
  selector: 'app-edit',
  standalone: true, 
  imports: [],
  templateUrl: './edit.component.html',
  styleUrl: './edit.component.css'
})
export class EditComponent implements OnInit {
  flightId: string | null = null;

  constructor(
    private http: HttpClient,
    private router: Router,
    private route: ActivatedRoute // Aqui está a injeção correta do ActivatedRoute
  ) {}

  ngOnInit(): void {
    // Pegando o ID da rota no momento que o componente é inicializado
    this.flightId = this.route.snapshot.paramMap.get('id');
    console.log('Flight ID:', this.flightId);
  }

  onEdit() {
    console.log('Edit button clicked. Flight ID:', this.flightId);
    // Aqui você pode implementar a lógica de edição
  }
}
