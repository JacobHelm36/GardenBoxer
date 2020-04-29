<template>
  <div class="dashboard container">
    
    <div class="row d-flex justify-content-center">
      <div class="form-input col-12">
        <label>Height:</label>
        <input type="number" class="form-control-sm" v-model="newGarden.height" placeholder="Enter a height"></input>
        <label>Width:</label>
        <input type="number" class="form-control-sm" v-model="newGarden.width" placeholder="Enter a width"></input>
        <input type="text" class="form-control-sm" max="100" v-model="newGarden.name" placeholder="Name"></input>
        <input type="text" class="form-control-sm" max="100" v-model="newGarden.description" placeholder="Description"></input>
        <button @click="createGarden()" class="btn btn-primary">Submit</button>
      </div>
      <div @click.prevent="click($event)" class="col-12 box p-0 mt-5 mb-5" v-bind:style="{ 'min-width': plotDimensions.plotWidth, 'max-width': plotDimensions.plotWidth, 'min-height': plotDimensions.plotHeight, 'max-height': plotDimensions.plotHeight}" >
      </div>
      <button @click="asdf()">asdf</button>
    </div>
  </div>
</template>

<script>
export default {
  name:"create",
  mounted() {
  },
  methods:{
    click(e){
      console.log(e);
      console.log(e.offsetY);
      console.log(e.offsetX);
      return e.offsetX;
    },
    asdf(){
      console.log(this.$router);
    },
    async createGarden(){
      this.newGarden.width = Number(this.newGarden.width);
      this.newGarden.height = Number(this.newGarden.height);
      await this.$store.dispatch("createGarden", this.newGarden);
    }
  },
  computed: {
    plotDimensions(){
      if(this.newGarden.height > 1000000){
        this.newGarden.height = 1000000
      }
      if(this.newGarden.width > 1000000){
        this.newGarden.width = 1000000
      }
      let ratio = this.newGarden.height / this.newGarden.width;
      if(ratio > 1.2){
        return {
          plotWidth: ((this.newGarden.width / this.newGarden.height) * 80) + "vw",
          plotHeight: "80vw"
        }
      }
      return {
        plotHeight: (ratio * 80) + "vw",
        plotWidth: "80vw"
      }
    }
  },
  components: {
  },
  data() {
    return {
      newGarden:{
        width: 0,
        height: 0,
        name: null,
        description:null
      }
    };
  }
};
</script>

<style>
.box{
  min-width:80vw;
  max-width:80vw;
  background-color: rgb(42, 165, 73);
  border: 1px solid black;
}

</style>
