import axios from 'axios'

export async function GenerateQRCode(phoneNumber, amount) {

    return await axios.post('https://mpc.getswish.net/qrg-swish/api/v1/prefilled', {
        "format" : "svg",
        "payee" : {
            "value" : phoneNumber,
            "editable" : false
        },
        "amount" : {
            "value" : amount,
            "editable" : false
        }
    })

}