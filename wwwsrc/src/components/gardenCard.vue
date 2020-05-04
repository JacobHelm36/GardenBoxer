<template>
  <div class="col-6 col-md-3">
    <div
      class="card-back rounded bg-primary d-flex justify-content-center flex-column align-items-center"
    >
      <garden class="mt-1" :percent="95" :gardenData="gardenData" />
      <router-link class="text-dark" :to="'/garden/' + gardenData.id">view garden</router-link>
      <h4>{{gardenData.name}}</h4>
      <h4>{{gardenData.description}}</h4>
    </div>
  </div>
</template>

<script>
import Garden from "../components/garden";
export default {
  props: ["gardenData"],
  mounted() {},
  computed: {},
  components: {
    Garden
  }
};
</script>

<style></style>
