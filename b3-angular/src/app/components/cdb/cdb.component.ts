import { Component, OnInit, Type } from '@angular/core';
import { CdbServiceService } from '../../services/cdb-service.service';
import { FormsModule, ReactiveFormsModule, UntypedFormBuilder, UntypedFormGroup, Validators } from '@angular/forms';
import { InvestmentProjection } from '../../models/investment-projection';
import { min } from 'rxjs';

@Component({
  selector: 'app-cdb',
  standalone: true,
  imports: [FormsModule, ReactiveFormsModule],
  templateUrl: './cdb.component.html',
  styleUrl: './cdb.component.css'
})
export class CDBComponent implements OnInit {

  form: UntypedFormGroup = this.fb.group({
    value: [null, Validators.required],
    months: [null, Validators.required]
  });

  investmentProjection?: InvestmentProjection;
  
  constructor(private calculatorService: CdbServiceService, private fb: UntypedFormBuilder) { }

  ngOnInit(): void { 
    
  }

  onSubmit() {
    if(this.form.valid)
    {
    this.calculatorService.calculate(parseFloat(this.form.controls["value"].value), parseInt(this.form.controls["months"].value))
      .subscribe( (res) => {
        this.investmentProjection = res;
      });
    }
    else 
     alert("Preencha todos os campos");
  }

}
