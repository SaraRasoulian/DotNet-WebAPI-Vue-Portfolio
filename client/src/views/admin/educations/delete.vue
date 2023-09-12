<template>
    <div class="education">
        <AdminLayout>
            <div class="content-container">
                <div class="view-wrapper">
                    <div class="title-wrapper">
                        <router-link :to="{ name: 'education-list' }" class="back-to-list-wrapper" data-toggle="tooltip"
                            data-placement="top" title="Return to list">
                            <div class="back-to-list">
                                <img src="@/assets/admin/images/back.png" class="back-icon" alt="" />
                            </div>
                        </router-link>
                        <h4>Delete Education</h4>
                    </div>
                    <hr class="line" />

                    <div class="content">
                        <div class="form-container">
                            <div>
                                <div class="row g-3">
                                    <div class="col-lg-8 col-md-12 col-sm-12">
                                        <div class="view-item-wrapper">
                                            <span>Degree</span>
                                            <p>{{ model.degree }}</p>
                                        </div>
                                    </div>
                                </div>

                                <div class="row g-3">
                                    <div class="col-lg-8 col-md-12 col-sm-12">
                                        <div class="view-item-wrapper">
                                            <span>Field of study</span>
                                            <p>{{ model.fieldOfStudy }}</p>
                                        </div>
                                    </div>
                                </div>

                                <div class="row g-3">
                                    <div class="col-lg-8 col-md-12 col-sm-12">
                                        <div class="view-item-wrapper">
                                            <span>School</span>
                                            <p>{{ model.school }}</p>
                                        </div>
                                    </div>
                                </div>

                                <div class="row g-3">
                                    <div class="col-lg-4 col-md-6 col-sm-12">
                                        <div class="view-item-wrapper">
                                            <span>Start Year</span>
                                            <p>{{ model.startYear }}</p>
                                        </div>
                                    </div>
                                    <div class="col-lg-4 col-md-6 col-sm-12">
                                        <div class="view-item-wrapper">
                                            <span>End Year</span>
                                            <p>{{ model.endYear }}</p>
                                        </div>
                                    </div>
                                </div>
                                <div class="row g-3" v-if="model.description !== ''">
                                    <div class="col-lg-8 col-md-12 col-sm-12">
                                        <div class="view-item-wrapper">
                                            <span>Description</span>
                                            <p>{{ model.description }}</p>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-6 col-md-8 col-sm-12 col-xs-12">
                                        <div class="button-container">
                                            <button class="btn btn-delete" v-on:click.prevent="remove()">Delete</button>
                                            <router-link :to="{ name: 'education-list' }"
                                                class="btn btn-cancel">Cancel</router-link>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </AdminLayout>
    </div>
</template>

<script>
import AdminLayout from '@/layouts/admin/Layout.vue'
import axios from "axios"
import api from '@/common/api.js'
import { useToast } from "vue-toastification"

export default {
    components: {
        AdminLayout,
    },
    data() {
        return {
            model: [],
            id: this.$route.params.id,
        };
    },
    methods: {
        loadData() {
            axios.get(api.url + '/api/educations/' + this.id).then(response => {
                this.model = response.data
            });
        },
        remove() {
            const toast = useToast();
            axios.delete(api.url + '/api/educations/' + this.id).then(response => {
                console.log('response status: ', response.status)

                this.$router.push("/admin/educations")

                if (response.status == 200) {
                    toast.success("Education deleted successfully")
                }
            })
                .catch(error => {
                    console.log(error)
                    toast.error("Something went wrong")
                })
        }
    },
    mounted() {
        this.loadData()

    }
}
</script>