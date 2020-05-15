<template>
  <div class="dashboard container">
    <div class="row d-flex justify-content-center">
      <div class="form-input col-12">
        <label>Height:</label>
        <input
          type="number"
          class="form-control-sm"
          max="100"
          v-model="newGarden.height"
          placeholder="Enter a height"
        />
        <label>Width:</label>
        <input
          type="number"
          class="form-control-sm"
          max="100"
          v-model="newGarden.width"
          placeholder="Enter a width"
        />
        <input
          type="text"
          class="form-control-sm"
          max="100"
          v-model="newGarden.name"
          placeholder="Name"
        />
        <input
          type="text"
          class="form-control-sm"
          max="100"
          v-model="newGarden.description"
          placeholder="Description"
        />
        <button @click="createGarden()" class="btn btn-success">Submit</button>
        <select name="colors" id="colors" v-model="newGarden.background">
          <option value="rgb(239, 248, 182)">faded yellow</option>
          <option value="rgb(223, 241, 59)">pea green</option>
          <option value="rgb(166, 226, 25)">lettuce leaf</option>
          <option value="rgb(77, 209, 16)">true green</option>
          <option value="rgb(2, 139, 32)">algae dream</option>
          <option value="rgb(64, 120, 194)">silky night</option>
          <option value="rgb(95, 85, 190)">soothing purple</option>
          <option value="rgb(187, 3, 3)">red</option>
        </select>
        
      </div>
      <div
        @click.prevent="click($event)"
        class="col-12 box p-0 mt-5 mb-5"
        v-bind:style="{ 'min-width': plotDimensions.plotWidth, 'max-width': plotDimensions.plotWidth, 'min-height': plotDimensions.plotHeight, 'max-height': plotDimensions.plotHeight, backgroundColor: newGarden.background}"
      ></div>
    </div>
  </div>
</template>

<script>
export default {
  name: "create",
  mounted() {},
  methods: {
    click(e) {
      return e.offsetX;
    },
    async createGarden() {
      this.newGarden.width = Number(this.newGarden.width);
      this.newGarden.height = Number(this.newGarden.height);
      await this.$store.dispatch("createGarden", this.newGarden);
      this.$router.push(`garden/${this.$store.state.activeGarden.id}`);
    }
  },
  computed: {
    plotDimensions() {
      if (this.newGarden.height > 1000000) {
        this.newGarden.height = 1000000;
      }
      if (this.newGarden.width > 1000000) {
        this.newGarden.width = 1000000;
      }
      let ratio = this.newGarden.height / this.newGarden.width;
      if (ratio > 1) {
        return {
          plotWidth: (this.newGarden.width / this.newGarden.height) * 80 + "vw",
          plotHeight: "80vw"
        };
      }
      return {
        plotHeight: ratio * 80 + "vw",
        plotWidth: "80vw"
      };
    }
  },
  components: {},
  data() {
    return {
      newGarden: {
        width: null,
        height: null,
        name: null,
        description: null,
        background: null
      }
    };
  }
};
</script>

<style scoped>
.box {
  min-width: 80vw;
  max-width: 80vw;
  /* background-color: null; */
  border: 1px solid rgb(0, 0, 0);
}

input[type="color"] {
  width: 25px;
}
</style>
