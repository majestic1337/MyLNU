import { Component,Output,EventEmitter, ViewChild, OnInit } from '@angular/core';
import { FormControl, FormGroup, NgForm, Validators } from '@angular/forms';

@Component({
  selector: 'app-reg',
  templateUrl: './reg.component.html',
  styleUrls: ['./reg.component.css']
})
export class RegComponent implements OnInit{

  @Output() GoToLog = new EventEmitter<boolean>()
  inreg = true;

name:string = '';
email:string = '';
password: string = '';
valid:boolean = false;
reactiveForm!: FormGroup;

  ngOnInit(): void {
    this.reactiveForm = new FormGroup({
      name: new FormControl(null, Validators.required),
      email: new FormControl(null, [Validators.required, Validators.email]),
      password: new FormControl(null, [Validators.required, Validators.minLength(8)])
    })
  }


  // @ViewChild('regForm')
  // form!: NgForm;

Back(){
  this.inreg = !this.inreg;
  this.GoToLog.emit(this.inreg);
}

onSubmit(){
 console.log(this.reactiveForm)
  if(this.reactiveForm.valid){
    this.name = this.reactiveForm.get('name')?.value;
    this.email = this.reactiveForm.get('email')?.value;
    this.password = this.reactiveForm.get('password')?.value;
    this.valid = true
  }
}
}
