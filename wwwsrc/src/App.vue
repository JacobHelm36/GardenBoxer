<template>
  <div id="app">
    <navbar />
    <router-view />
  </div>
</template>

<script>
import Datepicker from "vuejs-datepicker";
import Navbar from "@/components/navbar";
import { onAuth } from "@bcwdev/auth0-vue";
export default {
  name: "App",
  async beforeCreate() {
    await onAuth();
    this.$store.dispatch("setBearer", this.$auth.bearer);
  },
  components: {
    Navbar
  }
};
</script> 

<style lang="scss">
@import "./assets/_variables.scss";
@import "./assets/_overrides.scss";
</style>
