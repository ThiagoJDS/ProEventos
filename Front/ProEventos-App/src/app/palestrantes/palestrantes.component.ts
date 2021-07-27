import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-palestrantes',
  templateUrl: './palestrantes.component.html',
  styleUrls: ['./palestrantes.component.scss']
})
export class PalestrantesComponent implements OnInit {

  public palestrantes: any;

  constructor() { }

  ngOnInit() {
    this.getPalestrantes();
  }

  getPalestrantes(): void{
    this.palestrantes = [
      {
        Nome: 'Thiago',
        Idade: '32',
        Estuda: 'Angular 11'
      },
      {
        Nome: 'Juliano',
        Idade: '32',
        Estuda: '.NET 5'
      },
      {
        Nome: 'Silva',
        Idade: '32',
        Estuda: 'Banco de Dados'
      }
    ]
  }

}
