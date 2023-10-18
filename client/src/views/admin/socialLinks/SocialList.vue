<template>
  <div class="social">
    <AdminLayout>
      <div class="content-container noselect">
        <div class="title-wrapper parent-page-title">
          <div class="list-title">
            <h4>Social Links</h4>
            <div class="list-total">
              <span>{{ list.length }}</span>
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
              <div class="col-lg-3 col-md-3 col-sm-12"><span>Icon</span></div>
              <div class="col-lg-3 col-md-3 col-sm-12"><span>Name</span></div>
              <div class="col-lg-6 col-md-6 col-sm-12"><span>Link</span></div>
            </div>
            <div class="control-header">
              <span>Controls</span>
            </div>
          </div>
          <!--list items-->
          <div v-for="item in list" :key="item.id">
            <div class="list-item">
              <div class="row">
                <div class="col-lg-3 col-md-3 col-sm-12">
                  <img :src="item.icon" class="social-img" :alt="item.name">
                </div>
                <div class="col-lg-3 col-md-3 col-sm-12"><span>{{ item.name }}</span></div>
                <div class="col-lg-6 col-md-6 col-sm-12"><span>{{ item.url }}</span></div>
              </div>
              <div class="buttons-wrapper">
                <router-link :to="{ name: 'view-social', params: { id: item.id } }" class="list-button" data-toggle="tooltip"
                  data-placement="top" title="View">
                  <img src="@/assets/admin/images/view.png" class="list-button-icon" alt="View">
                </router-link>

                <router-link :to="{ name: 'edit-social', params: { id: item.id } }" class="list-button" data-toggle="tooltip"
                  data-placement="top" title="Edit">
                  <img src="@/assets/admin/images/edit.svg" class="list-button-icon" alt="Edit">
                </router-link>

                <router-link :to="{ name: 'delete-social', params: { id: item.id } }" class="list-button" data-toggle="tooltip"
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

<script setup>
import AdminLayout from '@/layouts/admin/Layout.vue'
import socialLinksService from '@/services/socialLinksService'
import { onMounted, ref } from 'vue'

const list = ref([])

async function getList() {
  await socialLinksService.getAll().then(response => {
    list.value = response.data
  })
}

onMounted(getList)
</script>