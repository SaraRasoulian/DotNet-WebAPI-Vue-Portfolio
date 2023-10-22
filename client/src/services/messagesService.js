import axios from '@/axiosConfig'

const path = '/api/messages'

const messagesService = {
  async getAll() {
    return await axios.get(`${path}`)
  },
  async get(id) {
    return await axios.get(`${path}/${id}`)
  },
  async create(model) {
    return await axios.post(`${path}`, model)
  },
  async delete(id) {
    return await axios.delete(`${path}/${id}`)
  },
  async GetNumberOfUnread() {
    return await axios.get(`${path}/unread`)
  },
  async markAsRead(id) {
    return await axios.put(`${path}/mark-as-read/${id}`)
  },
}

export default messagesService