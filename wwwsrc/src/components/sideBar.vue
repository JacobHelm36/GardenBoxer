<template>
  <div v-bind:style="{height:this.offsetHeight + 'px'}" class="side-wrapper">
    <button @click="toggleIt" class="btn btn-primary side-toggle">TOGGLE</button>
    <div class="side-bar d-flex flex-column" v-bind:style="{'left': left + '%'}">
      <button @click="toggleIt" class="btn btn-secondary align-self-end">Toogle</button>
      <div class="d-flex flex-row justify-content-around mt-2 mb-2">
        <button @click="active = 'group'" class="btn btn-warning btn-sm">groups</button>
        <button @click="active = 'bed'" class="btn btn-warning btn-sm">beds</button>
        <button @click="active = 'save'" class="btn btn-warning btn-sm">saves</button>
      </div>
      <div v-if="active == 'bed'" class="row beds-spot">
        <bed v-for="bed in beds" :key="bed.id" :bedData="bed" />
      </div>
      <div v-if="active == 'group'" class="row groups-spot">
        <button @click="form = !form" class="btn btn-primary btn-sm">+</button>
        <div v-if="form">
          <input class="form-control-sm" type="text" v-model="groupName" />
          <button @click="createGroup()" class="btn btn-primary btn-sm">Submit</button>
        </div>
        <div>
          <div v-for="group in groups" :key="group.id">
            <p>{{group.name}}</p>
          </div>
        </div>
      </div>
      <div v-if="active == 'save'" class="row saves-spot">
        <bed v-for="template in templates" :bedData="template" :key="template.id" />
      </div>
    </div>
  </div>
</template>

<script>
import Bed from "../components/bedCard";
export default {
  name: "Sidebar",
  mounted() {
    setTimeout(this.pollHeight, 1000);
  },
  methods: {
    toggleIt() {
      if (!this.toggleInterval) {
        if (this.toggle) {
          this.toggleInterval = setInterval(this.out, 5);
          return;
        }
        this.toggleInterval = setInterval(this.in, 5);
      }
    },
    in() {
      if (this.left > -100) {
        this.left--;
        return;
      }
      clearInterval(this.toggleInterval);
      this.toggleInterval = 0;
      this.toggle = !this.toggle;
    },
    out() {
      if (this.left < 0) {
        this.left++;
        return;
      }
      clearInterval(this.toggleInterval);
      this.toggleInterval = 0;
      this.toggle = !this.toggle;
    },
    pollHeight() {
      this.offsetHeight = document.getElementById("garden-view").offsetHeight;
    },
    async createGroup() {
      await this.$store.dispatch("createGroup", this.groupName);
      this.form = false;
    }
  },
  data() {
    return {
      left: -100,
      toggle: true,
      toggleInterval: null,
      active: "bed",
      form: false,
      groupName: ""
    };
  },
  computed: {
    beds() {
      return this.$store.state.beds;
    },
    templates() {
      return this.$store.state.templateBeds;
    },
    groups() {
      return this.$store.state.groups;
    }
  },
  components: {
    Bed
  }
};
</script>

<style>
.side-wrapper {
  overflow: hidden;
  position: absolute;
  left: 0px;
  min-width: 25%;
  height: 100%;
}
.side-bar {
  top: 0px;
  height: 100%;
  position: absolute;
  min-width: 100%;
  background-color: blue;
  z-index: 1;
  max-width: 100%;
  overflow: hidden;
}
.beds-spot {
  max-width: 100%;
  margin-left: 0px;
}
.groups-spot {
  max-width: 100%;
  margin-left: 0px;
}
.saves-spot {
  max-width: 100%;
  margin-left: 0px;
}
</style>
