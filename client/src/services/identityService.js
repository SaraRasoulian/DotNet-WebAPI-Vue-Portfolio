import axios from '@/axiosConfig'

const path = '/api/identity'

const identityService = {
  async login(userLogin) {
    return await axios.post(`${path}/login`, userLogin)
  }
}

export default identityService
