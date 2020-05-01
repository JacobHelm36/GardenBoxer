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
      v-bind:style="{'top':(bed.bedY * Interval.HInterval) + 'px', 'left':(bed.bedX * Interval.WInterval)+ 'px', 'min-width': Interval.WInterval + 'px', 'min-height': Interval.HInterval + 'px','max-width': Interval.WInterval + 'px', 'max-height': Interval.HInterval + 'px'}"
      :bedData="bed"
    />
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
      if(this.$route.params.id != this.gardenData.id){
        clearInterval(this.interval)
      }
      this.HInterval =
        document.getElementById("garden").offsetHeight / this.gardenData.height;
      this.WInterval =
        document.getElementById("garden").offsetWidth / this.gardenData.width;
      console.log(this.$route.params.id +"vs"+ this.gardenData.id);
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
    bedCoordinates() {
      return this.bedCoords;
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
    beds() {
      return this.$store.state.beds;
    },
    Interval() {
      return { WInterval: this.WInterval, HInterval: this.HInterval };
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
      interval: null
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
  background-color: rgb(131, 82, 53)
}
</style>
