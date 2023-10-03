var express = require('express');
var router = express.Router();
var userModel = require('../models/userModel');
var session = require('express-session');
var flash = require('connect-flash');

router.use(session({
  secret: 'keyboard cat',
  resave:true,
  saveUninitialized:true,
  cookie: { maxAge: 60000 }
}));
router.use(flash());
/* GET users listing. */
router.use('/',async function(req,res,next){
  if(req.session){
    req.user = await userModel.findById(req.session.userId);
  }
  next();
})
router.get('/', async function(req, res, next) {
  if(req.user){
    if(req.user.role=="user"){
      res.render('Profile/index',{user:req.user});
    }else{
      let users = await userModel.find();
      res.render('Profile/admin',{admin:req.user,users:users,error: req.session.error,message:req.session.message});
    }
  }else{
    req.session.regenerate(function(err){
      if (err) next(err);
      req.session.error = "You need to login first";
      req.session.save(function(err){
        if (err) next(err);
        return res.redirect('/');
      })
    });
  }
});
router.get('/delete/:id',async(req,res,next)=>{
  if(req.params.id&& req.user && req.user.role == "admin"){
    let userDel;
    try {
      userDel= await userModel.findById(req.params.id); 
    } catch (error) {
      console.log(error);
    }
    if(userDel.role != "admin" ){
      try {
        await userModel.findByIdAndDelete(req.params.id);
      } catch (error) {
        console.log(error);
        req.session.regenerate(function(err){
          if (err) next(err);
          req.session.userId = req.user._id.toString();
          req.session.error= "Delete user unsucessfully.";
          req.session.save(function(err){
            if(err) next(err);
            return res.redirect('/profile');
          })
        })
      }
      req.session.regenerate(function(err){
        if (err) next(err);
        req.session.userId = req.user._id.toString();
        req.session.message= "Delete user successfully.";
        req.session.save(function(err){
          if(err) next(err);
          return res.redirect('/profile');
        })
      })
    }
    else{
      req.session.regenerate(function(err){
        if(err) next(err);
        req.session.error = "You have no permission to delete this user";
        req.session.userId = req.user._id.toString();
        req.session.save(function(err){
          if(err) next(err);
          return res.redirect('/profile');
        })
      })
    }
  }else{
    req.session.regenerate(function(err){
      if (err) next(err);
      req.session.error = "Something wrong you cant do that task";
      req.session.save(function(err){
        if(err)next(err);
        return res.redirect('/');
      })
    })
  }  
})
module.exports = router;
