<template>
  <div class="container" v-html="qrCode">
  </div>
</template>

<script>
export default {

    props: {
        qrCode : String
    }
}
</script>

<style>

</style>