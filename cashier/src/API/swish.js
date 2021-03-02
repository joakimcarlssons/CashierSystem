import axios from 'axios'

export async function GenerateQRCode() {

    return await axios({
        method: 'post',
        url: 'https://cors-anywhere.herokuapp.com/https://mpc.getswish.net/qrg-swish/api/v1/prefilled',
        headers: {
            'X-Requested-With': 'XMLHttpRequest'
        },
        data: {
            "format" : "svg",
            "payee" : {
                "value" : '0760274800',
                "editable" : false
            },
            "amount" : {
                "value" : '100',
                "editable" : false
            }
        }

    });
}