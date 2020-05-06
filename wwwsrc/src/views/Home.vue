<template>
  <div class="home container">
    <div class="row">
      <div class="col-12 mb-3 d-flex justify-content-center text-center">
        <h1>Garden Boxer</h1>
      </div>
      <div class="col-6 d-flex justify-content-end align-items-center">
        <h3 class="mb-0">About:</h3>
      </div>
      <div class="col-6 d-flex justify-content-start align-items-center">
        <p class="mb-0">We're not a company and we don't have a mission, but you know, why not.</p>
      </div>
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
