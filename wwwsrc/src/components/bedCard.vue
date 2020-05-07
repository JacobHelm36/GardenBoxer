<template>
  <div class="row">
    <div class="col-12">
      <img :src="bedData.img" alt />
      <h2>{{bedData.name}}</h2>
      <p>{{bedData.description}}</p>
    </div>
  </div>
</template>
<script>
export default {
  props: ["bedData"]
};
</script>
<style scoped>
img {
  max-width: 100%;
}
</style>