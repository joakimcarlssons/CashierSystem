import Vue from 'vue'
import Vuex from 'vuex'

// Import mutation names
import * as m from './mutations'

// Import API functions
import * as API from '../API/index'

// Import modules
import {Cashier} from './modules/cashier'
import {Order} from './modules/order'
import {User} from './modules/user'

Vue.use(Vuex)

export default new Vuex.Store({
  state: {

    // The modal/overlay currently being shown in the application
    modal : { name : "", allowOutsideClick : true, active : false },
    qrCode : ""

  },
  mutations: {

    // Change the current modal/overlay
    [m.CHANGE_MODAL]: (state, modal) => state.modal = modal,

    // Reset the modal/overlay
    [m.RESET_MODAL]: (state) => state.modal = { name : "", allowOutsideClick : true, active : false },

    // Update the QR Code
    generateSwishPayment: (state, code) => {
      console.log(code);
      
      state.qrCode = code
    }

  },
  actions: {

    async generateSwishPayment(context, sum) {

      // Get the JWT token
      let token = localStorage.getItem('JWT');

      // If a token is saved in storage (User is logged on)
      if(token != null){
        // Make API call
        var res = await API.GetSwishQR(sum, token);
        // Commit changes
        context.commit('generateSwishPayment', res.data.response.qr);
      }
    }

  },
  modules: {

    cashier : Cashier,
    order : Order,
    user : User

  }
})
