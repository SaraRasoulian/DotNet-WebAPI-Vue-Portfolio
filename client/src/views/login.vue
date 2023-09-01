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
        <form class="needs-validation" novalidate="">
          <div class="row g-3">
            <div class="col-lg-21 col-md-12 col-sm-12">
              <label for="user-name" class="form-label">User Name</label>
              <div class="input-group has-validation">
                <input type="text" id="user-name" class="form-control" placeholder="User Name" required="" value="">
                <div class="invalid-feedback">
                  Username is required.
                </div>
              </div>
            </div>
          </div>

          <div class="row g-3">
            <div class="col-lg-12 col-md-12 col-sm-12">
              <label for="password" class="form-label">Password</label>
              <input type="text" id="password" class="form-control" placeholder="Password" value="">
              <div class="invalid-feedback">
                Password is required.
              </div>
            </div>
          </div>

          <div class="row">
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
              <div class="login-buttons">
                <RouterLink class="btn btn-login" to="/profile">Log In</RouterLink>
                <a class="back-home" href="/src/home/index.html">Back to home page</a>
              </div>
            </div>
          </div>
        </form>
      </div>
    </div>

  </div>
</template>

<style scoped>
@import '@/assets/css/login.css';
</style>