import axios from '@/axiosDefaults'

const path = '/api/identity'

const identityService = {
  async login(userLogin) {
    return await axios.post(`${path}/login`, userLogin)
  },
  async validateToken() {
    return await axios.get(`${path}/validate-token`)
  }
}

export default identityService
