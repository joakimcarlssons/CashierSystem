import * as m from '../mutations'
import * as API from '../../API/index';

export const User = {

    state: () => ({
        // Currently logged on user
        currentUser : {}
    }),

    mutations : {

        [m.REGISTER_USER]: (state, user) => {
            // Save the user phone number
            state.currentUser.phoneNumber = user.phoneNumber
        }
    },

    actions : {
        async [m.REGISTER_USER](context, user) {
            // Make API call and get the result
            let res = await API.CreateUser(user.phoneNumber, user.pin);
            // If response from server was 200
            if(res.status == 200) {
                // Save the JWT token to local storage
                localStorage.setItem('JWT', JSON.stringify(res.data.response.token));
                // Commit changes
                context.commit(m.REGISTER_USER, res.data.response.user)
            }
            // Else if API call was not successful
            else {
                // Log the error message
                console.log(res.data.error);
            }

        }
    },

    getters : {

    }

}