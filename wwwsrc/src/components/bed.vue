<template>
  <div class="beds row">
    <div class="col-12">
      <img class="img-fluid" :src="bedData.img" alt />
    </div>
    <div v-show="info" class="popup">
      <p>{{bedData.name}}</p>
    </div>
  </div>
</template>


<script>
export default {
  props: ["bedData"],
  methods: {},
  data() {
    return {
      info: false
    };
  },
  computed: {}
};
</script>


<style scoped>
</style>