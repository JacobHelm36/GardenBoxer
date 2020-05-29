<template>
  <div
    class="box cont"
    id="garden"
    v-bind:style="{ 'min-width': plotDimensions.plotWidth, 'max-width': plotDimensions.plotWidth,'padding-bottom':plotDimensions.plotHeight, backgroundColor : this.gardenData.backGround}"
    @click.prevent="click($event)"
  >
    <add-bed
      class="add-bed"
      id="bed-form"
      v-bind:style="{'top':gridCoords.y + 'px', 'left':(gridCoords.x + WInterval) + 'px'}"
      v-show="clickable"
      @formToFalse="form = false"
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
      :bedData="bed"
    />
    <!-- v-bind:style="{'top':(bed.bedY * Interval.HInterval) + 'px', 'left':(bed.bedX * Interval.WInterval)+ 'px', 'min-width': Interval.WInterval + 'px', 'min-height': Interval.HInterval + 'px','max-width': Interval.WInterval + 'px', 'max-height': Interval.HInterval + 'px'}" -->
  </div>
</template>

<script>
import AddBed from "../components/addBed";
import Bed from "../components/bed";
export default {
  props: ["gardenData", "clickable", "percent", "showBeds"],
  async mounted() {
    if (this.showBeds) {
      this.interval = setInterval(this.pollDim, 1000);
      let rect = await document
        .getElementById("garden")
        .getBoundingClientRect();
      let offset = { x: rect.left, y: rect.top };
      this.$store.dispatch("setOffset", offset);
    }
  },
  methods: {
    // NOTE gets the beds & form coordinates for x & y
    click(e) {
      if (e.toElement.id == "garden" && this.clickable) {
        this.bedCoords.bedY = Math.ceil(e.offsetY / this.Interval.HInterval);
        this.bedCoords.bedX = Math.ceil(e.offsetX / this.Interval.WInterval);
        this.formCoords.top = e.offsetY;
        this.formCoords.left = e.offsetX;
        this.form = !this.form;
      }
    },
    // NOTE gets the height interval and width interval
    pollDim() {
      if (this.$route.params.id != this.gardenData.id) {
        clearInterval(this.interval);
      }
      this.HInterval =
        document.getElementById("garden").offsetHeight / this.gardenData.height;
      this.WInterval =
        document.getElementById("garden").offsetWidth / this.gardenData.width;
      this.$store.dispatch("updateGardenDimensions", this.Interval);
    }
  },
  computed: {
    //NOTE gets the plots dimensions on the screen
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
      let x = (this.bedCoords.bedX - 1) * this.Interval.WInterval;
      let y = (this.bedCoords.bedY - 1) * this.Interval.HInterval;
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
      console.log(this.bedCoords);
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
  /* background-color: rgb(42, 165, 73); */
  border: 1px solid black;
}
.add-bed {
  position: absolute;
  z-index: 1;
}
.outline {
  position: absolute;
  border: 1px solid black;
}
.beds {
  position: absolute;
  border: 5px rgb(53, 83, 44);
}
</style>
