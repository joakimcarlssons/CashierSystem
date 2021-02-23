<template>
  <div class="container">

      <h1>
          Att sälja saker har aldrig varit lättare.
      </h1>
    
    <div class="inputContent">
      <input type="text" placeholder="Telefonnummer" />

      <button class="cta">
              <p>Skapa kassa</p>
              <p class="end">></p>
      </button>
    </div>

    <h4>Lär mig mer</h4>

  </div>
</template>

<script>
export default {

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
    
        p:first-of-type {
            align-self: center;
            padding: 1.5rem 3rem 1.5rem 5rem;
        }
    
        p:last-of-type {
            align-self: center;
            padding-right: 2rem;
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