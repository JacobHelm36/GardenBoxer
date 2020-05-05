<template>
  <div v-bind:style="{'height':windowHeight}" class="side-wrapper">
    <button @click="toggleIt" class="btn btn-primary side-toggle">TOGGLE</button>
    <div class="side-bar d-flex flex-column align-items-start" v-bind:style="{'left': left + '%'}">
      <button @click="toggleIt" class="btn btn-secondary align-self-end">Toogle</button>
      <button @click="info()" class="btn btn-warning">content</button>
      <p>stuff</p>
    </div>
  </div>
</template>

<script>
export default {
  name: "Sidebar",
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
    windowHeight() {
      return document.getElementById("garden-view").offsetHeight + "px";
    }
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
  height: 100vh;
  position: absolute;
  min-width: 100%;
  background-color: blue;
  z-index: 1;
}
</style>
