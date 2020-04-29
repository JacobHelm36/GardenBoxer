<template>
  <div class="dashboard container">
    <garden :gardenData="garden" />
    <h2>{{garden.name}}</h2>
    <h2>{{garden.description}}</h2>
    <h1>Your Gardens</h1>
    <bed v-for="bedObj in beds" :key="bedObj.id" />
    <p>{{bedObj.name}}</p>
  </div>
</template>

<script>
import Bed from "../components/bed"
import Garden from "../components/garden"
export default {
  mounted() {
    this.$store.dispatch("setActiveGarden", this.$route.params.id);
    this.$store.dispatch("getBedsByGardenId", this.$route.params.id);
  },
  computed: {
    beds() {
      return this.$store.state.beds;
    },
    garden() {
      return this.$store.state.activeGarden;
    }
  },
  components: {
    Bed
  },
  props:[]
};
</script>

<style></style>
