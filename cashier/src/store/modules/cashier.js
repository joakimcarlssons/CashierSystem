import * as m from '../mutations'

export const Cashier = {

    state: () => ({

        // The current cashier created by the user
        currentCashier : {
            name : "Kassa 1",
            cashierItems : []
        },

        selectedItem : {},
    }),

    mutations : {

        // Add a cashier item to the store version
        [m.ADD_CASHIER_ITEM]: (state, item) => state.currentCashier.cashierItems.push(item),
        
        // Remove a cashier item in the store version
        [m.REMOVE_CASHIER_ITEM]: (state, item) => state.currentCashier.cashierItems.splice(state.currentCashier.cashierItems.indexOf(item), 1),

        // Set the cashier item that has been slected for edit or deletion
        [m.SELECT_CASHIER_ITEM]: (state, item) => state.selectedItem = item,

        // Reset the selected cashier item
        [m.RESET_SELECTED_CASHIER_ITEM]: (state) => state.selectedItem = {}
    },

    actions : {

        // Add a cashier item to the database version
        async [m.ADD_CASHIER_ITEM](context, item) {

            // TODO: Make Api call

            context.commit(m.ADD_CASHIER_ITEM, item)
        },

        // Remove a cashier item from database
        async [m.REMOVE_CASHIER_ITEM](context, item) {

            // TODO: Make Api call

            context.commit(m.REMOVE_CASHIER_ITEM, item)
        }
    },

    getters : {

    }
}