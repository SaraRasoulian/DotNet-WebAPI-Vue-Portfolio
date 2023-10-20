<template>
    <div class="education">
      <AdminLayout>
        <div class="content-container">
          <div class="title-wrapper">
            <router-link :to="{ name: 'social-list' }" class="back-to-list-wrapper" data-toggle="tooltip"
              data-placement="top" title="Return to list">
              <div class="back-to-list">
                <img src="@/assets/admin/images/back.png" class="back-icon" alt="Return" />
              </div>
            </router-link>
            <h4>Add Social Link</h4>
          </div>
          <hr class="line" />
  
          <div class="content">
            <div class="form-container">
              <div class="row g-3">
                <div class="col-lg-8 col-md-12 col-sm-12">
                  <label for="name" class="form-label">Name</label>
                  <div class="input-group has-validation">
                    <input type="text" v-model="formData.name" class="form-control" id="name" placeholder="Name"
                      required="">
                    <div class="invalid-feedback">
                      Name is required.
                    </div>
                  </div>
                </div>
              </div>
  
              <div class="row g-3">
                <div class="col-lg-8 col-md-12 col-sm-12">
                  <label for="url" class="form-label">Url</label>
                  <input type="text" v-model="formData.url" class="form-control" id="url"
                    placeholder="Url">
                  <div class="invalid-feedback">
                    Field is required.
                  </div>
                </div>
              </div>
  
              <div class="row">
                <div class="col-lg-6 col-md-8 col-sm-12 col-xs-12">
                  <div class="button-container">
                    <button class="btn btn-save" v-on:click.prevent="create()">Add</button>
                    <router-link :to="{ name: 'social-list' }" class="btn btn-cancel">Cancel</router-link>
                  </div>
                </div>
              </div>
            </div>
          </div>
  
        </div>
      </AdminLayout>
    </div>
  </template>
  
  <script setup>
  import AdminLayout from '@/layouts/admin/Layout.vue'
  import socialLinksService from '@/services/socialLinksService'
  import { useToast } from 'vue-toastification'
  import { reactive } from 'vue'
  import { useRouter } from 'vue-router'
  
  const router = useRouter()
  const formData = reactive({
    name: '',
    url: '',
  })
  
  async function create() {
    const toast = useToast()
    try {
      await socialLinksService.create(formData).then(response => {
        router.push({ name: 'social-list' })
        if (response.status == 200)
          toast.success("Social link added successfully")
      })
    }
    catch (errorMsg) {
      toast.error("Something went wrong")
    }
  }
  </script>