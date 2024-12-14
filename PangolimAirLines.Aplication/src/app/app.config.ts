import { ApplicationConfig } from '@angular/core';
import { provideRouter } from '@angular/router';
import { customInterceptor} from './services/custom.interceptor';
import { routes } from './app.routes';
import {provideHttpClient, withInterceptors} from "@angular/common/http";

export const appConfig: ApplicationConfig = {
  providers: [provideRouter(routes)]
};
