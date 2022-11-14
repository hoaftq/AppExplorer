import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormControl, Validators } from '@angular/forms';

@Component({
  selector: '[app-edit-name-entity]',
  templateUrl: './edit-name-entity.component.html',
  styleUrls: ['./edit-name-entity.component.scss']
})
export class EditNameEntityComponent implements OnInit {

  @Input()
  originalValue: string;

  @Output()
  save = new EventEmitter<string>();

  isEditting: boolean;

  nameControl: FormControl;

  constructor(private fb: FormBuilder) { }

  ngOnInit(): void {
    this.nameControl = this.fb.control(this.originalValue, Validators.required);
  }

  editName() {
    this.isEditting = true;
    this.nameControl.setValue(this.originalValue);
  }

  saveName() {
    this.nameControl.markAsTouched();

    if (this.nameControl.valid) {
      this.save.emit(this.nameControl.value);

      this.nameControl.reset();
      this.isEditting = false;
    }
  }

  cancel() {
    this.isEditting = false;
  }
}
