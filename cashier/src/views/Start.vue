<template>
  <div class="container">

      <h1>
          Att sälja saker har aldrig varit lättare.
      </h1>
    
    <div class="inputContent">
      <input type="number" placeholder="Telefonnummer" v-model="user.phoneNumber" />

      <button class="cta" @click="registerUser">
              <p>Skapa kassa</p>
              <p class="end">></p>
      </button>
    </div>

    <h4>Läs mer | Hitta kassa</h4>

  </div>
</template>

<script>
export default {

    data(){ return {

        // The user of the application
        user : {
            phoneNumber : null,
        }

    }},

    methods: {

        // Register a user
        async registerUser() {
            await this.$store.dispatch('registerUser', this.user)

            this.$router.push('/cashier')
        }
    }

}
</script>

<style lang="scss" scoped>

.container {
    justify-content: space-evenly;
    margin: 0 2rem;
    text-align: center;

    .cta {
        padding: 0;
        margin: 2rem;
        display: flex;

        p {
            align-self: center;
 
            &:first-of-type {
                padding: 1.5rem 3rem 1.5rem 5rem;
                letter-spacing: .07rem;
            }

            &:last-of-type {
                padding-right: 2rem;
            }
        }
    }

    h4 {
        margin: 2rem;
    }

    input {
        margin-top: 4rem;
    }
}


</style>