var mongoose = require('mongoose');
let people = mongoose.Schema({
    id: Number,
    fullname: String,
    dob: { type: Date, require: true },
    reputation: String,
    photo: String
});

module.exports = mongoose.model("Peoples",people);