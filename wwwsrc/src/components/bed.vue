<template>
  <div
    :style="{'top':fTop + 'px', 'left': fLeft+'px', 'min-width': Interval.WInterval * this.bedData.width + 'px', 'min-height':Interval.HInterval * this.bedData.height + 'px', 'background-image':`url('${bedData.img}')`, 'opacity':opacity}"
    @click="info1()"
    class="beds"
    id="beds"
    draggable="true"
    @mousedown="clickIt($event)"
    @mouseup="drop($event)"
    @drag="dragIt($event)"
    @dragend="drop($event)"
  >
    <div
      :style="{'top': 'px', 'left':Interval.WInterval + 'px'}"
      v-if="info"
      class="popup"
    >
      <p>{{bedData.name}}</p>
      <button @click="bedViewForm = !bedViewForm" id="viewBedBtn" class="btn btn-primary">View Bed</button>
      <button @click="bedEditForm = !bedEditForm" id="editBedBtn" class="btn btn-edit">Edit</button>
      <button @click="deleteBed(bedData.id)" class="btn btn-danger">Delete</button>
    </div>
    <div class="edit-bed-form" :style="{'top': 'px', 'left': 126.77 + Interval.WInterval + 'px'}" v-if="bedEditForm">
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
    <div class="view-bed-form" :style="{'top': 'px', 'left': 126.77 + Interval.WInterval + 'px'}" v-if="bedViewForm">
      <div class="form">
        <p>{{bedData.name}}</p>
        <p>Width: {{bedData.width}}</p>
        <p>Height: {{bedData.height}}</p>
        <p>Planted: {{bedData.datePlanted}}</p>
        <p>Fertilized{{bedData.dateFertilized}}</p>
        <div class="d-flex">
          <button type="button" class="btn btn-danger" @click="bedViewForm = !bedViewForm">Got It!</button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import DatePicker from "vue2-datepicker";
export default {
  props: ["bedData", "clicker"],
  mounted() {},
  methods: {
    info1() {
      if (this.bedEditForm == false && this.bedViewForm == false) {
        this.info = !this.info;
      } 
    },
    updateBed() {
      this.$store.dispatch("editBed", this.editedBed);
      this.bedEditForm = !this.bedEditForm;
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
      this.tempY = Math.ceil(this.top / this.Interval.HInterval);
      this.tempX = Math.ceil(this.left / this.Interval.WInterval);
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
      bedEditForm: false,
      bedViewForm: false,
      drag: false,
      top: 0,
      left: 0,
      initX: 0,
      initY: 0,
      tempX: 0,
      tempY: 0
    };
  },
  computed: {
    bedInfo() {
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
    },
    offset() {
      return this.$store.state.offset;
    },
    fLeft() {
      return (this.bedData.bedX - 1) * this.Interval.WInterval;
    },
    fTop() {
      return (this.bedData.bedY - 1) * this.Interval.HInterval;
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
  font-size: 95%;
  width:126.77px;
  height:76px;
  border:1px rgb(44, 30, 30) solid;
}
.edit-bed-form {
  position: absolute;
  z-index: 1;
}
.view-bed-form {
  position: absolute;
  z-index: 1;
  width: 100%;
  background-color: white;
}
img {
  max-width: 100%;
  /* no repeat */
}
.beds {
  background-color: rgb(88, 59, 59);
  background-size: 100%;
  border: 3px rgb(44, 30, 30) solid;
}
.beds:active {
  cursor: help;
}
</style>