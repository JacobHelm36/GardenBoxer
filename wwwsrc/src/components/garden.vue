<template>
  <div
    class="box cont"
    id="garden"
    v-bind:style="{ 'min-width': plotDimensions.plotWidth, 'max-width': plotDimensions.plotWidth,'padding-bottom':plotDimensions.plotHeight}"
    @click.prevent="click($event)"
  >
    <add-bed
      class="add-bed"
      id="bed-form"
      v-bind:style="{'top':formCoords.top + 'px', 'left': formCoords.left + 'px'}"
      v-show="clickable"
      v-if="form"
      :coords="bedCoordinates"
    />
    <div
      v-bind:style="{'top':gridCoords.y + 'px', 'left':gridCoords.x + 'px', 'min-width': WInterval + 'px', 'min-height': HInterval + 'px'}"
      v-if="form"
      class="outline"
    ></div>

    <bed
      v-show="showBeds"
      v-for="bed in beds"
      :key="bed.id"
      :clicker="true"
      class="beds"
      @mousedown="clickIt($event)"
      @mouseup="drop()"
      @mousemove="dragIt($event)"
      @click="clickIt()"
      :bedData="bed"
      :gardenDim="gardenDim"
    />
    <!-- v-bind:style="{'top':(bed.bedY * Interval.HInterval) + 'px', 'left':(bed.bedX * Interval.WInterval)+ 'px', 'min-width': Interval.WInterval + 'px', 'min-height': Interval.HInterval + 'px','max-width': Interval.WInterval + 'px', 'max-height': Interval.HInterval + 'px'}" -->
  </div>
  
</template>

<script>
import AddBed from "../components/addBed";
import Bed from "../components/bed";
export default {
  props: ["gardenData", "clickable", "percent", "showBeds"],
  mounted() {
    if (this.showBeds) {
      this.interval = setInterval(this.pollDim, 1000);
    }
  },
  methods: {
    click(e) {
      if (e.toElement.id == "garden" && this.clickable) {
        this.bedCoords.bedY = Math.floor(e.offsetY / this.Interval.HInterval);
        this.bedCoords.bedX = Math.floor(e.offsetX / this.Interval.WInterval);
        this.formCoords.top = e.offsetY;
        this.formCoords.left = e.offsetX;
        this.form = !this.form;
      }
    },
    pollDim() {
      if (this.$route.params.id != this.gardenData.id) {
        clearInterval(this.interval);
      }
      this.HInterval =
        document.getElementById("garden").offsetHeight / this.gardenData.height;
      this.WInterval =
        document.getElementById("garden").offsetWidth / this.gardenData.width;
      console.log(this.$route.params.id + "vs" + this.gardenData.id);
    },
    clickIt(e) {
      this.drag = true;
      this.offset.x = e.offsetX;
      this.offset.y = e.offsetY;
      console.log("click");
    },
    drop(e) {
      this.drag = false;
      console.log(this.drag);
      console.log(this.top);
    },
    dragIt(e) {
      if (this.drag) {
        this.top = e.clientY - this.offset.y;
        this.left = e.clientX - this.offset.x;
      }
    }
  },
  computed: {
    plotDimensions() {
      let ratio = this.gardenData.height / this.gardenData.width;
      if (ratio > 1) {
        return {
          plotWidth:
            (this.gardenData.width / this.gardenData.height) * this.percent +
            "%",
          plotHeight: this.percent + "%"
        };
      }
      return {
        plotHeight: ratio * this.percent + "%",
        plotWidth: this.percent + "%"
      };
    },
    gridCoords() {
      let x = this.bedCoords.bedX * this.Interval.WInterval;
      let y = this.bedCoords.bedY * this.Interval.HInterval;
      return {
        x,
        y
      };
    },
    formBox() {
      let bottom = document.getElementById("bed-form").offsetHeight;
      let right = document.getElementById("bed-form").offsetWidth;
      return [this.formCoords.top, this.formCoords.left, bottom, right];
    },
    bedCoordinates() {
      console.log(this.bedCoords)
      return this.bedCoords;
    },
    beds() {
      return this.$store.state.beds;
    },
    Interval() {
      return { WInterval: this.WInterval, HInterval: this.HInterval };
    },
    gardenDim() {
      return { width: this.gardenData.width, height: this.gardenData.height };
    }
  },
  components: {
    AddBed,
    Bed
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
      WInterval: 0,
      HInterval: 0,
      interval: null,
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

<style>
.box {
  background-color: rgb(42, 165, 73);
  border: 1px solid black;
}
.add-bed {
  position: absolute;
}
.outline {
  position: absolute;
  border: 1px solid black;
}
.beds {
  position: absolute;
  border: 1px black;
  background-color: rgb(131, 82, 53);
}
</style>
