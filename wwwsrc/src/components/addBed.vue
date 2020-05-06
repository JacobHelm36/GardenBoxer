<template class="container">
  <div class="bed-form row">
    <div class="form col-12">
      <input type='text' class="form-control-sm" v-model="newBed.name" placeholder="Enter a plant"></input>
      <input type='text' class="form-control-sm" v-model="newBed.description" placeholder="Enter a description"></input>
      <input type='number' class="form-control-sm" v-model="newBed.width" placeholder="Enter a width"></input>
      <input type='number' class="form-control-sm" v-model="newBed.height" placeholder="Enter a height"></input>
      <input type='text' class="form-control-sm" v-model="newBed.img" placeholder="Enter an image"></input>
      <input type='text' class="form-control-sm" v-model="newBed.datePlanted" placeholder="Enter the date planted"></input>
      <input type='text' class="form-control-sm" v-model="newBed.dateFertilized" placeholder="Enter the date last fertilized"></input>
    </div>
      <date-picker v-model="date" lang="en" type="date" format="YYYY-MM-dd"></date-picker>
      <button type="button" class="btn btn-primary" @click="createBed()">Submit</button>
  </div>
</template>


<script>
import DatePicker from "vue2-datepicker"
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
      date: '',
    }
  },
  computed:{},
  components: {DatePicker}
}
</script>


<style scoped>
.example {
  background: #f2f2f2;
  border: 1px solid #ddd;
  padding: 0em 1em 1em;
  margin-bottom: 2em;
}
</style>