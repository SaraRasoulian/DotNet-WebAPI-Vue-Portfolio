<script setup>
import { RouterLink } from 'vue-router'
</script>

<template>
  <div class="content-container login-container">
    <div class="title-wrapper parent-page-title">
      <div class="login-title">
        <h4>Welcome back</h4>
      </div>
    </div>
    <hr class="line" />
    <div class="content">
      <div class="form-container">
        <form class="needs-validation">
          <div class="row g-3">
            <div class="col-lg-21 col-md-12 col-sm-12">
              <label for="user-name" class="form-label">User Name</label>
              <div class="input-group has-validation">
                <input type="text" id="user-name" class="form-control" placeholder="User Name">
                <div class="invalid-feedback">
                  Username is required.
                </div>
              </div>
            </div>
          </div>

          <div class="row g-3">
            <div class="col-lg-12 col-md-12 col-sm-12">
              <label for="password" class="form-label">Password</label>
              <input type="text" id="password" class="form-control" placeholder="Password">
              <div class="invalid-feedback">
                Password is required.
              </div>
            </div>
          </div>

          <div class="row">
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
              <div class="login-buttons">
                <RouterLink class="btn btn-login" to="/admin/profile">Log In</RouterLink>
                <RouterLink to="/" class="back-home">
                  Back to home page
                </RouterLink>
              </div>
            </div>
          </div>
        </form>
      </div>
    </div>

  </div>
</template>

<style>
@import '@/assets/admin/css/style.css';
@import '@/assets/admin/css/login.css';
</style>

<script>
import 'bootstrap'
import 'bootstrap/dist/css/bootstrap.min.css'
</script>