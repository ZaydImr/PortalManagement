import { CanActivateFn, Router } from '@angular/router';
import { inject } from "@angular/core";

export const authenticatedGuard: CanActivateFn = (route, state) => {
  const router: Router = inject(Router);

  console.log("test");
  
  return true;
};
