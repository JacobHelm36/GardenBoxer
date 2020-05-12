<template>
  <div :style="{'top':top + 'px', 'left': left+'px','max-width': Interval.Winterval + 'px', 'min-width': Interval.Winterval + 'px', 'max-height':Interval.Hinterval + 'px', 'min-height':Interval.Hinterval + 'px'}" @click="info()" class="beds" id="beds" draggable="true"
      @mousedown="clickIt($event)"
      @mouseup="drop($event)"
      @drag="dragIt($event)" 
      @dragend="drop($event)">
    <div class>
      <img
      draggable="false" class="img-fluid" :src="bedData.img" />
      
    </div>
    <div :style="{'top':(bedData.bedY + 1) * HInterval, 'left': (bedData.bedX + 1) * WInterval}" v-if="info" class="popup">
      <p>{{bedData.name}}</p>
      <button @click="bedEditForm = !bedEditForm" class="btn btn-primary">Edit</button>
    </div>
    <div class="edit-bed-form" :style="{'top':100 + 'px', 'left': 100 + 'px'}" v-if="bedEditForm">
      <div class="form">
        <input type='text' class="form-control-sm" v-model="editedBed.name" placeholder="Enter a plant">
        <input type='number' class="form-control-sm" v-model="editedBed.width" placeholder="Enter a width">
        <input type='number' class="form-control-sm" v-model="editedBed.height" placeholder="Enter a height">
        <input type='text' class="form-control-sm" v-model="editedBed.img" placeholder="Enter an image">
        <date-picker class="form-control-sm" v-bind:style="{'max-width': '0px' }" v-model="editedBed.datePlanted" lang="en" type="date" format="YYYY-MM-dd" placeholder="Enter date planted"></date-picker>
        <date-picker class="form-control-sm" v-bind:style="{'max-width': '0px' }" v-model="editedBed.dateFertilized" lang="en" type="date" format="YYYY-MM-dd" placeholder="Enter date fertilized"></date-picker>
        <div class="flex">
          <button type="button" class="btn btn-primary" @click="updateBed()">Save Changes</button>
          <button type="button" class="btn btn-danger" @click="cancelEditBed()">Cancel</button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import DatePicker from "vue2-datepicker"
export default {
  props: ["bedData", "clicker","gardenDim"],
  mounted(){
    this.HInterval = document.getElementById("garden").offsetHeight / this.gardenDim.height;
    this.WInterval = document.getElementById("garden").offsetWidth / this.gardenDim.width;
    this.left = this.bedData.bedX * this.WInterval;
    this.top = this.bedData.bedY * this.HInterval;
  },
  methods: {
    bedForm(e){
      this.bedEditForm = !this.bedEditForm;
    },
    info(){
      this.info = !this.info
    },
    updateBed() {
      console.log(this.bedData)
      console.log(this.editedBed)
      this.$store.dispatch("editBed", this.editedBed);
    },
    cancelEditBed() {
      this.bedEditForm = false;
    },
    clickIt(e) {
      this.drag = true;
      this.offset.x = e.clientX - this.left
      this.offset.y = e.clientY - this.top
      this.initX = e.clientX;
      this.initY = e.clientY;
    },
    drop(e) {
      if(e.clientY - this.initY < 1 && e.clientY - this.initY > -1 && e.clientX - this.initX < 1 && e.clientX - this.initX > -1){
        this.info = !this.info;
        this.drag = false;
        return;
      }
      this.bedData.bedY = Math.floor((this.top + e.offsetY) / this.HInterval);
      this.bedData.bedX = Math.floor((this.left + e.offsetX) / this.WInterval);
      if(this.bedData.bedY >= this.gardenDim.height){
        this.bedData.bedY = this.gardenDim.height - 1;
      }
      if(this.bedData.bedY >= this.gardenDim.width){
        this.bedData.bedY = this.gardenDim.height - 1;
      }
      if(this.bedData.bedX < 0){
        this.bedData.bedX = 0;
      }
      if(this.bedData.bedY < 0){
        this.bedData.bedY = 0;
      }
      this.top = (this.bedData.bedY * this.HInterval);
      this.left = (this.bedData.bedX * this.WInterval);
      this.drag = false;
      this.$store.dispatch("editBed", {id: this.bedData.id, bedX:this.bedData.bedX, bedY:this.bedData.bedY});
    },
    dragIt(e) {
      if (this.drag) {
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
        datePlanted: this.bedData.datePlanted || this.$state.beds == this.bedData.id,
        dateFertilized: this.bedData.dateFertilized,
        bedX: this.bedData.bedX,
        bedY: this.bedData.bedY,
        gardenId: this.bedData.gardenId,
        id: this.bedData.id
        },
      info: false,
      HInterval:0,
      WInterval:0,
      bedEditForm: false,
      drag: false,
      top: 0,
      left: 0,
      offset: {
        x: 0,
        y: 0
      },
      initX:0,
      initY:0
    };
  },
  computed: {
    bedInfo() {
      console.log(this.bedData);
      return this.bedData;
    },
    Interval() {
      return { Hinterval: this.HInterval, Winterval: this.WInterval };
    }
  },
  components: {DatePicker}
};
</script>


<style scoped>
.flex {
  display: flex;
}
.popup {
  position:absolute;
}
.edit-bed-form{
  position:absolute;
}
img{
  max-width:100%;
}
.beds{
  background-color:brown;
}
.beds:active{
  cursor:help;
}
</style>