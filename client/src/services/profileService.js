import axios from 'axios'
import api from '@/common/api.js'

const path = '/api/profiles'

const profileService = {
  async get() {
    return await axios.get(`${api.url}${path}`)
  },
  async update(model) {
    return await axios.put(`${api.url}${path}`, model)
  }
}

export default profileService
