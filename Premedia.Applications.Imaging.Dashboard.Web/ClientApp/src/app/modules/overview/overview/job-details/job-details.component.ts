import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-job-details',
  templateUrl: './job-details.component.html',
  styleUrls: ['./job-details.component.scss']
})
export class JobDetailsComponent {
  jobID : string | undefined;

  constructor(private route : ActivatedRoute){
    /*this.route.params.subscribe(params => {
      this.jobID = params['id'];
    })*/
  }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.jobID = params['id'];
      console.log('Job ID:', this.jobID);
    });
  }
}
