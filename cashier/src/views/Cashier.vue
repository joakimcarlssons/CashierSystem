<template>
  <div class="container" @click="canExitEditMode ? shake = false : ''">

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
          @mousedown="startTimer"
          @touchstart="startTimer"
          @mouseup="shakeReady = false"
          @touchend="shakeReady = false"
          :class="{shake : shake}"
          >
            <CashierItem :cashierItem="item" :editable="shake"
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
        shakeReady : false,
        shake : false,
        canExitEditMode : false
    }},

    components : { CashierItem, EmptyCashierItem },

    computed: {
        cashier() { return this.$store.state.cashier.currentCashier }
    },

    methods: {
        startTimer() {
            this.shakeReady = true

            setTimeout(() => {
                if (this.shakeReady) this.shake = true
            }, 1000)
        }
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
        }
    }

}

</style>