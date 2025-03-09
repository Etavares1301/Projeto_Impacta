import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { EmployeesService } from './employees.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'Funcionários';

  formGroupEmployes!: FormGroup

  constructor(
    private formBilder: FormBuilder,
    private _employesService: EmployeesService,
    private toastr: ToastrService
  ) { }

  ngOnInit(): void {
    this.createForm();
    this.getEmployees();
  }

  createForm(): void {
    this.formGroupEmployes = this.formBilder.group({
      name: new FormControl(['']),
      lastName: new FormControl(['']),
      department: new FormControl([null]),
      shift: new FormControl([null]),
    });
  }

  getEmployees(): void {
    this._employesService.getEmployees().subscribe(
      (response: any) => {
        let dados = response && response.dados
        console.table(dados);
      },
      (error: any) => {
        console.error(error);
      }
    );
  }

  onSave() {
    let formEmployesVM = {
      name: this.formGroupEmployes.get('name')?.value,
      lastName: this.formGroupEmployes.get('lastName')?.value,
      department: Number(this.formGroupEmployes.get('department')?.value),
      shift: Number(this.formGroupEmployes.get('shift')?.value),
    };

    try {
      this._employesService.register(formEmployesVM).subscribe({
        next: () => {
          this.toastr.success(`Cadastrado com sucesso!`);
          this.formGroupEmployes.reset();
          setTimeout(() => {
            this.toastr.toastrConfig.preventDuplicates = true;
          }, 1000);
        },
        error: (e: any) => {
          this.toastr.toastrConfig.preventDuplicates = true;
          var mensagemTratada = e.message.replace('Error:', '');
          if (mensagemTratada.includes('[object Object]')) {
            this.toastr.error('Erro ao tentar cadastrar');
            return;
          } else {
            this.toastr.error('Erro ao tentar cadastrar');
          }
        },
      });
    }
    catch (error: any) {
      console.error(error);
    }


  }
}
