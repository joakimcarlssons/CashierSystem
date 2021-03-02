// Imports >>
import axios from 'axios'

// Define variables
baseURL = "https://localhost:5001/"

//#region User functions

// Creates a new user
export async function CreateUser(phoneNumber, PIN) {

    return await axios.post(baseURL + "User/Create", {
        phoneNumber: phoneNumber,
        PIN: PIN
    });
}
// Logins the user
export async function LoginUser(phoneNumber, PIN) {

    return await axios.post(baseURL + "User/Login", {
        phoneNumber: phoneNumber,
        PIN: PIN
    });
}

//#endregion

//#region Item functions

// Gets the requested item
export async function GetItem(id) {

    return await axios.get(baseURL + "Item/" + id);
}

// Delete an item
export async function DeleteItem(id, token) {

    return await axios({
        method: 'delete',
        url: baseURL + "Item/" + id,
        headers: {
            Authorization: token
        }
    });
}

// Creates a new item
export async function CreateItem(item, token) {

    return await axios({
        method: 'post',
        url: baseURL + "Item",
        headers: {
            Authorization: token
        },
        data: {
            name: item.name,
            stock: item.stock,
            price: item.price,
            sellerID: item.sellerID,
            image: item.image,
            description: item.description
        }
    });
}

// Updates an item
export async function UpdateItem(id, item, token) {

    return await axios({
        method: 'patch',
        url: baseURL + "Item/" + id,
        headers: {
            Authorization: token
        },
        data: {
            name: item.name,
            stock: item.stock,
            price: item.price,
            sellerID: item.sellerID,
            image: item.image,
            description: item.description
        }
    });
}

//#endregion

//#region Menu functions

// Gets the requested menu from a seller
export async function GetMenu(id) {

    return await axios.get(baseURL + "menu/" + id);
}

//#endregion

//#region Order functions

// Creates an order
export async function CreateOrder(sellerID, itemIDs) {

    return await axios({
        method: 'post',
        url: baseURL + "order",
        data: {
            sellerID: sellerID,
            items: itemIDs
        }
    });
}

// Delete an order
export async function DeleteItem(id, token) {

    return await axios({
        method: 'delete',
        url: baseURL + "order/" + id,
        headers: {
            Authorization: token
        }
    });
}

//#endregion