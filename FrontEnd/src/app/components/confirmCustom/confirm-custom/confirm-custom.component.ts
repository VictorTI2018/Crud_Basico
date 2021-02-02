import { Component, OnInit } from '@angular/core';
import { MatDialog , MatDialogRef} from '@angular/material/dialog'

@Component({
  selector: 'app-confirm-custom',
  templateUrl: './confirm-custom.component.html',
  styleUrls: ['./confirm-custom.component.css']
})
export class ConfirmCustomComponent {

  constructor(public dialogRef: MatDialogRef<ConfirmCustomComponent>) { }

  public confirmMessage: string = ''

}
