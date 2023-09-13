import axios from 'axios'
import api from '@/common/api.js'

const path = '/api/educations'

const educationsService = {
  async getAll() {
    return await axios.get(`${api.url}${path}`)
  },
  async get(id) {
    return await axios.get(`${api.url}${path}/${id}`)
  },
  async update(id, model) {
    return await axios.put(`${api.url}${path}/${id}`, model)
  },
  async create(model) {
    return await axios.post(`${api.url}${path}`, model)
  },
  async delete(id) {
    return await axios.delete(`${api.url}${path}/${id}`)
  }
}

export default educationsService
