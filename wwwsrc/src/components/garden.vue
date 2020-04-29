<template>
  <div
    class="box cont d-flex justify-content-center"
    v-bind:style="{ 'min-width': plotDimensions.plotWidth, 'max-width': plotDimensions.plotWidth, 'min-height': plotDimensions.plotHeight, 'max-height': plotDimensions.plotHeight}"
    @click.prevent="click($event)"
  ></div>
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
            (this.gardenData.width / this.gardenData.height) * 95 + "%",
          plotHeight: "95%"
        };
      }
      return {
        plotHeight: ratio * 95 + "%",
        plotWidth: "95%"
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
  width: 95%;
  padding-bottom: 95%;
}
</style>
