import { HttpHandlerFn, HttpRequest } from "@angular/common/http";
import { inject } from "@angular/core";
import { TokenService } from "../services/token.service";

export function TokenInterceptor(request: HttpRequest<unknown>, next: HttpHandlerFn) {
    const tokenService = inject(TokenService);
    let user = tokenService.getUser();
    const clonedRequest = request.clone({
        setHeaders: {
            Authorization: `Bearer ${user?.token}`
        }
    });
    return next(clonedRequest).pipe()
}