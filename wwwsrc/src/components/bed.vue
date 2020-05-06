<template>
  <div  :style="{'top':top + 'px', 'left': left+'px','max-width': Interval.Winterval + 'px', 'max-height':Interval.Hinterval + 'px'}" @click="bedForm($event)" class="beds" id="beds">
    <div class>
      <img
      @mousedown="clickIt($event)"
      @mouseup="drop($event)"
      @mousemove="dragIt($event)" draggable="false" class="img-fluid" :src="bedData.img" />
    </div>
    <div :style="{'top':(bedData.bedY + 1) * HInterval, 'left': (bedData.bedX + 1) * WInterval}" v-if="info" class="popup">
      <p>{{bedData.name}}</p>
      <button @click="bedEditForm = !bedEditForm" class="btn btn-primary">Edit</button>
    </div>
    <div class="edit-bed-form" :style="{'top':100 + 'px', 'left': 100 + 'px'}" v-if="bedEditForm">
      <div class="form">
        <input type='text' class="form-control-sm" v-model="editedBed.name" placeholder="Enter a plant"></input>
        <input type='text' class="form-control-sm" v-model="editedBed.description" placeholder="Enter a description"></input>
        <input type='number' class="form-control-sm" v-model="editedBed.width" placeholder="Enter a width"></input>
        <input type='number' class="form-control-sm" v-model="editedBed.height" placeholder="Enter a height"></input>
        <input type='text' class="form-control-sm" v-model="editedBed.img" placeholder="Enter an image"></input>
        <input type='text' class="form-control-sm" :placeholder="bedData.datePlanted"></input>
        <input type='text' class="form-control-sm" v-model="editedBed.dateFertilized" placeholder="Enter the date last fertilized"></input>
        <div class="flex">
          <button type="button" class="btn btn-primary" @click="updateBed()">Save Changes</button>
          <button type="button" class="btn btn-danger" @click="cancelEditBed()">Cancel</button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
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
      if (e.toElement.id == "beds") {
        this.bedEditForm = !this.bedEditForm;
      }
    },
    updateBed() {
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
        description: this.bedData.description,
        width: this.bedData.width,
        height: this.bedData.height,
        img: this.bedData.image,
        datePlanted: this.bedData.datePlanted,
        dateFertilized: this.bedData.dateFertilized,
        bedX: this.bedData.bedX,
        bedY: this.bedData.bedY,
        gardenId: this.bedData.gardenId
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
      return { Hinterval: this.HIterval, Winterval: this.WInterval };
    }
  }
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
</style>