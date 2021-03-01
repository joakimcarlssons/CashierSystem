import * as m from '../mutations'

export const Order = {

    state: () => ({
        currentOrder : []
    }),

    mutations : {

        // Add an order item to the store version
        [m.ADD_ORDER_ITEM]: (state, item) => state.currentOrder.push(item)

    },

    actions : {
    },

    getters : {
    }
}