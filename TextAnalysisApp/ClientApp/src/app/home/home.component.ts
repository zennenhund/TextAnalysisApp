import { Component, OnInit } from '@angular/core';
import { TextAnalysisService } from '../shared/text-analysis.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  resultData: Array<TextAnalysisOutput>;
  textAnalysisForm: FormGroup;

  constructor(readonly textAnalysisService: TextAnalysisService,
    private fb: FormBuilder) { }

  ngOnInit() {
    this.createtextAnalysisForm();
  }

  onSubmit() {
    const text: TextAnalysisIntput = {
      text: this.textAnalysisForm.value.text
    };

    this.textAnalysisService.getSymbolsCount(text).subscribe((result: Array<TextAnalysisOutput>) => {
      this.resultData = result;
    });
  }

  resetForm() {
    this.textAnalysisForm.reset();
    this.resultData = null;
  }

  private createtextAnalysisForm(): void {
    this.textAnalysisForm = this.fb.group({
      text: ['', Validators.required],
    });
  }
}

interface TextAnalysisIntput {
  text: string;
}

interface TextAnalysisOutput {
  description: string;
}
