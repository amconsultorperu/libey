import swal from 'sweetalert2';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { LibeyUserService } from 'src/app/core/service/libeyuser/libeyuser.service';
import { documentType } from 'src/app/entities/documentType';
import { region } from 'src/app/entities/region';
import { province } from 'src/app/entities/province';
import { ubigeo } from 'src/app/entities/ubigeo';
import { LibeyUser } from 'src/app/entities/libeyuser';
import { Router } from '@angular/router';

@Component({
  selector: 'app-usermaintenance',
  templateUrl: './usermaintenance.component.html',
  styleUrls: ['./usermaintenance.component.css'],
})
export class UsermaintenanceComponent implements OnInit {
  frmUser: FormGroup;
  documentos: documentType[] = [];
  regions: region[] = [];
  provinces: province[] = [];
  ubigeos: ubigeo[] = [];
  constructor(
    private fb: FormBuilder,
    private libeyUserService: LibeyUserService,
    public router: Router
  ) {
    // this.inicialializarFormulario();
    this.frmUser = this.fb.group({
      tipoDocumento: ['', Validators.required],
      nroDocumento: ['', Validators.required],
      nombre: ['', Validators.required],
      apePaterno: ['', Validators.required],
      apeMaterno: ['', Validators.required],
      direccion: [''],
      departamento: ['', Validators.required],
      provincia: ['', Validators.required],
      distrito: ['', Validators.required],
      telefono: [''],
      correo: ['', Validators.required],
      constrasenia: ['', Validators.required],
    });

    this.frmUser.get('departamento')?.valueChanges.subscribe((codeRegion) => {
      this.getListProvinces(codeRegion);
    });
  }

  get f() {
    return this.frmUser.controls;
  }

  ngOnInit(): void {
    this.libeyUserService.ListDocumentTypes().subscribe((res) => {
      this.documentos = res;
    });

    this.libeyUserService.ListRegions().subscribe((res) => {
      this.regions = res;
    });
  }

  getListProvinces(codeRegion: string) {
    this.frmUser.patchValue({ provincia: '', distrito: '' });
    this.provinces = [];
    this.libeyUserService.ListProvinces(codeRegion).subscribe((res) => {
      this.provinces = res;
    });
  }

  getListDistrites(codeProvince: string) {
    this.frmUser.patchValue({ distrito: '' });
    this.libeyUserService
      .ListUbigeo(this.frmUser.get('departamento')?.value, codeProvince)
      .subscribe((res) => {
        this.ubigeos = res;
      });
  }

  Submit() {
    const dataUser = this.frmUser.value;
    const dataNewUser: LibeyUser = {
      documentNumber: dataUser.nroDocumento,
      documentTypeId: dataUser.tipoDocumento,
      name: dataUser.nombre,
      fathersLastName: dataUser.apePaterno,
      mothersLastName: dataUser.apeMaterno,
      address: dataUser.direccion,
      regionCode: dataUser.departamento,
      provinceCode: dataUser.provincia,
      ubigeoCode: dataUser.distrito,
      phone: dataUser.telefono,
      email: dataUser.correo,
      password: dataUser.constrasenia,
      active: true,
    };
    this.libeyUserService.createUser(dataNewUser).subscribe((res) => {
      console.log(res);
    });
  }

  clearUserform() {
    this.frmUser.reset();
  }

  return() {
    this.router.navigateByUrl('/user/card');
  }
}
