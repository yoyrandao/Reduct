<template>
  <div id="app">
    <reduct-form @getShortcut="getShortcut" />
    <p v-if="loading">Loading...</p>
    <br />
    <a target="blank" :href="result" v-if="result">{{ result }}</a>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import axios from "axios";

import ReductForm from "@/components/ReductForm.vue";

import { Response } from "@/components/Response";

export default Vue.extend({
  name: "App",
  data: () => ({
    result: "",
    loading: false
  }),
  components: {
    ReductForm
  },
  methods: {
    getShortcut(url: string) {
      this.loading = true;
      axios
        .post<Response>(
          `http://${window.location.hostname}:5000/register`,
          { url: url },
          {
            onDownloadProgress: () => (this.loading = false),
            responseType: "json"
          }
        )
        .then(response => {
          this.result = response.data.value.toString();
        });
    }
  }
});
</script>

<style lang="less">
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  display: flex;
  justify-content: center;
  flex-flow: column;
  margin-top: 20%;
}

body {
  background-color: #add8e6;
}
</style>
