<template>
  <div class="beds bed-form">
    <div class="form">
      <input type='text' class="form-control-sm" v-model="newBed.name" placeholder="Enter a plant"></input>
      <input type='text' class="form-control-sm" v-model="newBed.description" placeholder="Enter a description"></input>
      <input type='number' class="form-control-sm" v-model="newBed.width" placeholder="Enter a width"></input>
      <input type='number' class="form-control-sm" v-model="newBed.height" placeholder="Enter a height"></input>
      <input type='text' class="form-control-sm" v-model="newBed.image" placeholder="Enter an image"></input>
      <input type='text' class="form-control-sm" v-model="newBed.datePlanted" placeholder="Enter the date planted"></input>
      <input type='text' class="form-control-sm" v-model="newBed.dateFertilized" placeholder="Enter the date last fertilized"></input>
    </div>
      <button type="button" class="btn btn-primary" @click="createBed()">Submit</button>
  </div>
</template>


<script>
export default {
  props:["coords"],
  methods: {
    createBed(){
      this.$store.dispatch("createBed", this.newBed)
    }
  },
  data(){
    return {
      newBed: {
        name: "",
        description: "",
        width: 1,
        height: 1,
        img: "",
        datePlanted: "",
        dateFertilized: "",
        bedX: this.coords.bedX,
        bedY: this.coords.bedY,
        gardenId: parseInt(this.$route.params.id)
      },
    }
  },
  computed:{
    
    }
}
</script>


<style scoped>

</style>