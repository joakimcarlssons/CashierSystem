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
                state.totalAmount += 1

                // Add the item to the order
                state.currentOrder.push(item)
            }
        },

        // Update the amount values shown in UI
        [m.UPDATE_ORDER_AMOUNTS]: (state, payload) => {

            // Get the item
            let item = state.currentOrder.find(x => x.id == payload._item.id)

            // When the user wants to increase the quantity of an item...
            if(payload.action == 'increase' && item.amount < item.stock) {                    
                    state.totalAmount += 1
                    item.amount += 1
            }

            // When the user wants to decrease the quantity of an item
            else if(payload.action == 'decrease' && item.amount > 0) {
                state.totalAmount -= 1
                item.amount -= 1
            }
        }

    },

    actions : {
    },

    getters : {
    }
}