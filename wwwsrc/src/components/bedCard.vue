<template>
  <div class="col-6 col-md-4 bed-card mb-1 mt-1" @click="setActive()">
    <img :src="bedData.img" class="img-fluid" alt />
    <h4>{{bedData.name}}</h4>
    <p>{{bedData.description}}</p>
    <button @click="save()" class="btn btn-sm btn-primary">Save</button>
  </div>
</template>
<script>
export default {
  props: ["bedData"],
  methods: {
    setActive() {
      if (this.active) {
        this.$store.dispatch("removeHover", this.bedData.id);
        return;
      }
      this.$store.dispatch("addHover", this.bedData.id);
    },
    save() {
      this.$store.dispatch("saveBed", this.bedData);
    },
    deleteSave() {
      this.$store.dispatch("removeSavedBed", this.bedData.id);
    }
  },
  computed: {
    active() {
      return this.$store.state.activeHover[this.bedData.id];
    }
  }
};
</script>
<style scoped>
img {
  left: 0px;
}
.bed-card:hover {
  cursor: pointer;
}
</style>