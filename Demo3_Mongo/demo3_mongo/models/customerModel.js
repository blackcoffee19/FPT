const mongo = require('mongoose');

const customer = mongo.Schema({
    name : String,
    email: String,
    phone: String
});
module.exports = mongo.model('customer',customer);