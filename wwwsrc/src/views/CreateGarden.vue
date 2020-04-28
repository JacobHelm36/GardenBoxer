<template>
  <div class="dashboard container">
    <div class="row">
      <div class="col-12">
        <div
          v-for="grid in grids"
          v-bind:style="{ 'min-height': plotHeight + '%', 'min-width': plotWidth + '%'}"
          :key="grid"
          class="grid"
        >
          <p>hi</p>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name:"create",
  mounted() {
  },
  computed: {
    grids() {
      let arr = [];
      let num = this.width * this.height;
      for (let i = 0; i++; i < num) {
        arr.push(i);
      }
      return arr;
    },
    plotWidth() {
      return 100 / this.width;
    },
    plotHeight() {
      return 100 / this.height;
    }
  },
  components: {
  },
  data() {
    return {
      width: 2,
      height: 2
    };
  }
};
</script>

<style>
.grid {
  background-color: brown;
  border: 1px solid black;
}
</style>
