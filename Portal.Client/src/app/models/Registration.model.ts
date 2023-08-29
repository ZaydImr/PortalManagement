// registration-vm.model.ts
export class Registration {
    UserName?: string;
    Email?: string;
    Name?: string;
    PhoneNumber?: string;
    Password?: string;
    Roles?: string[];
  
    constructor() {
      this.Roles = [];
    }
  }
  