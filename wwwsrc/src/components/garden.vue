<template>
  <div class="row cont d-flex justify-content-center">
    <div
      @click.prevent="click($event)"
      class="col-12 box p-0"
      v-bind:style="{ 'min-width': plotDimensions.plotWidth, 'max-width': plotDimensions.plotWidth, 'min-height': plotDimensions.plotHeight, 'max-height': plotDimensions.plotHeight}"
    ></div>
  </div>
</template>

<script>
export default {
  name: "create",
  props: ["gardenData"],
  mounted() {},
  methods: {
    click(e) {
      console.log(e);
      console.log(e.offsetY);
      console.log(e.offsetX);
      return e.offsetX;
    }
  },
  computed: {
    plotDimensions() {
      let ratio = this.gardenData.height / this.gardenData.width;
      if (ratio > 1.2) {
        return {
          plotWidth:
            (this.gardenData.width / this.gardenData.height) * 100 + "%",
          plotHeight: "100%"
        };
      }
      return {
        plotHeight: ratio * 100 + "%",
        plotWidth: "100%"
      };
    }
  },
  components: {},
  data() {
    return {};
  }
};
</script>

<style scoped>
.box {
  background-color: rgb(42, 165, 73);
  border: 1px solid black;
}
.cont {
  min-width: 10rem;
  min-height: 10rem;
  max-width: 10rem;
  max-height: 10rem;
}
</style>
