<template>
  <div class="container overlayContainer">

      <!-- Go back -->
      <img 
      @click="$emit('goBack')"
      src="@/assets/arrow-circle-left-solid.svg" 
      alt="" 
      class="goBack" 
      />

      <!-- Info -->
      <p>Be kunden att scanna följande QR kod för att slutföra betalningen.</p>

      <!-- MOCK QR CODE -->
      <img :src="require('../assets/response.svg')" alt="qr" />

      <!-- Approve payment -->
      <button
      @click="confirmPayment"
      >
      Bekräfta
      </button>

  </div>
</template>

<script>
export default {

    props: {
        qrCode : String
    },

    methods: {
      confirmPayment() {

        this.$store.commit('resetOrder')
        this.$store.commit('resetModal')

      }
    }
}
</script>

<style lang="scss" scoped>

.container {
  justify-content: space-around;
  padding: 1rem;

  .goBack {
    height: 2rem;
    align-self: flex-start;
  }

  p {
    text-align: center;
  }
}

.overlayContainer {
  max-height: 50rem;
  max-width: 24rem;
}

</style>