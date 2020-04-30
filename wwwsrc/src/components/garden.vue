<template>
  <div
    class="box cont d-flex justify-content-center"
    id="garden"
    v-bind:style="{ 'min-width': plotDimensions.plotWidth, 'max-width': plotDimensions.plotWidth, 'min-height': plotDimensions.plotHeight, 'max-height': plotDimensions.plotHeight, 'padding-bottom':plotDimensions.plotHeight}"
    @click.prevent="click($event)"
  >
    <add-bed
      class="add-bed"
      id="bed-form"
      v-bind:style="{'top':formCoords.top + 'px', 'left': formCoords.left + 'px'}"
      v-show="clickable"
      :coords="bedCoordinates"
      :formActive="formActive"
    />
    <div v-bind:style="{'top':gridCoords.y + 'px', 'left':gridCoords.x + 'px', 'min-width': WInterval + 'px', 'min-height': HInterval + 'px'}" v-if="formActive" class="outline"></div>
    
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
      if (e.toElement.id == "garden" && this.clickable) {
        this.HInterval = e.toElement.offsetHeight / this.gardenData.height;
        this.WInterval = e.toElement.offsetWidth / this.gardenData.width;
        this.bedCoords.bedY = Math.floor(e.offsetY / this.HInterval);
        this.bedCoords.bedX = Math.floor(e.offsetX / this.WInterval);
        this.formCoords.top = e.offsetY;
        this.formCoords.left = e.offsetX;
        this.form = true;
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
    },
    gridCoords(){
      let x = this.bedCoords.bedX * this.WInterval;
      let y = this.bedCoords.bedY * this.HInterval;
      return {
        x,y
      }
    },
    formBox() {
      let bottom = document.getElementById("bed-form").offsetHeight;
      let right = document.getElementById("bed-form").offsetWidth;
      return [this.formCoords.top, this.formCoords.left, bottom, right];
    },
    formActive() {
      return this.form;
    }
  },
  components: {
    AddBed
  },
  data() {
    return {
      form: false,
      formCoords: {
        left: 0,
        top: 0
      },
      bedCoords: {
        bedX: 0,
        bedY: 0
      },
      HInterval:0,
      WInterval:0
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
.outline {
  position:absolute;
  border:1px solid black;
}
</style>
