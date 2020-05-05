<template>
  <div class="dashboard" id="garden-view">
    <side-bar />
    <div class="container">
      <div class="row">
        <div class="col-12 p-0">
          <garden :showBeds="true" :percent="100" :clickable="true" :gardenData="gardenInfo" />
          <h2>{{gardenInfo.name}}</h2>
          <h2>{{gardenInfo.description}}</h2>
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
  props: ["gardenDim"],
  async mounted() {
    if (await this.$auth.isAuthenticated) {
      this.$store.dispatch("setActiveGarden", this.$route.params.id);
      this.$store.dispatch("getBedsByGardenId", this.$route.params.id);
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
