<template>
  <div class="container">

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
        cashierItem : Object
    }

}
</script>

<style lang="scss" scoped>

.container {
    justify-content: space-around;
    height: 15rem;
    width: 12rem;
    background-color: rgba(244, 244, 244, .2);
    border: 1px solid rgba(244, 244, 244, .6);

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