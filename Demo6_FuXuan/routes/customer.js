let express = require('express');
let router = express.Router();
var session = require('express-session');
let customerModel = require('../models/customerModel');
router.use(session({
    secret: 'keyboard cat',
    resave:true,
    saveUninitialized:true,
    cookie: { maxAge: 60000 }
}));
const multer = require('multer');

//Config multer store data: 
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
router.use('/',async (req,res,next)=>{
    let customers = await customerModel.find();
    req.customers = customers;
    next();
})
router.use(['/detail/:id','/update/:id'],async(req,res,next)=>{
    let customer = await customerModel.findById(req.params.id);
    if(customer){
        req.customer = customer;
        console.log(req.customer);
        next();
    }else{
        req.session.regenerate(function(err){
            if(err) next(err);
            req.session.error = "Error: Not found Customer";
            req.session.save(function(err){
                if (err) next(err);
                return res.redirect('/customer');
            });
        })
    }
})
router.get('/',async (req,res,next)=>{
    res.render('Customer/index',{customers:req.customers,error:req.session.error,message:req.session.message});
})
router.get('/create',(req,res,next)=>{
    res.render('Customer/create',{error:req.session.error,message:req.session.message});
})
router.post('/create',upload.single("image"),async (req,res,next)=>{
    let regexPhone = /(84|0[3|5|7|8|9])+([0-9]{8})\b/;
    let checkPhone = regexPhone.test(req.body.phone);
    let regexEmail = /[\w]*@*[a-z]*\.*[\w]{5,}(\.)*(com)*(@gmail\.com)/;
    let checkEmail = regexEmail.test(req.body.email);
    let cuss = await customerModel.find({"email": req.body.email});//{ $regex: '.*' + title + '.*' }
    if(cuss.length>0){
        req.session.error = "Email has been signed.";
        return res.redirect('/customer/create');
    }
    let regexPass = /^.{6}/;
    let checkPass= regexPass.test(req.body.password);
    if(req.body.password != req.body.repassword){
        console.log(req.body.password != req.body.repassword)
        req.session.error = "Password Not Match";
        return res.redirect('/customer/create');
    }
    if(req.body.name && checkPhone && checkEmail && checkPass){
        try {
            await customerModel.create({
                name: req.body.name,
                phone: req.body.phone,
                email:req.body.email,
                password:req.body.password,
                image: req.file? req.file.filename:null
            });
            req.session.message = "Create Customer successfully.";
        } catch (error) {
            req.session.error = "Create customer unsucceff";
            return res.redirect('/customer/create');
        }
        return res.redirect('/customer');
    }else if(!checkPass){
        req.session.regenerate(function(err){
            if(err) next(err);
            req.session.error = "Error: Password too short (more than 6 character).";
            req.session.save(function(err2){
                if(err2) next(err2);
                return res.redirect(`/customer/create`);
            })
        })
    }else if(!checkPhone){
        req.session.regenerate(function(err){
            if(err) next(err);
            req.session.error = "Error: Phone invalid.";
            req.session.save(function(err2){
                if(err2) next(err2);
                return res.redirect(`/customer/create`);
            })
        });
    }else if(!checkEmail){
        req.session.regenerate(function(err){
            if(err) next(err);
            req.session.error = "Error: Email invalid.";
            req.session.save(function(err2){
                if(err2) next(err2);
                return res.redirect(`/customer/create`);
            })
        });
    }else{
        req.session.regenerate(function(err){
            if(err) next(err);
            req.session.error = "Error: Name is required.";
            req.session.save(function(err2){
                if(err2) next(err2);
                return res.redirect(`/customer/create`);
            })
        });
    }
})
router.get('/update/:id',async (req,res,next)=>{
    res.render('Customer/update',{customer: req.customer,error:req.session.error, message: req.session.message});
})
router.post('/update/:id',upload.single('image'),async(req,res,next)=>{
    let regexPhone = /(84|0[3|5|7|8|9])+([0-9]{8})\b/;
    let checkPhone = regexPhone.test(req.body.phone);
    let regexEmail = /[\w]*@*[a-z]*\.*[\w]{5,}(\.)*(com)*(@gmail\.com)/;
    let checkEmail = regexEmail.test(req.body.email);
    let cuss = await customerModel.find({"email": req.body.email});//{ $regex: '.*' + title + '.*' }
    if(cuss.length>1){
        req.session.error = "Email has been signed.";
        return res.redirect(`/customer/update/${req.params.id}`);
    }
    if(req.body.name && checkPhone && checkEmail){
        req.customer.name  = req.body.name;
        req.customer.email = req.body.email;
        req.customer.image = req.file? req.file.filename:req.customer.image;
        await req.customer.save().then(res=>console.log("Successfull")).catch(err=>{if(err)next(err);});
        req.session.regenerate(err=>{
            if(err) next(err);
            req.session.message = "Update Customer successfully.";
            req.session.save(function(err){
                if(err) next(err);
                return res.redirect('/customer');
            })
        }) 
    }else if(req.body.name && checkEmail){
        req.session.regenerate(function(err){
            if(err) next(err);
            req.session.error = "Error: Phone invalid.";
            req.session.save(function(err2){
                if(err2) next(err2);
                return res.redirect(`/customer/update/${req.params.id}`);
            })
        });
    }else if(req.body.name &&  checkPhone){
        req.session.regenerate(function(err){
            if(err) next(err);
            req.session.error = "Error: Email invalid.";
            req.session.save(function(err2){
                if(err2) next(err2);
                return res.redirect(`/customer/update/${req.params.id}`);
            })
        });
    }else{
        req.session.regenerate(function(err){
            if(err) next(err);
            req.session.error = "Error: Name is required.";
            req.session.save(function(err2){
                if(err2) next(err2);
                return res.redirect(`/customer/update/${req.params.id}`);
            })
        });
    }
})
router.post('/delete',async(req,res,next)=>{
    let cus = await customerModel.findById(req.body.id);
    if(cus instanceof customerModel){
        try {
            await customerModel.findByIdAndDelete(req.body.id);
            req.session.message = "Delete Customer successfully.";
        } catch (error) {
            console.log(error);

            req.session.error = "Delete Customer unsuccess.";    
        }
    }else{
        req.session.error = "Error: Customer not found.";           
    }
    return res.redirect('/customer');
})
module.exports = router;