import Vue from "vue";
import Vuex from "vuex";
import Axios from "axios";
import router from "../router";

Vue.use(Vuex);

let baseUrl = location.host.includes("localhost")
  ? "http://localhost:5000/"
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
    activeGardenDimensions: {},
    activeHover: {},
    templateBeds: [],
    groups: [],
    offset: {}
  },
  mutations: {
    // Gardens
    setGardens(state, gardens) {
      state.gardens = gardens;
    },
    setActiveGarden(state, garden) {
      state.activeGarden = garden;
    },
    setNewGardens(state, newGarden) {
      state.gardens.push(newGarden);
      state.activeGarden = newGarden;
    },
    removeGarden(state, gardenId) {
      state.gardens = state.gardens.filter(g => g.id != gardenId)
    },
    setGardenDimensions(state, gardenDim) {
      state.activeGardenDimensions = gardenDim;
    },
    // Beds
    setBeds(state, beds) {
      state.beds = beds;
    },
    addBed(state, newBed) {
      state.beds.push(newBed)
    },
    setEditBed(state, editedBed) {
      let index = state.beds.map(b => b.id).indexOf(editedBed.id);
      Vue.set(state.beds, index, editedBed);
    },
    deleteBed(state, bedId) {
      state.beds = state.beds.filter(b => b.id != bedId)
    },
    addActiveBed(state, bedId) {
      Vue.set(state.activeHover, bedId, true);
    },
    removeActiveBed(state, bedId) {
      Vue.set(state.activeHover, bedId, false);
    },
    addSavedBed(state, bed) {
      state.templateBeds.push(bed);
    },
    removeSavedBed(state, bedId) {
      state.templateBeds.filter(b => b.id != bedId);
    },
    setSavedBeds(state, beds) {
      state.templateBeds = beds;
    },
    addGroup(state, group) {
      state.groups.push(group);
    },
    removeGroup(state, groupId) {
      state.groups.filter(g => g.id != groupId);
    },
    setGroups(state, groups) {
      state.groups = groups;
    },
    setOffset(state, offset) {
      state.offset = offset;
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
    async editGarden({ commit }, editedGarden) {
      let res = await api.put("gardens", editedGarden);
      commit("setActiveGarden", res.data);
    },
    async createGarden({ commit }, newGarden) {
      let res = await api.post("gardens", newGarden);
      commit("setNewGardens", res.data);
    },
    async deleteGarden({ commit }, gardenData) {
      await api.delete(`gardens/${gardenData}`);
      commit("removeGarden", gardenData);
    },
    updateGardenDimensions({ commit }, gardenDim) {
      commit("setGardenDimensions", gardenDim);
    },

    // Beds
    async getBedsByGardenId({ commit }, gardenId) {
      let res = await api.get(`gardens/${gardenId}/beds`);
      commit("setBeds", res.data);
      console.log("yo beds", res.data)
    },
    async createBed({ commit }, newBed) {
      let res = await api.post("beds", newBed)
      commit("addBed", res.data)
    },
    async editBed({ commit }, editedBed) {
      console.log("this is the original edited bed", editedBed);
      let res = await api.put(`beds/${editedBed.id}`, editedBed);
      commit("setEditBed", res.data);
      console.log("new edited bed", res.data);
    },
    async deleteBed({ commit }, bedId) {
      let res = await api.delete(`beds/${bedId}`);
      commit("deleteBed", bedId)
    },
    addHover({ commit }, bedId) {
      commit("addActiveBed", bedId);
    },
    removeHover({ commit }, bedId) {
      commit("removeActiveBed", bedId);
    },
    async saveBed({ commit }, bed) {
      let res = await api.post(`bedtemplates`, bed);
      commit("addSavedBed", res.data);
    },
    async removeSavedBed({ commit }, bedId) {
      await api.delete(`bedtemplates/${bedId}`);
      commit("removeSavedBed", bedId);
    },
    async getBedTemplates({ commit }) {
      let res = await api.get(`bedtemplates`);
      commit("setSavedBeds", res.data);
    },
    async createGroup({ commit }, groupName) {
      let res = await api.post(`groups`, { name: groupName });
      commit("addGroup", res.data);
    },
    async deleteGroup({ commit }, groupId) {
      await api.delete(`groups/${groupId}`);
      commit("removeGroup", groupId);
    },
    async getGroups({ commit }) {
      let res = await api.get("groups");
      commit("setGroups", res.data);
    },
    setOffset({ commit }, offset) {
      commit("setOffset", offset)
    }
  }
});