<template>
  <div class="container overlayContainer">

      <h2>Är du säker på att du vill ta bort {{selectedItem.name}}?</h2>

      <div class="btns">

          <img src="@/assets/check-circle-solid.svg" alt="check"
          @click="removeItem"
          >
          <img src="@/assets/times-circle-solid.svg" alt="abort"
          @click="$store.commit('resetModal')"
          >
 
      </div>

  </div>
</template>

<script>
export default {
    computed: {
        selectedItem() { return this.$store.state.cashier.selectedItem }
    },

    methods: {

        // Remove an item from the cashier
        async removeItem() {

            // Remove the item
            await this.$store.dispatch('removeCashierItem', this.selectedItem)
            
            // Close the modal
            this.$store.commit('resetModal')
        }
    }
}
</script>

<style lang="scss" scoped>

.overlayContainer {
    text-align: center;
    justify-content: center;
}

.container {
    padding: 0 3rem;

    h2 {
        color: black;
    }

    .btns {
        display: flex;
        width: 100%;
        margin-top: 1rem;
        justify-content: center;

        img {
            height: 3rem;
            margin: 1rem;

            &:hover {
                opacity: .7;
            }
        }
    }
}

</style>