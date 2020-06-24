<template>
  <div>
    <form class="reduct-main__form" @submit="validate">
      <input
        class="reduct-main__form__input"
        type="url"
        v-model="url"
        @input="validate"
      />
      <button class="reduct-main__form__button" @click="requestForShortcut">
        Submit
      </button>
      <p class="reduct-main__form__error" v-if="!valid">
        Error. Link not valid
      </p>
    </form>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
export default Vue.extend({
  data: () => ({
    url: "",
    valid: false
  }),
  methods: {
    validate() {
      const regex = new RegExp(
        /https?:\/\/(www\.)?[-a-zA-Z0-9@:%._+~#=]{1,256}\.[a-zA-Z0-9()]{1,6}\b([-a-zA-Z0-9()!@:%_+.~#?&//=]*)/
      );

      this.valid = regex.test(this.url);
      return this.valid;
    },
    requestForShortcut() {
      if (this.valid) this.$emit("getShortcut", this.url);
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
}

.reduct-main__form__input {
  width: 20em;
  height: 2em;

  font-size: 18px;

  margin-top: 4%;
}

.reduct-main__form__button {
  margin-left: 1em;

  width: 5em;
  height: 3em;

  background-color: #00bfff;
}

.reduct-main__form__error {
  font-size: 18px;
  font-family: "Segoe UI", Tahoma, Geneva, Verdana, sans-serif;
  font-weight: bold;
}
</style>
