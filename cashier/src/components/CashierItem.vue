<template>
  <div class="container">

    <div class="editDelete">

      <div class="btns" v-if="editable"> 
        <img 
        src="@/assets/trash-solid.svg" 
        alt="trash" 
         @click="confirmDeletion">

      </div>

    </div>


    <img src="@/assets/image-not-found.svg" alt="No image found">
    
    <div class="info">
      <h2>{{cashierItem.name}}</h2>
      <p>{{cashierItem.desc}}</p>
      <h4>{{cashierItem.price}} kr</h4>
    </div>

  </div>
</template>

<script>
export default {

    props: {
        cashierItem : Object,
        editable : Boolean
    },

    methods: {
      confirmDeletion() {
        this.$store.commit('setSelectedCashierItem', this.cashierItem)

        this.$store.commit('changeModal', 
            { name : 'deleteCashierItem', allowOutsideClick : true, active : true })
      }
    }

}
</script>

<style lang="scss" scoped>

.container {
    justify-content: space-around;
    height: 17rem;
    width: 12rem;
    background-color: rgba(244, 244, 244, .2);
    border: 1px solid rgba(244, 244, 244, .6);

    .editDelete {
      align-self: flex-end;
      min-height: 1.5rem;

      .btns {
        display: flex;
        img {
          margin: 0 .5rem;
          height: 1.4rem;

          &:hover, &:focus, &:active { opacity: 1; }
        }

      }
    }

    img {
        height: 5rem;
        opacity: .3;
    }

    .info {
        align-self: flex-start;
        margin-left: 1rem;
        display: flex;
        flex-direction: column;
    }
}

</style>