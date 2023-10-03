const mongoose= require('mongoose');
let bookModel = new mongoose.Schema({
    title: String,
    price: {type: Number,min:0},
    image: String
});
module.exports = mongoose.model("Book",bookModel);