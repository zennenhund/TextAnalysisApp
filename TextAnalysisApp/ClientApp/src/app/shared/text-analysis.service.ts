import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
    providedIn: 'root'
  })

export class TextAnalysisService {
    _baseUrl: string;

    constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this._baseUrl = baseUrl;
     }

    getSymbolsCount(textModel: any) {
        return this.http.post(this._baseUrl + 'api/TextAnalysis', textModel);
    }
}
