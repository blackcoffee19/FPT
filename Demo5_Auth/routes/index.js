var express = require('express');
var router = express.Router();
var session = require('express-session');
var mongoose = require('mongoose');
router.use(session({
  secret: 'keyboard cat',
  resave:true,
  saveUninitialized:true,
  cookie: { maxAge: 60000 }
}));
var UserModel = require('../models/userModel');
const userModel = require('../models/userModel');
const bcrypt = require('bcrypt');
var multer = require('multer');
let storage = multer.diskStorage({
  //Config thu muc luu hinh
  destination: (req,file,cb)=>{
      cb(null,'./public/images');
  },
  filename: (req,file,cb)=>{
      cb(null,file.fieldname+"-"+Date.now()+".jpg");
  }
})
var upload = multer({storage:storage});

router.get('/', function(req, res, next) {
  if(req.session.userId){
    req.session.destroy(function(err){
      if(err) next(err);
    })
  }
  console.log(req.session.error);
  res.render('index',{error: req.session.error,message:req.session.messagel});
});
router.get('/create',(req,res,next)=>{
  res.render('create',{error: req.session.error});
});
router.post('/create',upload.single('image'),(req,res,next)=>{
  if(req.body.password != req.body.repassword){
    var err = new Error("Password do not match.");
    err.status =400; 
    res.send("password do not match");
    return next(err);
  };
  if(req.body.email && req.body.name && req.body.password && req.body.repassword){
    var userData = {
      name: req.body.name,
      email: req.body.email,
      password:req.body.password,
      image: req.file? req.file.filename:null,
      role: req.body.role
    };
    userModel.create(userData,function(err,user){
      if(err){
        req.session.regenerate(function(err){
          if(err) next(err);
          req.session.error= "Cannot create user, email have been sign.";
          req.session.save(function(err){
            if(err) next(err);
            return res.redirect('/create');
          })
        })
      }else{
        req.session.regenerate(function(err){
          if(err) next(err);
          req.session.userId = user._id.toString();
          req.session.save(function(err){
            if(err) next(err);
            return res.redirect('/profile');
          });
        });
      }
    })
  }else{
    var err = new Error("All fields required.");
    err.status = 400;
    return next(err);
  }
})
router.post('/login',(req,res,next)=>{
  if(req.body.email && req.body.password){
    UserModel.authenticate(req.body.email,req.body.password,(err,user)=>{
      if(err|!user){
        req.session.regenerate(function(err){
          if (err) next(err);
          req.session.error = "Wrong email or password.";
          req.session.save(function(err){
            if(err) next(err);
            return res.redirect('/');
          })
        })
        // var error = new Error("Wrong email or password.");
        // error.status = 401;
        // return next(error);
      }else{
        let userid = user._id.toString();
        req.session.regenerate(function(err){
          if (err ) next(err);
          req.session.userId = userid;
          req.session.save(function(err){
            if (err) return next(err);
            return res.redirect('/profile');
          })
        });
      }
    });
  }else{
    var err = new Error("All fields required.");
    err.status = 400;
    return next(err);
  }
})
router.get("/logout",(req,res,next)=>{
  if(req.session){
    req.session.regenerate(function(err){
      if(err) next(err);
      req.session.messagel = "You had logout.";
      req.session.save(function(err){
        if(err) next(err);
        return res.redirect('/');
      }) 
    })
  }
})
module.exports = router;
