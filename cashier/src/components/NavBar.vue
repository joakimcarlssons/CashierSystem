<template>
<nav>

    <div class="bars">
        <hr>
        <hr>
        <hr>
        <hr>
    </div>

    <div class="icons">
        <div class="activeOrder"
        @click="$store.commit('changeModal', { name : 'orderCheckout', allowOutsideClick : true, active: true })"
        >
            <div class="cartAmount" :style="orderAmount > 9 ? 'padding: 0.4rem 0.4rem;' : 'padding: 0.4rem 0.6rem;'">
                {{orderAmount}}
            </div>    
        </div>
        <div class="help"></div>
    </div>

</nav>
</template>

<script>
export default {

    computed: {
        orderAmount() { return this.$store.state.order.totalAmount }
    }
}

</script>

<style lang="scss" scoped>

nav {
    margin: 2rem;

    display: flex;
    justify-content: space-between;

    /* Mobile nav */
    .bars {
        hr {
            margin: .2rem;
            padding: .1rem;
            border: none;
            background-color: var(--DarkBlue);
            transition: .3s;

            &:nth-of-type(1) {
                width: 1.7rem;
            }

            &:nth-of-type(2) {
                width: 2rem;
            }

            &:nth-of-type(3) {
                width: 1.5rem;
            }

            &:nth-of-type(4) {
                width: 1.9rem;
            }
        }

        &:hover {
            cursor: pointer;

            hr {
                &:nth-of-type(1) {
                    width: 1.9rem;
                }

                &:nth-of-type(2) {
                    width: 1.5rem;
                }

                &:nth-of-type(3) {
                    width: 1.7rem;
                }

                &:nth-of-type(4) {
                    width: 2rem;
                }
            }
        }
    }

    /* Icons */
    .icons {
        display: flex;
        gap: 1.5rem;

        .activeOrder, .help {
            display: flex;
            align-items: center;
            justify-content: center;
            height: 2rem;
            width: 2rem;

            color: white;
        }

        .activeOrder {
            background-image: url('~@/assets/shopping-cart-solid.svg');
            background-size: contain;
            background-repeat: no-repeat;
            opacity: .6;


            .cartAmount {
                background: var(--MediumBlue);
                border-radius: 100%;

                margin-top: -2rem;
                margin-right: -2rem;
            }

        }

        .help {
            background-image: url('~@/assets/question-circle-regular.svg');
            background-size: contain;
            background-repeat: no-repeat;
            opacity: .6;
        }
    }
}

</style>