import Axios from 'axios';
const RESOURCE_NAME = '/Tshirt';
export default {
  getAll() {
    return Axios.get(RESOURCE_NAME + "/GetTshirts");
  },
  get(id) {
    return Axios.get(`${RESOURCE_NAME+"/GetTshirtById"}/${id}`);
  },
  addImage(data) {
    const headers = { 'Content-Type': 'multipart/form-data' };
    return Axios.post(RESOURCE_NAME+"/AddImage", data, { headers });
  },
  delete(id) {
    return Axios.delete(`${RESOURCE_NAME+"/DeleteImageById"}/${id}`);
  }
};