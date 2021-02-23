import Vue from 'vue'
import Vuex from 'vuex'

// Import mutation names
import * as m from './mutations'

// Import modules
import {Cashier} from './modules/cashier'

Vue.use(Vuex)

export default new Vuex.Store({
  state: {

    // The modal/overlay currently being shown in the application
    modal : { name : "", active : false }

  },
  mutations: {

    // Change the current modal/overlay
    [m.CHANGE_MODAL]: (state, modal) => state.modal = modal,

    // Reset the modal/overlay
    [m.RESET_MODAL]: (state) => state.modal = { name : "", active : false }

  },
  actions: {
  },
  modules: {

    cashier : Cashier

  }
})
