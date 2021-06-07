// Imports >>
import axios from 'axios'

// Define variables
let baseURL = "https://localhost:44316/"

//#region User functions

// Creates a new user
export async function CreateUser(phoneNumber, PIN) {

    return await axios.post(baseURL + "user/create", {
        phoneNumber: phoneNumber,
        PIN: PIN
    })
    .then  (res => { return res})
    .catch (err => { return err.response });
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
    })
    .then  (res => { return res})
    .catch (err => { return err.response });
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
            image: item.img,
            description: item.desc
        }
    })
    .then  (res => { return res})
    .catch (err => { return err.response });
}

// Update an item
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
            image: item.img,
            description: item.desc
        }
    })
    .then  (res => { return res})
    .catch (err => { return err.response });
}

//#endregion

//#region Menu functions

// Gets the requested menu from a seller
// A user id can be provided to fetch that sellers items.
// A token can be provided to retrieve the logged in sellers items
export async function GetMenu(id = null, token = null) {

    return await axios({
        method: 'get',
        url: baseURL + "menu/" + id,
        headers: {
            Authorization: token
        }
    });
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
export async function DeleteOrder(id, token) {

    return await axios({
        method: 'delete',
        url: baseURL + "order/" + id,
        headers: {
            Authorization: token
        }
    });
}

//#endregion

//#region Swish functions

// Get swish QR code
export async function GetSwishQR(sum, token) {

    return await axios({
        method: 'post',
        url: baseURL + "Swish/QR",
        headers: {
            Authorization: token
        },
        data: {
            price: sum
        }
    })
    .then  (res => { return res})
    .catch (err => { return err.response });
}

//#endregion