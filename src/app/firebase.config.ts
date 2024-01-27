import { EnvironmentProviders, importProvidersFrom } from "@angular/core";
import { provideFirebaseApp, initializeApp } from '@angular/fire/app';
import { getFirestore, provideFirestore } from '@angular/fire/firestore';
import { environment } from "../environments/environment";

const fireBaseProviders: EnvironmentProviders = importProvidersFrom(
    provideFirebaseApp(() => initializeApp(environment.firebase)),
    provideFirestore(() => getFirestore()),
);

export { fireBaseProviders };