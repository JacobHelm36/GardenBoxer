<template>
  <div class="dashboard container">
    <h2>{{garden.name}}</h2>
    <h2>{{garden.description}}</h2>
    <h1>Your Gardens</h1>
  </div>
</template>

<script>
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
    Garden
  }
};
</script>

<style></style>
