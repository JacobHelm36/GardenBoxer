<template>
  <div class="col-6 col-md-3">
    <div
      class="card-back rounded d-flex justify-content-center flex-column align-items-center"
    >
      <garden class="mt-1" style="border-radius: 3%" :percent="95" :gardenData="gardenData" />
      <router-link class="text-dark" :to="'/garden/' + gardenData.id">view garden</router-link>
      <h4>{{gardenData.name}}</h4>
      <h4>{{gardenData.description}}</h4>
      <select
        id="gardenOptions"
        @change="onChange($event)"
        v-model="selected"
      >
        <option disabled value="">Options</option>
        <option value="edit">Edit</option>
        <option value="destroy">Delete</option>
      </select>
    </div>
  </div>
</template>

<script>
import Garden from "../components/garden";
// import Swal from 'sweetalert2'
export default {
  props: ["gardenData"],
  mounted() {},
  computed: {},
  components: {
    Garden
  },
  data() {
    return {
      selected: ''
    }
  },
  methods: {
    onChange(e) {
      let value = e.target.value;
      if (value == 'edit') {
        console.log("get a form here")
        // this.$store.dispatch("editGarden", this.gardenData.Id)
      }
      if (value == 'destroy') {
        Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
      }).then((result) => {
        if (result.value) {
          Swal.fire(
            'Deleted!',
            'Your file has been deleted.',
            'success',
            this.$store.dispatch("deleteGarden", this.gardenData.id)
          )     
        }
      })
      }
    }
  }
};
</script>

<style>
div.card-back {
  background-color: rgb(160, 237, 243);
}
</style>
