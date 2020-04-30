<template>
  <div
    class="box cont d-flex justify-content-center"
    v-bind:style="{ 'min-width': plotDimensions.plotWidth, 'max-width': plotDimensions.plotWidth, 'min-height': plotDimensions.plotHeight, 'max-height': plotDimensions.plotHeight, 'padding-bottom':plotDimensions.plotHeight}"
    @click.prevent="click($event)"
  >
    <add-bed
      class="add-bed"
      v-bind:style="{'top':formCoords.top, 'left': formCoords.left}"
      v-if="form"
      v-show="clickable"
      :coords="bedCoords"
    />
    <!-- <button v-if="cancellation">Cancel</button> -->
  </div>
</template>

<script>
import AddBed from "../components/addBed";
export default {
  name: "create",
  props: ["gardenData", "clickable"],
  mounted() {},
  methods: {
    click(e) {
      if (!this.form) {
        let Hinterval = e.toElement.offsetHeight / this.gardenData.height;
        let Winterval = e.toElement.offsetWidth / this.gardenData.width;
        this.bedCoords.bedY = Math.round(e.offsetY / Hinterval);
        this.bedCoords.bedX = Math.round(e.offsetX / Winterval);
        this.formCoords.top = e.offsetY + "px";
        this.formCoords.left = e.offsetX + "px";
        this.form = true;
        // this.cancellation = true;
      }
    },
    cancel() {
      if (this.form) {
        this.form = false;
        this.cancellation = false;
      }
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
    },
    bedCoordinates() {
      return this.bedCoords;
    }
  },
  components: {
    AddBed
  },
  data() {
    return {
      form: false,
      cancellation: false,
      formCoords: {
        left: 0,
        top: 0
      },
      bedCoords: {
        bedX: 0,
        bedY: 0
      }
    };
  }
};
</script>

<style>
.box {
  background-color: rgb(42, 165, 73);
  border: 1px solid black;
}
.cont {
  width: 95%;
  padding-bottom: 95%;
}
.add-bed {
  position: absolute;
}
</style>
