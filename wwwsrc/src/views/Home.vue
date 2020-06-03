<template>
  <div class="home container">
    <div class="row">
      <div class="col-12">
        <h1 class="text-center">Garden Boxer</h1>
      </div>
      <div class="col-12 text-center">
        <h3>About us: </h3>
        <h5>We're not a company and we don't have a mission, but you know, why not.</h5>
      </div>
      <div class="col-12 text-center">
        <img src="https://www.rd.com/wp-content/uploads/2014/10/15-hampton-the-worlds-15-most-unforgettable-royal-gardens-211608664-PlusONE-760x506.jpg" alt="a picture">
        <h4 class="mt-2">
          Just think, with this app this could be you.
        </h4>
      </div>
      <img class="flower1" src="flowers-home.png" alt="">
      <img class="flower2" src="flowers-home.png" alt="">
    </div>
  </div>
</template>

<script>
export default {
  name: "home",
  computed: {
    user() {
      return this.$store.state.user;
    }
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    }
  }
};
</script>
<style scoped>
div img {
  margin-top: 20px;
  /* height: 550px; */
  min-width: 300px;
  max-width: 700px;
  min-height: 150px;
  max-height: 400px;
}
.flower1 {
  position: absolute;
  left: -100px;
  top: 200px;
  max-width: 400px;
  min-width: 100px;
  transform: rotate(35deg);
  /* transform: scaleX(-1) */
}
.flower2 {
  position: absolute;
  right: -70px;
  top:200px;
  max-width: 400px;
  min-width: 100px;
  transform: rotate(-25deg)
}
</style>
