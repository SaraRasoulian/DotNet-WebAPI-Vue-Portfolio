<template>
  <AdminLayout>
    <div class="content-container">
      <div class="title-wrapper">
        <RouterLink to="/admin/educations" class="back-to-list-wrapper" data-toggle="tooltip" data-placement="top"
          title="Return to list">
          <div class="back-to-list">
            <img src="@/assets/admin/images/back.png" class="back-icon" alt="" />
          </div>
        </RouterLink>
        <h4>Add Education</h4>
      </div>
      <hr class="line" />

      <div class="content">
        <div class="form-container">
          <form class="needs-validation" novalidate="">
            <div class="row g-3">
              <div class="col-lg-8 col-md-12 col-sm-12">
                <label for="degree" class="form-label">Degree</label>
                <div class="input-group has-validation">
                  <input type="text" v-model="degree" class="form-control" id="degree" placeholder="Degree" required="">
                  <div class="invalid-feedback">
                    Degree is required.
                  </div>
                </div>
              </div>
            </div>

            <div class="row g-3">
              <div class="col-lg-8 col-md-12 col-sm-12">
                <label for="fieldOfStudy" class="form-label">Field of study</label>
                <input type="text" v-model="fieldOfStudy" class="form-control" id="fieldOfStudy"
                  placeholder="Field of study">
                <div class="invalid-feedback">
                  Field is required.
                </div>
              </div>
            </div>

            <div class="row g-3">
              <div class="col-lg-8 col-md-12 col-sm-12">
                <label for="school" class="form-label">School</label>
                <input type="text" v-model="school" class="form-control" id="school" placeholder="School" required="">
                <div class="invalid-feedback">
                  School is required.
                </div>
              </div>
            </div>

            <div class="row g-3">
              <div class="col-lg-4 col-md-6 col-sm-12">
                <label for="startYear" class="form-label">Start Year</label>
                <input type="text" v-model="startYear" class="form-control" id="startYear" placeholder="Start Year"
                  required="">
                <div class="invalid-feedback">
                  start year is required.
                </div>
              </div>
              <div class="col-lg-4 col-md-6 col-sm-12">
                <label for="endYear" class="form-label">End Year</label>
                <input type="text" v-model="endYear" class="form-control" id="endYear" placeholder="End Year" required="">
                <div class="invalid-feedback">
                  end year is required.
                </div>
              </div>
            </div>
            <div class="row g-3">
              <div class="col-lg-8 col-md-12 col-sm-12">
                <label for="description" class="form-label">Description
                  <span class="secondary-text">(Optional)</span>
                </label>
                <textarea type="text" v-model="description" class="form-control" id="description"
                  placeholder="description"></textarea>
              </div>
            </div>

            <div class="row">
              <div class="col-lg-6 col-md-8 col-sm-12 col-xs-12">
                <div class="button-container">
                  <button class="btn btn-save" v-on:click.prevent="create()">Add</button>
                  <button class="btn btn-cancel" type="submit">Cancel</button>
                </div>
              </div>
            </div>
          </form>
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
    AdminLayout
  },
  data() {
    return {
      degree: '',
      fieldOfStudy: '',
      school: '',
      startYear: '',
      endYear: '',
      description: '',
    };
  },
  methods: {
    create() {
      const model = {
        Degree: this.degree,
        FieldOfStudy: this.fieldOfStudy,
        School: this.school,
        StartYear: this.startYear,
        EndYear: this.endYear,
        Description: this.description,
      };
      console.log('dd ', model);
      alert('test');

      axios.post('https://localhost:7026/api/educations', model, {
        headers: {
          'Accept': 'application/json',
          'Content-Type': 'application/json;charset=utf-8'
        }
      })
        .then(response => {
          console.log(response);
          alert('S');
        })
        .catch(error => {
          this.errorMessage = error.message;
          console.error("There was an error!", error);
          alert('Error');

        });

      this.clearForm();
    },
    clearForm() {
      this.degree = "";
      this.fieldOfStudy = "";
      this.school = "";
      this.startYear = "";
      this.endYear = "";
      this.description = "";
    },
  }
}
</script>