<template>
    <div class="overlay navOverlay">

        <div class="close" @click="$store.commit('resetModal')">
                X
        </div>

        <ul>
          <li
          v-for="(route, index) in $router.options.routes"
          :key="index"
          >
              <router-link 
              :to="route.path" 
              :class="route.name == $route.name ? 'active' : ''" 
              @click.native="$store.commit('resetModal')">
              {{route.name}}
              </router-link>

              <hr>
          </li>
        </ul>

    </div>
  
</template>

<script>
export default {
    mounted(){ console.log(this.$router.options.routes)}
}
</script>

<style lang="scss" scoped>

.navOverlay {
    height: 100%;
    background-color: rgba(13, 22, 20, .9);
    color: #FFF;

    .close {
        align-self: flex-end;
        margin-top: -14rem;
        margin-right: 2rem;
        font-size: 1.5rem;
        font-family: Verdana, Geneva, Tahoma, sans-serif;
        font-weight: 900;
    }
    ul {
        height: 70vh;
        display: flex;
        flex-direction: column;
        align-items: center;
        justify-content: center;
        li {
            display: flex;
            flex-direction: column;
            align-items: center;
            
            a {
                color: var(--White);
                font-size: 1.3rem;
                text-transform: uppercase;
                letter-spacing: .2rem;

                &.active {
                    color: var(--DarkBeige);
                }
            }
            hr {
                width: 7rem;
                opacity: .3;
                margin: 2rem 0;
            }
        }
        li:last-of-type {
            hr {
                display: none;
            }
        }
    }
}


</style>