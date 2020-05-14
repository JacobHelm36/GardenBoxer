<template>
  <div id="app">
    <navbar />
    <router-view />
  </div>
</template>

<script>
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
div.mx-datepicker-content {
  background-color: aqua;
}
span button.mx-btn {
  background-color: lightgreen
}
table.mx-table.mx-table-date {
  cursor: pointer;
}
</style>
