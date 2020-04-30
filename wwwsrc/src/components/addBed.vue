<template>
  <div class="beds" v-if="formActive">
    <div class="form">
      <input type='text' class="form-control-sm" v-model="newBed.name" placeholder="Enter a plant"></input>
      <input type='text' class="form-control-sm" v-model="newBed.description" placeholder="Enter a description"></input>
      <input type='number' class="form-control-sm" v-model="newBed.width" placeholder="Enter a width"></input>
      <input type='number' class="form-control-sm" v-model="newBed.height" placeholder="Enter a height"></input>
      <input type='text' class="form-control-sm" v-model="newBed.datePlanted" placeholder="Enter the date planted"></input>
      <input type='text' class="form-control-sm" v-model="newBed.dateFertilized" placeholder="Enter the date last fertilized"></input>
    </div>
      <button type="button" class="btn btn-primary" @click="createBed()">Submit</button>
      <button type="button" class="btn btn-primary" @click="this.formActive = false">Submit</button>
  </div>
</template>


<script>
export default {
  props:["coords", "formActive"],
  name: 'beds',
  methods: {
    createBed(){
      this.$store.dispatch("createBed", this.newBed)
    }
  },
  data(){
    return {
      newBed: {
        name: null,
        description: null,
        width: null,
        height: null,
        datePlanted: null,
        dateFertilized: null,
        bedX: this.coord.bedX,
        bedY: this.coords.bedY
      }
    }
  },
  computed:{
    
    }
}
</script>


<style scoped>

</style>