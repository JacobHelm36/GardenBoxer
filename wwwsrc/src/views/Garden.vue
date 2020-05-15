<template>
  <div class="dashboard" id="garden-view">
    <side-bar />
    <div class="container">
      <div class="row">
        <div class="col-12 mb-5"></div>
        <div class="col-12 p-0">
          <garden :showBeds="true" :percent="100" :clickable="true" :gardenData="gardenInfo" />
          <h2>{{gardenInfo.name}}</h2>
          <h2>{{gardenInfo.description}}</h2>
          <select name="gardenOptions" id="gardenOptions">
            <option value></option>
            <option value></option>
          </select>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import AddBed from "../components/addBed";
import Garden from "../components/garden";
import SideBar from "../components/sideBar";
export default {
  async mounted() {
    if (await this.$auth.isAuthenticated) {
      await this.$store.dispatch("setActiveGarden", this.$route.params.id);
      await this.$store.dispatch("getBedsByGardenId", this.$route.params.id);
      await this.$store.dispatch("getBedTemplates");
      await this.$store.dispatch("getGroups");
    }
  },
  computed: {
    beds() {
      return this.$store.state.beds;
    },
    gardenInfo() {
      return this.$store.state.activeGarden;
    }
  },
  components: {
    AddBed,
    Garden,
    SideBar
  },
  props: []
};
</script>

<style></style>
