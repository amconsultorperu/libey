import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../environments/environment';
import { LibeyUser } from 'src/app/entities/libeyuser';
import { documentType } from 'src/app/entities/documentType';
import { region } from 'src/app/entities/region';
import { province } from 'src/app/entities/province';
import { ubigeo } from 'src/app/entities/ubigeo';
@Injectable({
  providedIn: 'root',
})
export class LibeyUserService {
  constructor(private http: HttpClient) {}
  Find(documentNumber: string): Observable<LibeyUser> {
    const uri = `${environment.pathLibeyTechnicalTest}LibeyUser/${documentNumber}`;
    return this.http.get<LibeyUser>(uri);
  }

  ListDocumentTypes(): Observable<documentType[]> {
    const uri = `${environment.pathLibeyTechnicalTest}LibeyUser/document-types/`;
    return this.http.get<documentType[]>(uri);
  }

  ListRegions(): Observable<region[]> {
    const uri = `${environment.pathLibeyTechnicalTest}LibeyUser/list-region/`;
    return this.http.get<region[]>(uri);
  }

  ListProvinces(codeRegion: string): Observable<province[]> {
    const uri = `${environment.pathLibeyTechnicalTest}LibeyUser/region/${codeRegion}/list-province/`;
    return this.http.get<province[]>(uri);
  }

  ListUbigeo(codeRegion: string, codeProvince: string): Observable<ubigeo[]> {
    const uri = `${environment.pathLibeyTechnicalTest}LibeyUser/region/${codeRegion}/province/${codeProvince}/list-ubigeo`;
    return this.http.get<ubigeo[]>(uri);
  }

  createUser(dataNewUser: LibeyUser): Observable<any> {
    const uri = `${environment.pathLibeyTechnicalTest}LibeyUser/Create`;
    return this.http.post<any>(uri, dataNewUser);
  }
}
