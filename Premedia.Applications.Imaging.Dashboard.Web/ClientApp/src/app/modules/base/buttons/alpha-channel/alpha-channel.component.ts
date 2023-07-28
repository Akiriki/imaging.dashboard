import { Component, Inject } from '@angular/core';
import { ItemModel } from '@syncfusion/ej2-angular-splitbuttons';

@Component({
  selector: 'app-alpha-channel',
  templateUrl: './alpha-channel.component.html',
  styleUrls: ['./alpha-channel.component.scss']
})
export class AlphaChannelComponent {
  constructor(
    @Inject('sourceFiles') private sourceFiles: any
    )
    { sourceFiles.files = ['alpha-channel.component.scss']; }

    public items: ItemModel[] = [
    {
        text: '...',
    },
    {
        text: '...'
    },
    {
        text: '...'
    }];
}
