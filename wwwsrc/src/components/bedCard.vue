<template>
  <div class="col-6 col-md-4 bed-card mb-1 mt-1" @click="setActive()">
    <img
      draggable="true"
      @dragend="drop($event)"
      @dragstart="drag = true"
      @drag="dragIt($event)"
      :src="bedData.img"
      class="img-fluid"
      alt
    />
    <h4>{{bedData.name}}</h4>
    <p>{{bedData.description}}</p>
    <button v-if="!template" @click="save()" class="btn btn-sm btn-primary">Save</button>
    <div
      v-if="drag"
      :style="{'background-image':`url('${bedData.img}')`, 'min-height': (Interval.HInterval * bedData.height) + 'px', 'min-width': (Interval.WInterval * bedData.width) + 'px', 'top': this.top + 'px', 'left':this.left + 'px'}"
      class="dummy"
    ></div>
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
        debugger;
        this.top = e.clientY - this.offset.y;
        this.left = e.clientX - this.offset.x;
      }
    },
    drop(e) {
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
      this.bedData.bedX = tempX;
      this.bedData.bedY = tempY;
      this.top = this.bedData.bedY * this.Interval.HInterval;
      this.left = this.bedData.bedX * this.Interval.WInterval;
      this.drag = false;
      console.log(this.bedData);
      this.$store.dispatch("createBed", this.bedData);
    }
  },
  computed: {
    active() {
      return this.$store.state.activeHover[this.bedData.id];
    },
    Interval() {
      let garden = this.$store.state.activeGarden;
      let dims = this.$store.state.activeGardenDimensions;
      let HInterval = dims.height / garden.height;
      let WInterval = dims.width / garden.width;
      return { HInterval, WInterval };
    },
    offset() {
      return this.$store.state.offset;
    },
    garden() {
      return this.$store.state.activeGarden;
    }
  },
  data() {
    return {
      drag: false,
      top: 0,
      left: 0
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
</style>