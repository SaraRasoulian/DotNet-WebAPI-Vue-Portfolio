import axios from '@/axiosDefaults'

const path = '/api/identity'

const identityService = {
  async login(userLogin) {
    return await axios.post(`${path}/login`, userLogin)
  },
  async validateToken() {
    return await axios.get(`${path}/validate-token`)
  },
  async changePassword(model) {
    return await axios.put(`${path}/change-password`, model)
  }
}

export default identityService
