const mongoose = require('mongoose');
const bcrypt = require('bcrypt');

let userSchema = new mongoose.Schema({
    name: {
        type: String,
        required: true,
        trim: true
    },
    email: {
        type: String,
        unique: true,
        required: true,
        trim: true
    },
    password: {
        type: String,
        required: true
    },
    image: {
        type: String,
        required: false
    },
    role: {
        type: String,
        enum: ['user', 'admin'],
        require: true
    },
    date: { type: Date, default: Date.now }
});
userSchema.statics.authenticate = (email,password,callback)=>{
    console.log("Authenticate: \n"+email+"\nPw: "+password);
    mongoose.model("User").findOne({email:email}).exec((err,user)=>{
        if(err){
            return callback(err);
        }else if(!user){
            let err = new Error("User Not Found");
            err.status = 401;
            return callback(err);
        }
        bcrypt.compare(password,user.password,function(err,res){
            if(res == true){
                return callback(null,user);
            }else{
                return callback();
            }
        })
    })
}
userSchema.pre('save',function(next){
    let user = this;
    bcrypt.hash(user.password,10,function(err,hash){
        if (err ){ return next(err);}
        user.password = hash;
        next();
    })
})
module.exports = mongoose.model("User",userSchema);