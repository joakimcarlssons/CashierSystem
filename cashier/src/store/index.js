import Vue from 'vue'
import Vuex from 'vuex'

// Import mutation names
import * as m from './mutations'

// Import modules
import {Cashier} from './modules/cashier'
import {Order} from './modules/order'
import {User} from './modules/user'

/* API imports */
import {GenerateQRCode} from '@/API/swish.js' 

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
    generateSwishPayment: (state, code) => state.qrCode = code

  },
  actions: {

    async generateSwishPayment(context) {
      let res = await GenerateQRCode()
      context.commit('generateSwishPayment', res.data)
    }

  },
  modules: {

    cashier : Cashier,
    order : Order,
    user : User

  }
})
