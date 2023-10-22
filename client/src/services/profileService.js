import axios from '@/axiosDefaults'

const path = '/api/profiles'

const profileService = {
  async get() {
    return await axios.get(`${path}`)
  },
  async update(model) {
    return await axios.put(`${path}`, model)
  }
}

export default profileService