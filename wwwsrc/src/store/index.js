import Vue from "vue";
import Vuex from "vuex";
import Axios from "axios";
import router from "../router";

Vue.use(Vuex);

let baseUrl = location.host.includes("localhost")
  ? "https://localhost:5001/"
  : "/";

let api = Axios.create({
  baseURL: baseUrl + "api/",
  timeout: 3000,
  withCredentials: true
});

export default new Vuex.Store({
  state: {
    gardens: [],
    beds: [],
    activeGarden: {},
  },
  mutations: {
    setGardens(state, gardens) {
      state.gardens = gardens;
    },
    setNewGardens(state, newGarden) {
      state.gardens.push(newGarden)
    },
    setActiveGarden(state, garden) {
      state.activeGarden = garden;
    },
    setBeds(state, beds) {
      state.beds = beds;
    },
    setEditBed(state, editedBed) {
      let index = state.beds.indexOf({ id: editedBed.id });
      Vue.set(state.beds, index, editedBed);
    }
  },
  actions: {
    setBearer({ }, bearer) {
      api.defaults.headers.authorization = bearer;
    },
    resetBearer() {
      api.defaults.headers.authorization = "";
    },

    // Gardens
    async getGardens({ commit }) {
      let res = await api.get("gardens")
      commit("setGardens", res.data)
    },
    async setActiveGarden({ commit }, gardenId) {
      let res = await api.get(`gardens/${gardenId}`);
      commit("setActiveGarden", res.data);
    },
    async createGarden({ commit }, newGarden) {
      let res = await api.post("gardens", newGarden)
      commit("setNewGardens", res.data)
    },
    async deleteGarden({ commit }, gardenData) {
      await api.delete(`gardens/${gardenData.id}`)
      commit("removeGarden", gardenData.id)
    },

    // Beds
    async getBedsByGardenId({ commit }, gardenId) {
      let res = await api.get(`gardens/${gardenId}/beds`);
      commit("setBeds", res.data);
    },
    async editBeds({ commit }, editedBed) {
      let res = await api.put(`gardens/${editedBed.Id}`, editedBed);
      commit("setEditBed", res.data)
    }
  }
});
