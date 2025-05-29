import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterOutlet } from '@angular/router';
import { Menu1Service } from './services/menu1.service';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, FormsModule, CommonModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'Angular App';
  name = ''
  isNameVisible = false;
  ldrpStudents = ['Jay', 'Ajay', 'Vijay']

  constructor(private Menu1Service: Menu1Service) { }

  onClick(){
    this.isNameVisible = !this.isNameVisible;
    console.log("isNameVisible:", this.isNameVisible);
    console.log("in component");
    this.Menu1Service.onSubmit(this.name);
  }
}