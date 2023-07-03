import { Component, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
@Component({
  template: ''
})

// This component is used to destroy all subscriptions when the component is destroyed.
export class DestroySubscriptionsComponent implements OnDestroy {
  private subscription: Subscription | undefined = new Subscription();
  constructor() {}
  ngOnDestroy() {
    if (this.subscription) this.subscription.unsubscribe();
  }
  protected resetSubscriptions() {
    if (this.subscription) this.subscription.unsubscribe();
  }
  addSubscription(sub: Subscription | undefined) {
    this.subscription?.add(sub);
  }
  removeSubscription(sub: Subscription) {
    this.subscription?.remove(sub);
  }
  set setNewSubscription(sub: Subscription | undefined) {
    this.subscription?.add(sub);
  }
}
