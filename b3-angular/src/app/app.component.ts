import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { CDBComponent } from "./components/cdb/cdb.component";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, CDBComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'b3-angular';
}

