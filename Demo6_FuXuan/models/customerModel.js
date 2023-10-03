var mongoose = require('mongoose');
var bcrypt = require('bcrypt');

const customer = mongoose.Schema({
    name: String,
    email: {type:String,unique:true, require:true},
    password: String,
    image: String,
    phone: String
});


customer.statics.authenticate = (email,password,callback)=>{
    mongoose.model("Customer").findOne({email:email}).exec((err,cust)=>{
        if(err){
            return callback(err);
        }else if(!cust){
            let err = new Error("Customer Not Found");
            err.status = 401;
            return callback(err);
        }
        bcrypt.compare(password,cust.password,function(err,res){
            if(res == true){
                return callback(null,cust);
            }else{
                return callback();
            }
        })
    })
}
customer.pre('save',function(next){
    let cust = this;
    bcrypt.hash(cust.password,10,function(err,hash){
        if (err ){ return next(err);}
        cust.password = hash;
        next();
    })
})
module.exports = mongoose.model("Customer",customer);