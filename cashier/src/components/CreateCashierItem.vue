<template>
  <div class="container">  
      
      <h1>Lägg till produkt</h1>
      
      <div class="form">
        <!-- Item image -->
        <label for="img" class="imgLabel">
          <img src="@/assets/image-not-found.svg" alt="">
          <p>Klicka på bilden för ändra den</p>
        </label>
        <input type="file" id="img" accept="image/*" />


        <!-- Item name -->
        <input type="text" placeholder="Namn" v-model="cashierItem.name">

        <!-- Item price -->
        <input type="number" placeholder="Pris" v-model="cashierItem.price">

        <!-- Item stock -->
        <input type="number" placeholder="Antal" v-model="cashierItem.stock">

        <!-- Item description -->
        <textarea placeholder="Beskrivning" v-model="cashierItem.desc" maxlength="100" />

      </div>

      <button
      @click="createItem"
      >Spara</button>
  </div>
</template>

<script>
export default {
  computed: {
    itemImg() { return "'" + this.cashierItem.img + "'" }
  },

  data() {return {

    // The item to be added
    cashierItem : {

      // The name of the item
      name : "Jockes special",

      // The description of the item
      desc : "Dunderhonung",

      // The price of the item
      price : 1,

      // The current stock of the item
      stock: 1,

      // The image of the item
      img : "@/assets/image-not-found.svg"

    }
  }},

  methods: {

    // Creates a new item
    async createItem() {

      // Create the cashier item
      await this.$store.dispatch('addCashierItem', this.cashierItem)

      // Close the modal
      this.$store.commit('resetModal')

    }
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


}

</style>