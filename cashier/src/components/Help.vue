<template>
  <div class="container overlayContainer">

      <!-- Start -->
      <div class="helpText" v-if="currentRoute == '/'">
        <HelpStart />
      </div>

      <!-- Cashier -->
      <div class="helpText" v-if="currentRoute == '/cashier'">
        <HelpCashier />
      </div>
  </div>

</template>

<script>
import HelpStart from '@/components/HelpStart'
import HelpCashier from '@/components/HelpCashier'

export default {
    components : { HelpStart, HelpCashier },
    computed: {
        currentRoute() { return this.$route.fullPath }
    }
}
</script>

<style lang="scss" scoped>

.container {
  justify-content: space-around;
  min-width: 20rem;
  padding: 6rem 2rem;

    .overlayContainer {
    min-height: 50rem;
    min-width: 24rem;
    }
}

</style>