<template>
  <div
    :style="{'top':(Interval.HInterval * (bedData.bedY - 1)) + 'px', 'left': (Interval.WInterval * (bedData.bedX - 1))+'px', 'min-width': Interval.WInterval * this.bedData.width + 'px', 'min-height':Interval.HInterval * this.bedData.height + 'px', 'background-image':`url('${bedData.img}')`, 'opacity':opacity}"
    @click="info1()"
    class="beds"
    id="beds"
    draggable="true"
    @mousedown="clickIt($event)"
    @mouseup="drop($event)"
    @drag="dragIt($event)"
    @dragend="drop($event)"
  >
    <div :style="{'top':HInterval + 'px', 'left':WInterval + 'px'}" v-if="info" class="popup">
      <p>{{bedData.name}}</p>
      <button @click="bedEditForm = !bedEditForm" class="btn btn-edit">Edit</button>
      <button @click="deleteBed(bedData.id)" class="btn btn-danger">Delete</button>
    </div>
    <div class="edit-bed-form" :style="{'top':HInterval + 'px', 'left': 126.77 + WInterval + 'px'}" v-if="bedEditForm">
      <div class="form">
        <input
          type="text"
          class="form-control-sm"
          v-model="editedBed.name"
          placeholder="Enter a plant"
        />
        <input
          type="number"
          class="form-control-sm"
          v-model.number="editedBed.width"
          placeholder="Enter a width"
        />
        <input
          type="number"
          class="form-control-sm"
          v-model.number="editedBed.height"
          placeholder="Enter a height"
        />
        <input
          type="text"
          class="form-control-sm"
          v-model="editedBed.img"
          placeholder="Enter an image"
        />
        <date-picker
          class="form-control-sm"
          v-bind:style="{'max-width': '0px' }"
          v-model="editedBed.datePlanted"
          lang="en"
          type="date"
          format="YYYY-MM-dd"
          placeholder="Change date planted"
        ></date-picker>
        <date-picker
          class="form-control-sm"
          v-bind:style="{'max-width': '0px' }"
          v-model="editedBed.dateFertilized"
          lang="en"
          type="date"
          format="YYYY-MM-dd"
          placeholder="Change date fertilized"
        ></date-picker>
        <div class="flex">
          <button type="button" class="btn btn-success" @click="updateBed()">Save Changes</button>
          <button type="button" class="btn btn-danger" @click="cancelEditBed()">Cancel</button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import DatePicker from "vue2-datepicker";
export default {
  props: ["bedData", "clicker"],
  mounted() {
    this.HInterval =
      document.getElementById("garden").offsetHeight / this.garden.height;
    this.WInterval =
      document.getElementById("garden").offsetWidth / this.garden.width;
    this.left = (this.bedData.bedX - 1) * this.WInterval;
    this.top = (this.bedData.bedY - 1) * this.HInterval;
  },
  methods: {
    bedForm() {
      this.bedEditForm = !this.bedEditForm;
    },
    info1() {
      if (this.bedEditForm == false) {
        this.info = !this.info;
      }
    },
    updateBed() {
      this.$store.dispatch("editBed", this.editedBed);
    },
    cancelEditBed() {
      this.bedEditForm = false;
    },
    deleteBed(id) {
      this.$store.dispatch("deleteBed", id);
    },
    clickIt(e) {
      this.drag = true;
      this.left = (this.bedData.bedX - 1) * this.Interval.WInterval;
      this.top = (this.bedData.bedY - 1) * this.Interval.HInterval;
      this.offset.x = e.clientX - e.offsetX - this.left;
      this.offset.y = e.clientY - e.offsetY - this.top;
      this.$store.dispatch("setOffset", this.offset);
      this.initX = e.clientX;
      this.initY = e.clientY;
    },
    drop(e) {
      if (
        e.clientY - this.initY < 1 &&
        e.clientY - this.initY > -1 &&
        e.clientX - this.initX < 1 &&
        e.clientX - this.initX > -1
      ) {
        this.drag = false;
        return;
      }
      this.tempY = Math.ceil(this.top / this.HInterval);
      this.tempX = Math.ceil(this.left / this.WInterval);
      if (this.tempY > this.garden.height) {
        this.tempY = this.garden.height;
      }
      if (this.tempX > this.garden.width) {
        this.tempX = this.garden.width;
      }
      if (this.tempX < 1) {
        this.tempX = 1;
      }
      if (this.tempY < 1) {
        this.tempY = 1;
      }
      if (
        this.$store.state.beds.filter(
          b => b.bedY == this.tempY && b.bedX == this.tempX
        )[0]
      ) {
        return;
      }
      this.bedData.bedX = this.tempX;
      this.bedData.bedY = this.tempY;
      this.top = this.bedData.bedY * this.Interval.HInterval;
      this.left = this.bedData.bedX * this.Interval.WInterval;
      this.drag = false;
      this.$store.dispatch("editBed", {
        id: this.bedData.id,
        bedX: this.bedData.bedX,
        bedY: this.bedData.bedY
      });
    },
    dragIt(e) {
      if (this.drag && e.clientX) {
        this.top = e.clientY - this.offset.y;
        this.left = e.clientX - this.offset.x;
      }
    }
  },
  data() {
    return {
      editedBed: {
        name: this.bedData.name,
        width: this.bedData.width,
        height: this.bedData.height,
        img: this.bedData.image,
        datePlanted:
          this.bedData.datePlanted || this.$state.beds == this.bedData.id,
        dateFertilized: this.bedData.dateFertilized,
        bedX: this.bedData.bedX,
        bedY: this.bedData.bedY,
        gardenId: this.bedData.gardenId,
        id: this.bedData.id
      },
      info: false,
      HInterval: 0,
      WInterval: 0,
      bedEditForm: false,
      drag: false,
      top: 0,
      left: 0,
      offset: {
        x: 0,
        y: 0
      },
      initX: 0,
      initY: 0,
      tempX: 0,
      tempY: 0
    };
  },
  computed: {
    bedInfo() {
      console.log(this.bedData);
      return this.bedData;
    },
    Interval() {
      return this.$store.state.activeGardenDimensions;
    },
    garden() {
      return this.$store.state.activeGarden;
    },
    active() {
      return this.$store.state.activeHover[this.bedData.id];
    },
    opacity() {
      if (this.active) {
        return "50%";
      }
      return "100%";
    }
  },
  components: { DatePicker }
};
</script>


<style scoped>
.flex {
  display: flex;
}
.popup {
  position: absolute;
  background-color: rgb(139, 224, 82);
  text-align: center;
  z-index: 1;
}
.edit-bed-form {
  position: absolute;
}
img {
  max-width: 100%;
}
.beds {
  background-color: brown;
  background-size: 100%;
}
.beds:active {
  cursor: help;
}
</style>