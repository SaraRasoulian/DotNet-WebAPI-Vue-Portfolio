import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import axios from 'axios'
import VueAxios from 'vue-axios'
import Toast from 'vue-toastification'
import 'vue-toastification/dist/index.css'
import axiosConfig from './axios'

const app = createApp(App)
app.use(router)
app.use(VueAxios, axios)
app.use(Toast)
app.config.globalProperties.$axios = axiosConfig
app.mount('#app')