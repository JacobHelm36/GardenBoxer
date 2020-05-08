<template class="container">
  <form class="bed-form row">
    <div class="col-12">
      <input type='text' class="form-control-sm" v-model="newBed.name" placeholder="Enter a plant">
      <input type='text' class="form-control-sm" v-model="newBed.description" placeholder="Enter a description">
      <input type='number' class="form-control-sm" v-model.number="newBed.width" placeholder="Enter a width">
      <input type='number' class="form-control-sm" v-model.number="newBed.height" placeholder="Enter a height">
      <input type='text' class="form-control-sm" v-model="newBed.img" placeholder="Enter an image">
      <date-picker class="form-control-sm" v-bind:style="{'max-width': '50px' }" v-model="newBed.datePlanted" lang="en" type="date" format="YYYY-MM-dd" placeholder="Enter date planted"></date-picker>
      <date-picker class="form-control-sm" v-bind:style="{'max-width': '50px' }" v-model="newBed.dateFertilized" lang="en" type="date" format="YYYY-MM-dd" placeholder="Enter date fertilized"></date-picker>
    </div>
      <button type="button" class="btn btn-primary" @click="createBed()">Submit</button>
  </form>
</template>


<script>
import DatePicker from "vue2-datepicker"
export default {
  props:["coords"],
  methods: {
    createBed(){
      debugger
      console.log(this.newBed)
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
      }
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
.calendar-icon {
  background-image: url(https://img.favpng.com/21/24/23/computer-icons-google-calendar-icon-design-time-png-favpng-HpYLV7p1Cbkr1MbJ6wXWFWd8M.jpg);
  background-position: 50%;
  background-repeat: no-repeat;
}
.bed-form {
  max-width: 100px;
  min-width: 100px;
  max-height: 600px;
}
</style>