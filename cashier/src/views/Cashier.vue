<template>
  <div class="container" @click="canExitEditMode ? editModeActive = false : ''">

      <div class="info">
        <input type="text" class="cashierName" placeholder="Ditt kassanamn" v-model="cashier.name">

        <p v-if="cashier.cashierItems.length == 0">
            Klicka på plusset för att lägga till din första produkt
        </p>

      </div>

      <ul class="cashierItems" @mouseover="canExitEditMode = false" @mouseleave="canExitEditMode = true">

          <li 
          v-for="item in cashier.cashierItems"
          :key="item.id"
          @mousedown="startClick"
          @mouseup="endClick(item)"
          @touchstart="startTimer"
          @touchend="endTimer"
          :class="{shake : editModeActive}"
          >
            <CashierItem :cashierItem="item" :editable="editModeActive"
            />
          </li>

          <li
          class="createItem"
          @click="$store.commit('changeModal', 
            { name : 'createCashierItem', allowOutsideClick : false, active : true })"
          >
              <EmptyCashierItem
              />
          </li>          
      </ul>
      
  </div>
</template>

<script>
import CashierItem from '@/components/CashierItem'
import EmptyCashierItem from '@/components/EmptyCashierItem'

export default {

    data() { return {
        editModeActive : false,
        canOpenEditModal : false,
        canExitEditMode : false,
        editTimer : null
    }},

    components : { CashierItem, EmptyCashierItem },

    computed: {
        
        // The current cashier
        cashier() { return this.$store.state.cashier.currentCashier }
    },

    methods: {

        // Starts a timer to check whether the user is holding the item to edit it or not
        startClick() {

            // If the edit mode is active, activate possibility to open edit modal
            if (this.editModeActive) this.canOpenEditModal = true
            // Else turn the possibility off
            else this.canOpenEditModal = false

            // Start the click timer
            this.startTimer()
        },

        // Stop the edit mode
        endClick(item) {

            // Stop the timer
            this.endTimer()

            // If the edit mode is active, open the edit modal
            if(this.canOpenEditModal) {

                // Set the selected cashier item
                this.$store.commit('setSelectedCashierItem', item)

                // Open the edit modal
                this.$store.commit('changeModal', { name : 'editCashierItem', allowClickOutside : false, active : true })
            }

            // If the edit mode is not active, add the item to the current order
            else this.$store.commit('addOrderItem', item)
        },

        // Starts a timer to check whether the user is holding the item to edit it or not
        startTimer() {

            // If the user is holding the item when the timer is up, activate the edit mode
            this.editTimer = setTimeout(() => {
                this.editModeActive = true
            }, 1500)

        },

        // Stop the timer
        endTimer() { clearTimeout(this.editTimer) },
    }
}
</script>

<style lang="scss" scoped>

.container {
    
    .info { 

        display: flex;
        flex-direction: column;
        margin-bottom: 3rem;

        .cashierName {
            text-align: center;
            font-family: var(--OpenSans);
            font-size: 2rem;
            font-weight: 700;
            border: none;
    
            &:focus {
                opacity: 1;
                border-bottom: 1px solid var(--MediumBlue);
            }
        }

        p {
            text-align: center;
            margin: 0 3rem;
        }
    }

    .cashierItems {
        width: 100%;
        display: flex;
        justify-content: center;
        gap: .8rem;
        flex-wrap: wrap;

        li {
            display: flex;
            align-items: center;
            justify-content: center;

            cursor: pointer;

            -moz-user-select: none;
            -webkit-user-select: none;
            -ms-user-select: none;
            user-select: none;
        }
    }

}

</style>