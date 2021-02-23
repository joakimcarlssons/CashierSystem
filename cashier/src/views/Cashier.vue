<template>
  <div class="container">

      <div class="info">
        <input type="text" class="cashierName" placeholder="Ditt kassanamn" v-model="cashier.name">

        <p v-if="cashier.cashierItems.length == 0">
            Klicka på plusset för att lägga till din första produkt
        </p>

      </div>

      <ul class="cashierItems">

          <li 
          v-for="item in cashier.cashierItems"
          :key="item.id"
          >
            <CashierItem :cashierItem="item" />
          </li>

          <li
          class="createItem"
          @click="$store.commit('changeModal', { name : 'createCashierItem', active : true })"
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

    components : { CashierItem, EmptyCashierItem },

    computed: {
        cashier() { return this.$store.state.cashier.currentCashier }
    },
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