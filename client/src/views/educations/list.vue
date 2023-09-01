<template>
  <div class="about">
    <h1>This is list of educations page </h1>

    <RouterLink class="btn btn-primary" to="/educations/add">Add</RouterLink>

    <div class="list-title">
      <h4>Educations</h4>
      <div class="list-total">
        <span>{{ listTotal }}</span>
        <span>total</span>
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
      </div>
      <hr class="line" />
    </div>
  </div>
</template>

<script>
import axios from "axios";

export default {

  data() {
    return {
      list: [],
      listTotal: 0,
    }
  },
  methods: {
    getList() {
      axios.get('https://localhost:7026/api/educations').then(response => {
        console.log(response)
        console.log('data: ', response.data)
        this.list = response.data
        this.listTotal = this.list.length
      })
    },
  },
  mounted() {
    this.getList();
  }
}
</script>

<style>
@media (min-width: 1024px) {
  .about {
    min-height: 100vh;
    display: flex;
    align-items: center;
  }
}
</style>
