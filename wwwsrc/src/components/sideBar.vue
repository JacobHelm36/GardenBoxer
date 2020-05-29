<template>
  <div class="side-wrapper">
    <button @click="toggleIt" class="btn btn-primary side-toggle">TOGGLE</button>
    <div class="side-bar d-flex flex-column" v-bind:style="{'left': left + '%'}">
      <button @click="toggleIt" class="btn btn-secondary align-self-end">Toogle</button>
      <div class="d-flex flex-row justify-content-around mt-2 mb-2">
        <button @click="active = 'group'" class="btn btn-warning btn-sm">groups</button>
        <button @click="active = 'bed'" class="btn btn-warning btn-sm">beds</button>
        <button @click="active = 'save'" class="btn btn-warning btn-sm">saves</button>
      </div>
      <div v-if="active == 'bed'" class="row beds-spot">
        <bed v-for="bed in beds" :template="false" :key="bed.id" :bedData="bed" />
      </div>
      <div v-if="active == 'group'" class="row groups-spot">
        <div class="col-12">
          <button @click="form = !form" class="btn btn-primary btn-sm">+</button>
        </div>
        <div v-if="form" class="col-12 d-flex justify-content-center">
          <input class="form-control-sm" type="text" v-model="groupName" />
          <button @click="createGroup()" class="btn btn-primary btn-sm">Submit</button>
        </div>
        <div class="col-6 col-md-4" v-for="group in groups" :key="group.id">
          <p>{{group.name}}</p>
          <button @click="groupEdit = !groupEdit" class="btn btn-primary btn-sm">Edit</button>
        </div>
      </div>
      <div v-if="active == 'save'" class="row saves-spot">
        <bed v-for="template in templates" :bedData="template" :template="true" :key="template.id" />
      </div>
      <div v-if="active == 'group' && groupEdit">
        <div class="form">
          <input
            type="text"
            class="form-control-sm"
            v-model="editedBed.name"
            placeholder="Enter a plant"
          />
          <input
            type="number"
            class="form-control-sm"
            v-model.number="editedBed.width"
            placeholder="Enter a width"
          />
          <input
            type="number"
            class="form-control-sm"
            v-model.number="editedBed.height"
            placeholder="Enter a height"
          />
          <input
            type="text"
            class="form-control-sm"
            v-model="editedBed.img"
            placeholder="Enter an image"
          />
          <date-picker
            class="form-control-sm"
            v-bind:style="{'max-width': '0px' }"
            v-model="editedBed.datePlanted"
            lang="en"
            type="date"
            format="YYYY-MM-dd"
            placeholder="Change date planted"
          ></date-picker>
          <date-picker
            class="form-control-sm"
            v-bind:style="{'max-width': '0px' }"
            v-model="editedBed.dateFertilized"
            lang="en"
            type="date"
            format="YYYY-MM-dd"
            placeholder="Change date fertilized"
          ></date-picker>
          <div class="flex">
            <button type="button" class="btn btn-success" @click="updateBeds()">Save Changes</button>
            <button type="button" class="btn btn-danger" @click="groupEdit = !groupEdit">Cancel</button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import Bed from "../components/bedCard";
import DatePicker from "vue2-datepicker";
export default {
  name: "Sidebar",
  mounted() {
    // setTimeout(this.pollHeight, 1000);
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
    async createGroup() {
      await this.$store.dispatch("createGroup", this.groupName);
      this.form = false;
      this.groupName = "";
    },
    updateBeds() {
      this.$store.dispatch("", this.editedBed);
    }
  },
  data() {
    return {
      left: -100,
      toggle: true,
      toggleInterval: null,
      active: "bed",
      form: false,
      groupName: "",
      groupEdit: false,
      editedBed: {}
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
    Bed,
    DatePicker
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
  background-color: rgb(192, 248, 245);
  z-index: 1;
  max-width: 100%;
  overflow: hidden;
  border-top: 2px solid rgb(185, 140, 73);
  border-right: 2px solid rgb(185, 140, 73);
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
.form {
  z-index: 1;
}
.mx-datepicker-main {
  z-index: 1;
}
</style>
