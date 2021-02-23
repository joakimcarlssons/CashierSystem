<template>
  <div class="container">
      <button
      @click="createItem"
      >Spara</button>
  </div>
</template>

<script>
export default {
  methods: {
    async createItem() {

      // Create the cashier item
      await this.$store.dispatch('addCashierItem', { name : 'test', desc : 'test', price : 123 })

      // Close the modal
      this.$store.commit('resetModal')

    }
  }
}
</script>

<style lang="scss" scoped>

.container {
  height: auto;
}

</style>