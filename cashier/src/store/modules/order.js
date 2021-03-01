import * as m from '../mutations'

export const Order = {

    state: () => ({
        currentOrder : [],
        totalAmount : 0
    }),

    mutations : {

        // Add an order item to the store version
        [m.ADD_ORDER_ITEM]: (state, item) => {
            
            // If the item already has been added...
            if(state.currentOrder.find(x => x.id == item.id)) {

                // Increase the amount
                state.currentOrder.find(x => x.id == item.id).amount += 1
                state.totalAmount += 1
            }
            
            // Add the item to the order if it hasn't been added before
            else {
                // Add the amount property to the item
                item.amount = 1
                state.totalAmount = 1

                // Add the item to the order
                state.currentOrder.push(item)
            }
        },

        [m.UPDATE_ORDER_AMOUNTS]: (state, payload) => {

            if(payload.action == 'increase') {
                state.totalAmount += 1
                state.currentOrder.find(x => x.id == payload._item.id).amount += 1
            }
            else if(payload.action == 'decrease') {
                state.totalAmount -= 1
                state.currentOrder.find(x => x.id == payload._item.id).amount -= 1
            }
        }

    },

    actions : {
    },

    getters : {
    }
}