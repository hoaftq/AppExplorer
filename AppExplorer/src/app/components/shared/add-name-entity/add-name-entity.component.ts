import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-add-name-entity',
  templateUrl: './add-name-entity.component.html',
  styleUrls: ['./add-name-entity.component.scss']
})
export class AddNameEntityComponent implements OnInit {

  @Input()
  entityName: string;

  @Output()
  add = new EventEmitter<string>();

  placeHolder = "";

  formGroup = this.fb.group(
    { name: this.fb.control('', Validators.required) }
  );

  get name() {
    return this.formGroup.get('name');
  }

  constructor(private fb: FormBuilder) { }

  ngOnInit(): void {
    this.placeHolder = `Enter ${this.entityName.toLocaleLowerCase()}`;
  }

  addEntity() {
    this.formGroup.markAllAsTouched();
    if (this.formGroup.valid) {
      this.add.emit(this.name.value);
      alert(this.name.value)
      this.formGroup.reset();
    }
  }
}
