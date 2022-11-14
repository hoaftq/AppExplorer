import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-add-name-entity',
  templateUrl: './add-name-entity.component.html',
  styleUrls: ['./add-name-entity.component.scss']
})
export class AddNameEntityComponent {

  @Input()
  entityName: string;

  @Output()
  add = new EventEmitter<string>();

  formGroup = this.fb.group(
    { name: this.fb.control('', Validators.required) }
  );

  get name() {
    return this.formGroup.get('name');
  }

  constructor(private fb: FormBuilder) { }

  addEntity() {
    this.formGroup.markAllAsTouched();
    if (this.formGroup.valid) {
      this.add.emit(this.name.value);
      this.formGroup.reset();
    }
  }
}
