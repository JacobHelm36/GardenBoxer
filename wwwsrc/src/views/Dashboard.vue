<template>
  <div class="dashboard container">
    <div class="col-12 text-center">
      <h1>Your Gardens</h1>
    </div>
    <div class="row">
      <garden v-for="garden in gardens" :key="garden.id" :gardenData="garden" />
    </div>
  </div>
</template>

<script>
import Garden from "../components/gardenCard.vue";
export default {
  async mounted() {
    if (await this.$auth.isAuthenticated) {
      this.$store.dispatch("getGardens");
    }
  },
  computed: {
    gardens() {
      return this.$store.state.gardens;
    }
  },
  components: {
    Garden
  }
};
</script>

<style></style>
