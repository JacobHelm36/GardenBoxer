<template>
  <div class="col-12 col-md-6">
    <garden :gardenData="gardenData" />
    <h1>Your Gardens</h1>
    <h4>{{gardenData.name}}</h4>
    <h4>{{gardenData.description}}</h4>
  </div>
</template>

<script>
import Garden from "../components/garden"
export default {
  props: ["gardenData"],
  mounted() {},
  computed: {},
  components:{
    Garden
  }
};
</script>

<style></style>
