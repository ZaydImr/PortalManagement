import { CanActivateFn } from '@angular/router';

export const hasRolesGuard: CanActivateFn = (route, state) => {
  return true;
};
