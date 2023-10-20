import axios from 'axios'
import api from '@/common/api.js'

const path = '/api/identity'

const identityService = {
  async login(userLogin) {
    return await axios.post(`${api.url}${path}/login`, userLogin)
  }
}

export default identityService
