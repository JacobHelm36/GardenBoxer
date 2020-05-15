<template>
  <div class="col-6 col-md-4 bed-card mb-1 mt-1" @click="setActive()">
    <!-- <img
      draggable="true"
      @dragend="drop($event)"
      @dragstart="drag = true"
      @drag="dragIt($event)"
      :src="bedData.img"
      class="img-fluid"
      alt
    />-->
    <div
      class="bed-model"
      :style="{'width': plotDimensions.plotWidth, 'padding-bottom':plotDimensions.plotHeight, 'background-image':`url('${bedData.img}')`}"
      @dragend="drop($event)"
      @dragstart="drag = true"
      @drag="dragIt($event)"
      :draggable="template"
    ></div>
    <h4>{{bedData.name}}</h4>
    <p>{{bedData.description}}</p>
    <button v-if="!template" @click="save()" class="btn btn-sm btn-primary">Save</button>
    <!-- <div
      v-if="drag"
      :style="{'background-image':`url('${bedData.img}')`, 'min-height': (Interval.HInterval * bedData.height) + 'px', 'min-width': (Interval.WInterval * bedData.width) + 'px', 'top': this.top + 'px', 'left':this.left + 'px'}"
      class="dummy"
    ></div>-->
  </div>
</template>
<script>
export default {
  props: ["bedData", "template"],
  methods: {
    setActive() {
      if (this.active) {
        this.$store.dispatch("removeHover", this.bedData.id);
        return;
      }
      this.$store.dispatch("addHover", this.bedData.id);
    },
    save() {
      this.$store.dispatch("saveBed", this.bedData);
    },
    deleteSave() {
      this.$store.dispatch("removeSavedBed", this.bedData.id);
    },
    dragIt(e) {
      if (e.clientX) {
        // debugger;
        this.top = e.clientY - this.offset.y;
        this.left = e.clientX - this.offset.x;
      }
    },
    drop(e) {
      // debugger;
      let tempY = Math.ceil(this.top / this.Interval.HInterval);
      let tempX = Math.ceil(this.left / this.Interval.WInterval);
      if (tempY > this.garden.height) {
        tempY = this.garden.height;
      }
      if (tempX > this.garden.width) {
        tempX = this.garden.width;
      }
      if (tempX < 1) {
        tempX = 1;
      }
      if (tempY < 1) {
        tempY = 1;
      }
      if (
        this.$store.state.beds.filter(
          b => b.bedY == tempY && b.bedX == tempX
        )[0]
      ) {
        return;
      }
      let date = new Date();
      this.newBed.bedX = parseInt(tempX);
      this.newBed.bedY = parseInt(tempY);
      this.newBed.gardenId = parseInt(this.$route.params.id);
      this.newBed.datePlanted = date.toJSON();
      this.newBed.dateFertilized = date.toJSON();
      this.top = this.newBed.bedY * this.Interval.HInterval;
      this.left = this.newBed.bedX * this.Interval.WInterval;
      this.drag = false;
      this.$store.dispatch("createBed", this.newBed);
    }
  },
  computed: {
    active() {
      return this.$store.state.activeHover[this.bedData.id];
    },
    Interval() {
      return this.$store.state.activeGardenDimensions;
    },
    offset() {
      return this.$store.state.offset;
    },
    garden() {
      return this.$store.state.activeGarden;
    },
    plotDimensions() {
      let ratio = this.bedData.height / this.bedData.width;
      console.log(this.bedData.height + " AND " + this.bedData.width);
      if (ratio > 1) {
        return {
          plotWidth:
            (this.bedData.width / this.bedData.height) * this.percent + "%",
          plotHeight: this.percent + "%"
        };
      }
      return {
        plotHeight: ratio * this.percent + "%",
        plotWidth: this.percent + "%"
      };
    }
  },
  data() {
    return {
      drag: false,
      top: 0,
      left: 0,
      percent: 100,
      newBed: this.bedData
    };
  }
};
</script>
<style scoped>
img {
  left: 0px;
}
.bed-card:hover {
  cursor: pointer;
}
.dummy {
  background-size: 100%;
  position: absolute;
  z-index: 2;
}
.bed-model {
  background-size: 100%;
  background-color: brown;
  z-index: 1;
}
</style>