<template>
  <div v-bind:style="{}" class="side-wrapper">
    <button @click="toggleIt" class="btn btn-primary side-toggle">TOGGLE</button>
    <div class="side-bar d-flex flex-column align-items-start" v-bind:style="{'left': left + '%'}">
      <button @click="toggleIt" class="btn btn-secondary align-self-end">Toogle</button>
      <button @click="info()" class="btn btn-warning">content</button>
      <p>stuff</p>
      <bed v-for="bed in beds" :key="bed.id" :bedData="bed" />
    </div>
  </div>
</template>

<script>
import Bed from "../components/bedCard";
export default {
  name: "Sidebar",
  mounted() {
    setTimeout(
      (this.offsetHeight = document.getElementById("garden-view").offsetHeight),
      1000
    );
  },
  methods: {
    toggleIt() {
      if (!this.toggleInterval) {
        if (this.toggle) {
          this.toggleInterval = setInterval(this.out, 5);
          return;
        }
        this.toggleInterval = setInterval(this.in, 5);
      }
    },
    in() {
      if (this.left > -100) {
        this.left--;
        return;
      }
      clearInterval(this.toggleInterval);
      this.toggleInterval = 0;
      this.toggle = !this.toggle;
    },
    out() {
      if (this.left < 0) {
        this.left++;
        return;
      }
      clearInterval(this.toggleInterval);
      this.toggleInterval = 0;
      this.toggle = !this.toggle;
    },
    info() {
      console.log(document.getElementById("app").scrollHeight);
    }
  },
  data() {
    return {
      left: -100,
      toggle: true,
      toggleInterval: null
    };
  },
  computed: {
    beds() {
      return this.$store.state.beds;
    }
  },
  components: {
    Bed
  }
};
</script>

<style>
.side-wrapper {
  overflow: hidden;
  position: absolute;
  left: 0px;
  min-width: 25%;
  height: 100%;
}
.side-bar {
  top: 0px;
  height: 100%;
  position: absolute;
  min-width: 100%;
  background-color: blue;
  z-index: 1;
  max-width:100%;
}
</style>
