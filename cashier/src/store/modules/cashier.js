import * as m from '../mutations'

export const Cashier = {

    state: () => ({
        currentCashier : {
            name : "Kassa 1",
            cashierItems : []
        }
    }),

    mutations : {
        [m.ADD_CASHIER_ITEM]: (state, item) => state.currentCashier.cashierItems.push(item) 
    },

    actions : {
        async [m.ADD_CASHIER_ITEM](context, item) {

            // TODO: Make Api call

            context.commit(m.ADD_CASHIER_ITEM, item)
        } 
    },

    getters : {

    }
}