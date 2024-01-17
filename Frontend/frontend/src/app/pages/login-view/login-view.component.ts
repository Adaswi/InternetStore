import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../auth.service';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { DurationInputArg1 } from 'moment';
import moment from 'moment';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-login-view',
  standalone: true,
  imports: [FormsModule, ReactiveFormsModule, CommonModule],
  templateUrl: './login-view.component.html',
  styleUrl: './login-view.component.scss'
})
export class LoginViewComponent {

  form: FormGroup;
  error: any = '';

  constructor(private fb: FormBuilder, private authService: AuthService,
    private router: Router) {
    this.form = this.fb.group({
      email: ['', Validators.required],
      password: ['', Validators.required]
    });
  }

  login() {
    const val = this.form.value;

    if ((val.email && val.password)) {
      console.log('poop');

      this.authService.login(val.email, val.password)
        .subscribe(
          (response: any) => {
            console.log(response);
            this.router.navigateByUrl('/');
            this.setSession(response);
          }, error => {
            console.log(error.error);
            this.error = error.error;
          }
        );
    }
    else
    {
      {{this.error = 'All fields are required'}}
    }
  }

  private setSession(authResult: { expiresIn: DurationInputArg1; token: string; user:Object}) {
    const expiresAt = moment().add(authResult.expiresIn,'second');

    localStorage.setItem('id_token', authResult.token);
    localStorage.setItem("expires_at", JSON.stringify(expiresAt.valueOf()) );
    localStorage.setItem('user', JSON.stringify(authResult.user));
}  

logout() {
  localStorage.removeItem("id_token");
  localStorage.removeItem("expires_at");
}

public isLoggedIn() {
  return moment().isBefore(this.getExpiration());
}

isLoggedOut() {
  return !this.isLoggedIn();
}

getExpiration() {
  const expiration = localStorage.getItem("expires_at");
  const expiresAt = JSON.parse(expiration!);
  return moment(expiresAt);
}  
}