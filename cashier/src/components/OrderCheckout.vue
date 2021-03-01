<template>
  <div class="container overlayContainer">
      <ul>
        <li
        v-for="item in currentOrder"
        :key="item.id"
        >
        <OrderCheckoutItem
        :item="item"
        @priceChanged="changePrice"
        />
        </li>
      </ul>

      <hr>

      <div class="totals">
        <h2>Totalt: {{totalPrice}} kr</h2>
      </div>

      <hr>

      <div class="checkout">
        <button>Bekräfta</button>
      </div>

  </div>
</template>

<script>
import OrderCheckoutItem from '@/components/OrderCheckoutItem'

export default {
  components: { OrderCheckoutItem },

  data(){ return {
    totalPrice : 0
  }},

  computed: {
    currentOrder() { return this.$store.state.order.currentOrder },
  },

  methods: {
    changePrice() {
      this.totalPrice = 0
      this.currentOrder.forEach(x => {
        this.totalPrice += (x.price * x.amount)
      })
    },
  },

  mounted() {
      this.currentOrder.forEach(x => {
        this.totalPrice += (x.price * x.amount)
      })
  }

}
</script>

<style lang="scss" scoped>

.container {
  justify-content: space-around;
  padding: 1rem;

  ul {
    width: 100%;
    height: 70%;
    overflow-y: auto;
  }

  hr {
    width: 95%;
    border: none;
    border-bottom: 1px dotted var(--GreyBlue);
  }
}

.overlayContainer {
  min-height: 50rem;
  min-width: 24rem;
}

</style>