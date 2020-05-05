<template>
  <div @click="bedForm($event)" class="beds" id="beds">
    <div class>
      <img  class="img-fluid" :src="bedData.img" />
    </div>
    <div v-show="info" class="popup">
      <p>{{bedData.name}}</p>
    </div>
    <div class="edit-bed-form" v-if="bedEditForm">
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
  props: ["bedData", "clicker"],
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
      bedEditForm: false
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
</style>