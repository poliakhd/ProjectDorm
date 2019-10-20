import { FormsModule } from '@angular/forms';
import { FeatureModule } from './modules/feature';
import { CoreModule, ApiInterceptor } from './modules/core';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { AppComponent } from './app.component';
import { ApiService } from './services/api.service';
import { AppRoutingModule } from './app-routing.module';
import { FeatureRoutingModule } from './modules/feature/feature-routing.module';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    CoreModule,
    FeatureModule,
    FeatureRoutingModule,
    AppRoutingModule
  ],
  providers: [
    ApiService, {
      provide: HTTP_INTERCEPTORS,
      useClass: ApiInterceptor,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
