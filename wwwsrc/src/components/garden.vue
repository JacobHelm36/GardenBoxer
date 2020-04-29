<template>
    <div class="row d-flex justify-content-center">
      <div @click.prevent="click($event)" class="col-12 box p-0 mt-5 mb-5" v-bind:style="{ 'min-width': plotDimensions.plotWidth, 'max-width': plotDimensions.plotWidth, 'min-height': plotDimensions.plotHeight, 'max-height': plotDimensions.plotHeight}" >
      </div>
    </div>
</template>

<script>
export default {
  name:"create",
  props:["gardenData"],
  mounted() {
  },
  methods:{
    click(e){
      console.log(e);
      console.log(e.offsetY);
      console.log(e.offsetX);
      return e.offsetX;
    }
  },
  computed: {
    plotDimensions(){
      let ratio = this.gardenData.height / this.gardenData.width;
      if(ratio > 1.2){
        return {
          plotWidth: ((this.gardenData.width / this.gardenData.height) * 80) + "%",
          plotHeight: "80%"
        }
      }
      return {
        plotHeight: (ratio * 80) + "%",
        plotWidth: "80%"
      }
    }
  },
  components: {
  },
  data() {
    return {
    };
  }
};
</script>

<style>
.box{
  min-width:80%;
  max-width:80%;
  background-color: rgb(42, 165, 73);
  border: 1px solid black;
}

</style>
