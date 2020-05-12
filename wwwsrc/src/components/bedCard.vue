<template>
  <div class="row">
    <div class="col-12">
      <img :src="bedData.img" class="img-fluid" alt />
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
  left:0px;
}
</style>