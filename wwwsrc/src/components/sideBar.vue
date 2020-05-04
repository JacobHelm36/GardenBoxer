<template>
  <div v-bind:style="{}" class="side-wrapper">
    <button @click="toggleIt" class="btn btn-primary side-toggle">WEEBU</button>
    <div v-bind:style="{'left': left + '%'}" class="side-bar">
      <button class="btn btn-warning">content</button>
      <p>stuff</p>
    </div>
  </div>
</template>

<script>
export default {
  name: "Sidebar",
  methods: {
    toggleIt(){
      if(!this.toggleInterval){
        if(this.toggle){
          this.toggleInterval = setInterval(this.out, 5);
          return;
        }
        this.toggleInterval = setInterval(this.in, 5);
      }
    },
    in(){
      if(this.left > -100){
          this.left--;
          return;
        }
        clearInterval(this.toggleInterval);
        this.toggleInterval = 0;
        this.toggle = !this.toggle
    },
    out(){
      if(this.left < 0){
          this.left++;
          return;
        }
        clearInterval(this.toggleInterval);
        this.toggleInterval = 0;
        this.toggle = !this.toggle
    }
  },
  data(){
    return {
      left:-100,
      toggle:false,
      toggleInterval: null
    }
  },
  computed:{
  }
};
</script>

<style>
.side-wrapper{
  overflow:hidden;
  position:absolute;
  left:0px;
  height:100vh;
  min-width:25%;
}
.side-bar{
  height:100vh;
  position:absolute;
}
</style>
