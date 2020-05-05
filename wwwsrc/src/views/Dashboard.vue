<template>
  <div class="dashboard container">
    <div class="col-12 text-center">
      <h1>Your Gardens</h1>
    </div>
    <div class="row">
      <garden v-for="garden in gardens" :key="garden.id" :gardenData="garden" />
    </div>
    <div
      @mousedown="clickIt($event)"
      @mouseup="drop()"
      @mousemove="dragIt($event)"
      :style="{'top': top + 'px', 'left': left + 'px'}"
      class="drag"
    ></div>
  </div>
</template>

<script>
import Garden from "../components/gardenCard.vue";
export default {
  async mounted() {
    if (await this.$auth.isAuthenticated) {
      this.$store.dispatch("getGardens");
    }
  },
  computed: {
    gardens() {
      return this.$store.state.gardens;
    }
  },
  methods: {
    clickIt(e) {
      this.drag = true;
      this.offset.x = e.offsetX;
      this.offset.y = e.offsetY;
    },
    drop(e) {
      this.drag = false;
      console.log(this.drag);
    },
    dragIt(e) {
      if (this.drag) {
        this.top = e.clientY - this.offset.y;
        this.left = e.clientX - this.offset.x;
      }
    }
  },
  components: {
    Garden
  },
  data() {
    return {
      drag: false,
      top: 0,
      left: 0,
      offset: {
        x: 0,
        y: 0
      }
    };
  }
};
</script>

<style scoped>
.drag {
  min-height: 50px;
  min-width: 50px;
  background-color: darkcyan;
  position: absolute;
}
</style>
