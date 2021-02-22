<template>
  <div id="app">
    <Nav />
    <router-view/>
  </div>
</template>

<script>
import Nav from '@/components/NavBar'

export default {
  components : { Nav }
}
</script>

<style lang="scss">

/* Style imports */
@import url('~@/styles/globals.scss');
@import url('~@/styles/buttons.scss');
@import url('~@/styles/texts.scss');
@import url('~@/styles/inputs.scss');

#app {
  height: 100%;
  display: flex;
  flex-direction: column;
}

</style>
