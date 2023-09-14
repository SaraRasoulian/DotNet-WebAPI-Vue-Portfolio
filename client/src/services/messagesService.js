import axios from 'axios'
import api from '@/common/api.js'

const path = '/api/messages'

const messagesService = {
  async getAll() {
    return await axios.get(`${api.url}${path}`)
  },
  async get(id) {
    return await axios.get(`${api.url}${path}/${id}`)
  },
  async create(model) {
    return await axios.post(`${api.url}${path}`, model)
  },
  async delete(id) {
    return await axios.delete(`${api.url}${path}/${id}`)
  }
}

export default messagesService
