<template>
  <div class="col-6 col-md-3 card-back rounded bg-light">
    <garden :gardenData="gardenData" />
    <h4>{{gardenData.name}}</h4>
    <h4>{{gardenData.description}}</h4>
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

<style>
.card-back {
  border: 1px solid black;
}
</style>
