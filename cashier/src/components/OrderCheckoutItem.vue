<template>
  <div class="itemContainer">      
    
      <img :src="imgUrl" alt="" />

      <div class="content">
        
        <div class="text">
          <h3>{{item.name}}</h3>
          <h4>{{item.price}} kr</h4>
        </div>

        <div class="amount">
          <h4 @click="increaseAmount">+</h4>
          <h3>{{itemAmount}}</h3>
          <h4 @click="decreaseAmount">-</h4>
        </div>
      </div>

  </div>
</template>

<script>
export default {
    props: {
        item : Object
    },

    data(){ return {
      itemAmount : 0
    }},

    computed: {
      imgUrl() { return require('@/assets/' + this.item.img) },
      currentItem() { return this.$store.state.order.currentOrder.find(x => x.id == this.item.id) }
    },

    mounted() { this.itemAmount = this.item.amount },

    methods: {

      // Increase the items amount...
      increaseAmount() {

        //..in the store
        this.$store.commit('updateOrderAmounts', { action : 'increase', _item : this.item })

        //..and locally
        this.itemAmount = this.currentItem.amount

        // Change the total price
        this.$emit('priceChanged', this.itemAmount)
      },

      // Descrease the items amount
      decreaseAmount() {

        //..in the store
        this.$store.commit('updateOrderAmounts', { action : 'decrease', _item : this.item })
      
        //..and locally
        this.itemAmount = this.currentItem.amount

        // Change the total price
        this.$emit('priceChanged', this.itemAmount)
      }
    }
}
</script>

<style lang="scss" scoped>

.itemContainer {
  display: grid;
  grid-template-columns: .7fr auto;
  align-items: center;

  box-shadow: 0 0 .7rem 0rem var(--GreyBlue);
  margin: 1rem;
  border-radius: .5rem;

  img {
    margin: 1.5rem;
  }

  .content {
    margin-left: .5rem;
    display: flex;
    align-items: center;
    justify-content: space-between;

    .text {
      h3 {
        font-size: 1.3rem;
      }
      h4 {
        font-size: 1.2rem;
      }
    }

    .amount {
      display: flex;
      flex-direction: column;
      justify-content: center;
      align-items: center;
      margin: 1rem;

      h4 {
        display: flex;
        justify-content: center;
        align-items: center;
        height: 2rem;
        width: 2rem;
        margin: .8rem 0;
        font-size: 1.5rem;
        box-shadow: 0 0 .5rem 0rem var(--GreyBlue);
      }
    }

  }
}

</style>