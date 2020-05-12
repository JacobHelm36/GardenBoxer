<template>
  <div v-bind:style="{height:this.offsetHeight + 'px'}" class="side-wrapper">
    <button @click="toggleIt" class="btn btn-primary side-toggle">TOGGLE</button>
    <div class="side-bar d-flex flex-column" v-bind:style="{'left': left + '%'}">
      <button @click="toggleIt" class="btn btn-secondary align-self-end">Toogle</button>
      <div class="d-flex flex-row justify-content-around mt-2 mb-2">
        <button @click="active = 'group'" class="btn btn-warning">groups</button>
        <button @click="active = 'bed'" class="btn btn-warning">beds</button>
        <button @click="active = 'save'" class="btn btn-warning">saves</button>
      </div>
      <div v-if="active == 'bed'" class="row beds-spot">
        <bed v-for="bed in beds" :key="bed.id" :bedData="bed" />
      </div>
      <div v-if="active == 'group'" class="row groups-spot"></div>
      <div v-if="active == 'save'" class="row saves-spot"></div>
    </div>
  </div>
</template>

<script>
import Bed from "../components/bedCard";
export default {
  name: "Sidebar",
  mounted() {
    setTimeout(this.pollHeight, 1000);
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
    pollHeight() {
      this.offsetHeight = document.getElementById("garden-view").offsetHeight;
    }
  },
  data() {
    return {
      left: -100,
      toggle: true,
      toggleInterval: null,
      active: "bed"
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
  max-width: 100%;
}
.beds-spot {
  max-width: 100%;
  margin-left: 0px;
}
</style>
