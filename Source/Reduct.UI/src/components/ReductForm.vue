<template>
  <div>
    <form class="reduct-main__form" @submit="validate">
      <p>Enter your URL to short it</p>
      <input
        class="reduct-main__form__input"
        type="url"
        v-model="url"
        @input="validate"
      />
      <button class="reduct-main__form__button" @click="requestForShortcut">
        Submit
      </button>
    </form>
    <p class="reduct-main__form__error" v-if="isError">
      Error. Link is not valid
    </p>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
export default Vue.extend({
  data: () => ({
    url: "",
    valid: false,
    first: true
  }),
  methods: {
    validate() {
      this.first = false;

      const regex = new RegExp(
        /https?:\/\/(www\.)?[-a-zA-Z0-9@:%._+~#=]{1,256}\.[a-zA-Z0-9()]{1,6}\b([-a-zA-Z0-9()!@:%_+.~#?&//=]*)/
      );

      this.valid = regex.test(this.url);
      return this.valid;
    },
    requestForShortcut(e: Event) {
      e.preventDefault();
      if (this.valid) this.$emit("getShortcut", this.url);
    }
  },
  computed: {
    isError() {
      return !this.valid && !this.first;
    }
  }
});
</script>

<style lang="less" scoped>
.reduct-main__form {
  background-color: #87ceeb;
  width: 50%;
  height: 8em;
  margin: auto;
  border: 1px solid black;
  border-radius: 10px;

  overflow: hidden;
}

.reduct-main__form__input {
  width: 50%;
  height: 2em;

  font-size: 18px;

  text-align: center;
}

.reduct-main__form__button {
  margin-left: 1em;

  width: 5em;
  height: 3em;

  color: black;
  border: 1px solid black;

  border-radius: 10px;

  background-color: #00bfff;
}

.reduct-main__form__error {
  font-size: 18px;
  font-family: "Segoe UI", Tahoma, Geneva, Verdana, sans-serif;
  font-weight: bold;
}

p {
  font-size: 18px;
  font-family: "Segoe UI", Tahoma, Geneva, Verdana, sans-serif;
}
</style>
