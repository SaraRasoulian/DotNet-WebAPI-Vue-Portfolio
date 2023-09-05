<template>
  <AdminLayout>
    <div class="content-container noselect">
      <div class="title-wrapper parent-page-title">
        <div class="list-title">
          <h4>Educations</h4>
          <div class="list-total">
            <span>{{ listTotal }}</span>
            <span>total</span>
          </div>
        </div>
        <div class="right-button-wrapper">
          <RouterLink to="/admin/educations/add" class="btn btn-save btn-add">
            <img src="@/assets/admin/images/add.svg" class="add-icon" alt="">
            <span class="add-text">Add</span>
          </RouterLink>
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
              <a href="education-view.html" class="list-button" data-toggle="tooltip" data-placement="top" title="View">
                <img src="@/assets/admin/images/view.png" class="list-button-icon" alt="">
              </a>
              <a href="education-edit.html" class="list-button" data-toggle="tooltip" data-placement="top" title="Edit">
                <img src="@/assets/admin/images/edit.svg" class="list-button-icon" alt="">
              </a>
              <a href="education-delete.html" class="list-button" data-toggle="tooltip" data-placement="top"
                title="Delete">
                <img src="@/assets/admin/images/delete.svg" class="list-button-icon" alt="">
              </a>
            </div>
          </div>
          <hr class="line" />
        </div>
      </div>

    </div>
  </AdminLayout>
</template>

<script>
import AdminLayout from '@/layouts/admin/Layout.vue'
import axios from "axios"

export default {
  components: {
    AdminLayout,
  },
  data() {
    return {
      list: [],
      listTotal: 0,
    };
  },
  methods: {
    getList() {
      axios.get('https://localhost:7026/api/educations').then(response => {
        console.log(response);
        console.log('data: ', response.data);
        this.list = response.data;
        this.listTotal = this.list.length;
      });
    },
  },
  mounted() {
    this.getList();
  }
}
</script>