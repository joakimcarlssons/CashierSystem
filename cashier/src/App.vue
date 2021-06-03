<template>
  <div id="app">
    <Nav />
    <router-view :style="activeModal.active ? 'filter: blur(2px)' : ''" />


    <!-- Overlays -->
    <div 
    class="overlay" 
    @click="closeOverlay" 
    v-if="activeModal.active">
      <div 
      class="content"
      :style="activeModal.allowOutsideClick ? '' : 'height: 100%; width: 100%'"
      @mouseenter="outsideContent = false"
      @mouseleave="activeModal.allowOutsideClick ? outsideContent = true : outsideContent = false"
      >
      
      <!-- The different modal components -->
      <CreateCashierItem 
      v-if="activeModal.name == 'createCashierItem'"
      />

      <ConfirmDeleteCashierItem
      v-if="activeModal.name == 'deleteCashierItem'"
      />

      <EditCashierItem
      v-if="activeModal.name == 'editCashierItem'"
      />

      <OrderCheckout
      v-if="activeModal.name == 'orderCheckout'" />

      <Help
      v-if="activeModal.name == 'help'" />

      <NavScreen
      v-if="activeModal.name == 'navScreen'" />

      </div>
    </div>

  </div>
</template>

<script>

//#region Component imports

import Nav from '@/components/NavBar'
import NavScreen from '@/components/NavScreen'
import CreateCashierItem from '@/components/CreateCashierItem'
import ConfirmDeleteCashierItem from '@/components/ConfirmDeleteCashierItem'
import EditCashierItem from '@/components/EditCashierItem'
import OrderCheckout from '@/components/OrderCheckout'
import Help from '@/components/Help'

//#endregion

export default {
  components : { Nav, NavScreen, CreateCashierItem, ConfirmDeleteCashierItem, EditCashierItem, OrderCheckout, Help },

  computed: {

    // Get the active modal/overlay
    activeModal() { return this.$store.state.modal }
  },

  watch: {
    activeModal: function() {

      // Reset the outside content flag everytime the overlay closes
      if (!this.activeModal.active) this.outsideContent = true
    }
  },

  data() { return {

    // Flag if the user clicks outside the active modal
    // and want to close...
    outsideContent : true
  }},

  methods: {
    closeOverlay() {

      // If the user clicks outside the modal...
      if(this.outsideContent) {

        // Close and reset the modal/overlay
        this.$store.commit('resetModal')
      }

    }
  }
}
</script>

<style lang="scss">

/* Style imports */
@import url('~@/styles/globals.scss');
@import url('~@/styles/buttons.scss');
@import url('~@/styles/texts.scss');
@import url('~@/styles/inputs.scss');
@import url('~@/styles/animations.scss');
@import url('~@/styles/overlays.scss');

#app {
  height: 100%;
  min-width: 280px;
  display: flex;
  flex-direction: column;
}

</style>
