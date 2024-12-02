import {Component, Inject} from '@angular/core';
import {MAT_DIALOG_DATA, MatDialogRef} from "@angular/material/dialog";
import {FormBuilder, FormGroup, Validators} from "@angular/forms";

@Component({
  selector: 'app-dialog-date-picker',
  templateUrl: './dialog-date-picker.component.html',
  styleUrl: './dialog-date-picker.component.scss'
})
export class DialogDatePickerComponent {
  datePickerForm: FormGroup;

  constructor(
      private fb: FormBuilder,
      public dialogRef: MatDialogRef<DialogDatePickerComponent>,
      @Inject(MAT_DIALOG_DATA) public data: DialogDatePickerComponentProps)
  {
    this.datePickerForm = this.fb.group({
      startDate: [this.data.startDate, Validators.required],
      endDate: [this.data.endDate, Validators.required],
      allTimeCheck: [this.data.allTime]
    });

    this.toggleAllTime();
  }

  onSubmit(): void {
    if (!this.datePickerForm.valid) {
      return;
    }

    const { startDate, endDate, allTimeCheck } = this.datePickerForm.value;

    this.dialogRef.close({
      startDate: startDate,
      endDate: endDate,
      allTime: allTimeCheck
    });
  }

  cancel(): void {
    this.dialogRef.close({
      startDate: this.data.startDate,
      endDate: this.data.endDate,
      allTime: this.data.allTime,
    });
  }

  toggleAllTime(): void {
    this.datePickerForm.get('allTimeCheck')?.valueChanges
      .subscribe({
        next: (value: boolean) => {
          if (value) {
            this.datePickerForm.get('startDate')?.disable();
            this.datePickerForm.get('endDate')?.disable();
          } else {
            this.datePickerForm.get('startDate')?.enable();
            this.datePickerForm.get('endDate')?.enable();
          }
        }
    });
  }
}

export interface DialogDatePickerComponentProps {
  startDate: Date | null;
  endDate: Date | null;
  allTime: boolean;
}
