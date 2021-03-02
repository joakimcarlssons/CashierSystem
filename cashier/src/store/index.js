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
    modal : { name : "", allowOutsideClick : true, active : false }

  },
  mutations: {

    // Change the current modal/overlay
    [m.CHANGE_MODAL]: (state, modal) => state.modal = modal,

    // Reset the modal/overlay
    [m.RESET_MODAL]: (state) => state.modal = { name : "", allowOutsideClick : true, active : false }

  },
  actions: {

    async generateSwishPayment(context, payload) {
      let res = await GenerateQRCode(payload.phoneNumber, payload.amount)
      console.log(res)
      console.log(context)
    }

  },
  modules: {

    cashier : Cashier,
    order : Order,
    user : User

  }
})
