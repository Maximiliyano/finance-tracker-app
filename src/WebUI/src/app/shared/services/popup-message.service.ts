import { Injectable, NgZone } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class PopupMessageService {
  private defaultDuration: number = 3000;
  private messageContainer: HTMLDivElement | null = null;

  constructor(private readonly zone: NgZone) {}

  warning(message: string, duration: number = this.defaultDuration): void {
    this.display(message, "warning", duration);
  }

  error(message: string, duration: number = this.defaultDuration): void {
    this.display(message, "error", duration);
  }

  success(message: string, duration: number = this.defaultDuration): void {
    this.display(message, "success", duration);
  }

  private display(message: string, type: 'success' | 'warning' | 'error', duration: number): void {
    this.zone.run(() => {
      this.createPopup(message, type);

      setTimeout(() => this.removePopup(), 99999999999); // TODO don't word duration
    });
  }

  private createPopup(message: string, type: 'success' | 'warning' | 'error'): void {
    if (this.messageContainer) {
      this.removePopup();
    }

    this.messageContainer = document.createElement('div');
    this.messageContainer.className = `popup-message ${type}`;
    this.messageContainer.innerHTML = `
      <div class="popup-icon">${this.getIcon(type)}</div>
      <div class="popup-text">${message}</div>
    `;// TODO fix styles with long text
    // TODO add ability to see multiples popups
    document.body.appendChild(this.messageContainer);
  }

  private getIcon(type: 'success' | 'warning' | 'error'): string {
    switch (type) {
      case 'success':
        return '✔️';
      case 'warning':
        return '⚠️';
      case 'error':
        return '❌';
      default:
        return '';
    }
  }

  private removePopup(): void {
    if (this.messageContainer) {
      this.messageContainer.remove();
      this.messageContainer = null;
    }
  }
}
