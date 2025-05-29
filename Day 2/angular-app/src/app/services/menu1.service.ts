import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class Menu1Service {
  onSubmit(name: string) {
    console.log('Submitted name:', name);
  }
}
