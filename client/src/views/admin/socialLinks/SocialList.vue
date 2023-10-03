<template>
  <div class="social">
    <AdminLayout>
      <div class="content-container noselect">
        <div class="title-wrapper parent-page-title">
          <div class="list-title">
            <h4>Social Links</h4>
            <div class="list-total">
              <span>3</span>
              <span>total</span>
            </div>
          </div>
          <div class="right-button-wrapper">
            <router-link :to="{ name: 'add-social' }" class="btn btn-save btn-add">
              <img src="@/assets/admin/images/add.svg" class="add-icon" alt="Add">
              <span class="add-text">Add</span>
            </router-link>
          </div>
        </div>

        <hr class="line" />

        <div class="content">
          <!--list header-->
          <div class="list-header">
            <div class="row">
              <div class="col-lg-4 col-md-4 col-sm-12"><span>Icon</span></div>
              <div class="col-lg-4 col-md-4 col-sm-12"><span>Name</span></div>
              <div class="col-lg-4 col-md-4 col-sm-12"><span>Link</span></div>
            </div>
            <div class="control-header">
              <span>Controls</span>
            </div>
          </div>
          <!--list items-->
          <div>
            <div class="list-item">
              <div class="row">
                <div class="col-lg-3 col-md-3 col-sm-12">
                  <img src="@/assets/home/images/social/linkedin.svg" class="social-img" alt="LinkedIn">
                </div>
                <div class="col-lg-3 col-md-3 col-sm-12"><span>LinkedIn</span></div>
                <div class="col-lg-6 col-md-6 col-sm-12"><span>https://www.linkedin.com/in/sara-rasoulian</span></div>
              </div>
              <div class="buttons-wrapper">
                <router-link :to="{ name: 'view-social', params: { id: 1 } }" class="list-button" data-toggle="tooltip"
                  data-placement="top" title="View">
                  <img src="@/assets/admin/images/view.png" class="list-button-icon" alt="View">
                </router-link>

                <router-link :to="{ name: 'edit-social', params: { id: 1 } }" class="list-button" data-toggle="tooltip"
                  data-placement="top" title="Edit">
                  <img src="@/assets/admin/images/edit.svg" class="list-button-icon" alt="Edit">
                </router-link>

                <router-link :to="{ name: 'delete-social', params: { id: 1 } }" class="list-button" data-toggle="tooltip"
                  data-placement="top" title="Delete">
                  <img src="@/assets/admin/images/delete.svg" class="list-button-icon" alt="Delete">
                </router-link>
              </div>
            </div>
            <hr class="line" />
          </div>

          <div>
            <div class="list-item">
              <div class="row">
                <div class="col-lg-3 col-md-3 col-sm-12">
                  <img src="@/assets/home/images/social/github.svg" class="social-img" alt="GitHub">
                </div>
                <div class="col-lg-3 col-md-3 col-sm-12"><span>GitHub</span></div>
                <div class="col-lg-6 col-md-6 col-sm-12"><span>https://github.com/SaraRasoulian</span></div>
              </div>
              <div class="buttons-wrapper">
                <router-link :to="{ name: 'view-social', params: { id: 1 } }" class="list-button" data-toggle="tooltip"
                  data-placement="top" title="View">
                  <img src="@/assets/admin/images/view.png" class="list-button-icon" alt="View">
                </router-link>

                <router-link :to="{ name: 'edit-social', params: { id: 1 } }" class="list-button" data-toggle="tooltip"
                  data-placement="top" title="Edit">
                  <img src="@/assets/admin/images/edit.svg" class="list-button-icon" alt="Edit">
                </router-link>

                <router-link :to="{ name: 'delete-social', params: { id: 1 } }" class="list-button" data-toggle="tooltip"
                  data-placement="top" title="Delete">
                  <img src="@/assets/admin/images/delete.svg" class="list-button-icon" alt="Delete">
                </router-link>
              </div>
            </div>
            <hr class="line" />
          </div>

          <div>
            <div class="list-item">
              <div class="row">
                <div class="col-lg-3 col-md-3 col-sm-12">
                  <img src="@/assets/home/images/social/email.svg" class="social-img" alt="Email">
                </div>
                <div class="col-lg-3 col-md-3 col-sm-12"><span>Email</span></div>
                <div class="col-lg-6 col-md-6 col-sm-12"><span>sara.rasoulian.dev@gmail.com</span></div>
              </div>
              <div class="buttons-wrapper">
                <router-link :to="{ name: 'view-social', params: { id: 1 } }" class="list-button" data-toggle="tooltip"
                  data-placement="top" title="View">
                  <img src="@/assets/admin/images/view.png" class="list-button-icon" alt="View">
                </router-link>

                <router-link :to="{ name: 'edit-social', params: { id: 1 } }" class="list-button" data-toggle="tooltip"
                  data-placement="top" title="Edit">
                  <img src="@/assets/admin/images/edit.svg" class="list-button-icon" alt="Edit">
                </router-link>

                <router-link :to="{ name: 'delete-social', params: { id: 1 } }" class="list-button" data-toggle="tooltip"
                  data-placement="top" title="Delete">
                  <img src="@/assets/admin/images/delete.svg" class="list-button-icon" alt="Delete">
                </router-link>
              </div>
            </div>
            <hr class="line" />
          </div>
        </div>

      </div>
    </AdminLayout>
  </div>
</template>

<script>
import AdminLayout from '@/layouts/admin/Layout.vue'

export default {
  components: {
    AdminLayout,
  }
}
</script>