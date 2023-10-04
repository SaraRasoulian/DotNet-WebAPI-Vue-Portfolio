<template>
  <div class="education">
    <AdminLayout>
      <div class="content-container noselect">
        <div class="title-wrapper parent-page-title">
          <div class="list-title">
            <h4>Educations</h4>
            <div class="list-total">
              <span>{{ list.length }}</span>
              <span>total</span>
            </div>
          </div>
          <div class="right-button-wrapper">
            <router-link :to="{ name: 'add-education' }" class="btn btn-save btn-add">
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
              <div class="col-lg-4 col-md-4 col-sm-12"><span>Degree</span></div>
              <div class="col-lg-4 col-md-4 col-sm-12"><span>Field of study</span></div>
              <div class="col-lg-4 col-md-4 col-sm-12"><span>School</span></div>
            </div>
            <div class="control-header">
              <span>Controls</span>
            </div>
          </div>
          <!--list items-->
          <div v-for="item in list" :key="item.id">
            <div class="list-item">
              <div class="row">
                <div class="col-lg-4 col-md-4 col-sm-12"><span>{{ item.degree }}</span></div>
                <div class="col-lg-4 col-md-4 col-sm-12"><span>{{ item.fieldOfStudy }}</span></div>
                <div class="col-lg-4 col-md-4 col-sm-12"><span>{{ item.school }}</span></div>
              </div>
              <div class="buttons-wrapper">
                <router-link :to="{ name: 'view-education', params: { id: item.id } }" class="list-button"
                  data-toggle="tooltip" data-placement="top" title="View">
                  <img src="@/assets/admin/images/view.png" class="list-button-icon" alt="View">
                </router-link>

                <router-link :to="{ name: 'edit-education', params: { id: item.id } }" class="list-button"
                  data-toggle="tooltip" data-placement="top" title="Edit">
                  <img src="@/assets/admin/images/edit.svg" class="list-button-icon" alt="Edit">
                </router-link>

                <router-link :to="{ name: 'delete-education', params: { id: item.id } }" class="list-button"
                  data-toggle="tooltip" data-placement="top" title="Delete">
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
import educationsService from '@/services/educationsService'
import { onMounted, ref } from 'vue'

const list = ref([])

async function getList() {
  await educationsService.getAll().then(response => {
    list.value = response.data
  })
}

onMounted(getList)
</script>