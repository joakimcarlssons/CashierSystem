import * as m from '../mutations'

export const User = {

    state: () => ({
        currentUser : {}
    }),

    mutations : {

        [m.REGISTER_USER]: (state, user) => state.currentUser = user
    },

    actions : {
        async [m.REGISTER_USER](context, user) {

            // TODO: Make Api call

            context.commit(m.REGISTER_USER, user)
        }
    },

    getters : {

    }

}