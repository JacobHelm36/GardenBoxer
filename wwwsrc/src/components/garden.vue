<template>
  <div class="col-12 col-md-6">
    <h1>Your Gardens</h1>
    <h4>{{gardenData.name}}</h4>
    <h4>{{gardenData.description}}</h4>
  </div>
</template>

<script>
export default {
  props: ["gardenData"],
  mounted() {},
  computed: {}
};
</script>

<style></style>
