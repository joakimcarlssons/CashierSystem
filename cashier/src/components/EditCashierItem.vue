<template>
  <div class="container">

      <h3 class="close" @click="$store.commit('resetModal')">X</h3>
      
      <h1>Uppdatera produkt</h1>
      
      <div class="form">
        <!-- Item image -->
        <label for="img" class="imgLabel">
          <img src="@/assets/image-not-found.svg" alt="">
          <p>Klicka på bilden för ändra den</p>
        </label>
        <input type="file" id="img" accept="image/*" />


        <!-- Item name -->
        <input type="text" placeholder="Namn" v-model="itemToUpdate.name">

        <!-- Item price -->
        <input type="number" placeholder="Pris" v-model="itemToUpdate.price">

        <!-- Item stock -->
        <input type="number" placeholder="Antal" v-model="itemToUpdate.stock">

        <!-- Item description -->
        <textarea placeholder="Beskrivning" v-model="itemToUpdate.desc" maxlength="100" />

      </div>

      <button
      @click="updateItem"
      >Spara</button>
  </div>
</template>

<script>
export default {
  computed: {
    selectedItem() { return this.$store.state.cashier.selectedItem }
  },

  data() { return {
    itemToUpdate : {
      id : 0,
      name : "",
      price : 0,
      stock : 0,
      desc : ""
    }
  }},

  methods: {

    // Creates a new item
    async updateItem() {

      // Create the cashier item
      await this.$store.dispatch('updateCashierItem', this.itemToUpdate)

      // Close the modal
      this.$store.commit('resetModal')

    }
  },

  mounted() {
    Object.assign(this.itemToUpdate, this.selectedItem)
  }
}
</script>

<style lang="scss" scoped>

.container {
  background-color: var(--LightGrey);
  height: 100%;
  justify-content: space-around;
  
  h1 {
    align-self: center;
  }

  .form {
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;

    img {
      height: 8rem;
    }

    input {
      align-self: center;
      margin: 1.5rem 0;

      &[type=file] {
        display: none;
      }
    }

    label {
      &.imgLabel {
        display: flex;
        flex-direction: column;
        justify-content: center;
        margin-bottom: 2rem;
      }
    }

    textarea {
      margin: 1rem 0;
      width: 100%;
      min-height: 8rem;
      padding: .5rem;
      font-family: var(--Poppins);
      font-size: 1.2rem;
      resize: none;
    }
  }

.close {
  position: absolute;
  top: 1rem;
  right: 2rem;
}

}

</style>