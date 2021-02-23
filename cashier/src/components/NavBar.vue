<template>
<nav>

    <div class="bars">
        <hr>
        <hr>
        <hr>
        <hr>
    </div>

    <div class="icons">
        <div class="activeOrder"></div>
        <div class="waitingOrders"></div>
    </div>

</nav>
</template>

<script>
export default {

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
        gap: .5rem;

        .activeOrder {
            height: 2rem;
            width: 2rem;
            background-color: var(--MouldGreen);
        }

        .waitingOrders {
            height: 2rem;
            width: 2rem;
            background-color: var(--Brown);
        }
    }
}

</style>