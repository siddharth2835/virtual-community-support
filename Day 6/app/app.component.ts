import { NgIf } from "@angular/common"
import { Component, OnDestroy, OnInit } from "@angular/core"
import { FormBuilder, FormControl, FormGroup, ReactiveFormsModule, Validators } from "@angular/forms"
import { Router, RouterModule } from "@angular/router"
import { NgToastService } from "ng-angular-popup"
import { Subscription } from "rxjs"
import { APP_CONFIG } from "src/app/configs/enviroment.config"
import { AuthService } from "src/app/services/auth.service"

@Component({
  selector: "app-login",
  standalone: true,
  imports: [ReactiveFormsModule, NgIf, RouterModule],
  templateUrl: "./app.component.html",
  styleUrls: ["./app.component.css"],
})
export class LoginComponent implements OnInit, OnDestroy {
  private unsubscribe: Subscription[] = [];
  
  constructor(
    private _fb: FormBuilder,
    private _service: AuthService,
    private _router: Router,
    private _toast: NgToastService,
  ) { }
  loginForm!: FormGroup
  formValid!: boolean
  ngOnInit(): void {
    this.loginUser()
  }
  loginUser() {
    this.loginForm = this._fb.group({
      emailAddress: [null, Validators.compose([Validators.required, Validators.email])],
      password: [null, Validators.compose([Validators.required])],
    })
  }
  get emailAddress() {
    return this.loginForm.get("emailAddress") as FormControl
  }
  get password() {
    return this.loginForm.get("password") as FormControl
  }
  onSubmit() {
    this.formValid = true
    if (this.loginForm.valid) {
      const loginUserSubscribe = this._service
        .loginUser([this.loginForm.value.emailAddress, this.loginForm.value.password])
        .subscribe((res: any) => {
          if (res.result == 1) {
            if (res.data.message == "Login Successfully") {
              this._service.setToken(res.data.data)
              const tokenpayload = this._service.decodedToken()
              this._service.setCurrentUser(tokenpayload)

              this._toast.success(res.data.message)
              if (tokenpayload.userType == "admin") {
                this._router.navigate(["admin/dashboard"])
              } else {
                this._router.navigate(["/home"])
              }
            } else {
              // this.toastr.error(res.data.message);
              this._toast.danger(res.data.message)
            }
          } else {
            // this.toastr.error(res.message);
            this._toast.danger(res.message)
          }
        })
      this.formValid = false
      this.unsubscribe.push(loginUserSubscribe);
    }
  }
  ngOnDestroy() {
    this.unsubscribe.forEach((sb) => sb.unsubscribe())
  }
}
