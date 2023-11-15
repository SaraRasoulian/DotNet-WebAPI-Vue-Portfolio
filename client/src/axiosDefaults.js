import axios from 'axios'

axios.defaults.baseURL = 'https://localhost:7026'
axios.defaults.headers.common['Authorization'] = 'Bearer ' + localStorage.getItem('token')

export default axios