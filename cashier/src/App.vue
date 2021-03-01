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
      </div>
    </div>

  </div>
</template>

<script>

//#region Component imports

import Nav from '@/components/NavBar'
import CreateCashierItem from '@/components/CreateCashierItem'
import ConfirmDeleteCashierItem from '@/components/ConfirmDeleteCashierItem'

//#endregion

export default {
  components : { Nav, CreateCashierItem, ConfirmDeleteCashierItem },

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
