import { ApplicationRef, ComponentFactoryResolver, Injectable, Injector } from '@angular/core';
import { LoadingComponent } from '../components/loading/loading.component';

@Injectable({
  providedIn: 'root'
})
export class LoadingService {
  private spinnerRef: any;

  constructor(
    private componentFactoryResolver: ComponentFactoryResolver,
    private appRef: ApplicationRef,
    private injector: Injector
  ) {}

  show(): void {
    if(!this.spinnerRef) {
      const factory = this.componentFactoryResolver.resolveComponentFactory(LoadingComponent);

      this.spinnerRef = factory.create(this.injector);
      this.appRef.attachView(this.spinnerRef.hostView);

      const domElem = (this.spinnerRef.hostView as any).rootNodes[0] as HTMLElement;

      document.body.appendChild(domElem);
    }
  }

  hide(): void {
    if(this.spinnerRef) {
      this.appRef.detachView(this.spinnerRef.hostView);
      this.spinnerRef.destroy();
      this.spinnerRef = null;
    }
  }
}
