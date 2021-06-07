import * as m from '../mutations'
import * as API from '../../API/index'

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
        [m.ADD_CASHIER_ITEM]: (state, item) => {
            // Create the new item
            let newItem = item;
            item.desc = item.description;
            item.img = item.image;

            // Delete properties from the new object
            delete item.description;
            delete item.image;

            // Add the new item to the list
            state.currentCashier.cashierItems.push(newItem)
        },
        
        // Remove a cashier item in the store version
        [m.REMOVE_CASHIER_ITEM]: (state, item) => state.currentCashier.cashierItems.splice(state.currentCashier.cashierItems.indexOf(item), 1),

        // Update a cashier item in the store version
        [m.UPDATE_CASHIER_ITEM]: (state, item) => {
            // Create the new item
            let newItem = item;
            item.desc = item.description;
            item.img = item.image;

            // Delete properties from the new object
            delete item.description;
            delete item.image;

            // Update the item
            Object.assign(state.currentCashier.cashierItems.find(x => x.id == item.id), newItem)
        },

        // Set the cashier item that has been slected for edit or deletion
        [m.SELECT_CASHIER_ITEM]: (state, item) => state.selectedItem = item,

        // Reset the selected cashier item
        [m.RESET_SELECTED_CASHIER_ITEM]: (state) => state.selectedItem = {}
    },

    actions : {

        // Add a cashier item to the database version
        async [m.ADD_CASHIER_ITEM](context, item) {

            // Get the JWT token from local storage
            let token = localStorage.getItem('JWT');

            // If a token exists in local storage
            if(token != null){
                // Make API call to create the new item
                let res = await API.CreateItem(item, token)

                // If the API call was successful
                if(res.status == 200) {          
                    // Log the returned message          
                    console.log(res.data.response.message);
                    // Commit changes
                    context.commit(m.ADD_CASHIER_ITEM, res.data.response.item);
                }
                // If the API call was not successful
                else {
                    console.log(res.data.error);
                }
            }           
        },

        // Remove a cashier item from database
        async [m.REMOVE_CASHIER_ITEM](context, item) {

            // Get the JWT token from local storage
            let token = localStorage.getItem('JWT');

            // If a token exists in local storage
            if(token != null){
                // Make API call to delete the item
                let res = await API.DeleteItem(item.itemID, token)

                // If the API call was successful
                if(res.status == 200) {         
                    // Log returned message from the server           
                    console.log(res.data.response);
                    // Commit changes
                    context.commit(m.REMOVE_CASHIER_ITEM, item)
                }
                // If the API call was not successful
                else {
                    // Log the error message
                    console.log(res.data.error);
                }
            }   
        },

        // Update a cashier item in the database
        async [m.UPDATE_CASHIER_ITEM](context, item) {

            // Get the JWT token from local storage
            let token = localStorage.getItem('JWT');

            // If a token exists in local storage
            if(token != null){
                // Make API call to update the item
                let res = await API.UpdateItem(item.itemID, item, token)

                // If the API call was successful
                if(res.status == 200) { 
                    // Log the returned message                   
                    console.log(res.data.response.message);
                    // Commit the changes
                    context.commit(m.UPDATE_CASHIER_ITEM, res.data.response.item)
                }
                // If the API call was not successful
                else {
                    // Log the error message
                    console.log(res.data.error);
                }
            }    
        }
    },

    getters : {

    }
}