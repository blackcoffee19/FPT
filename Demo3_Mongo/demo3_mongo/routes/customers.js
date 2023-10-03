const express = require('express');
const router = express.Router();
const mongoose = require('mongoose');
const customerModel = require('../models/customerModel');

//GET users
router.use('/update/:id',async (req,res,next)=>{
    const id = req.params.id;
    let customer;  
    try {
        customer =await customerModel.findById(id).exec();
    } catch (error) {
        console.log(error);
    }
    req.id = customer instanceof mongoose.Model? id :null;
    req.customer = customer instanceof mongoose.Model? customer:null;
    next();
});
router.get('/',async function(req,res,next){
    let searchName =req.query.name;
    let searchEmail = req.query.email; 
    let search = searchEmail && searchName ? {name: searchName,email:searchEmail} : (searchEmail ? {email:searchEmail}: (searchName ? {name:searchName}:{}) );
    let searchBy = req.query.searchBy;
    let searchStr= req.query.searchInput;
    searchStr = searchStr.trim();
    if(searchBy){
        switch(searchBy){
            case "name":
                search = {name: {$regex: '.*' + searchStr + '.*' , $options: 'i'}};
                break;
            case "email":
                search = {email: {$regex: '.*' + searchStr + '.*' , $options: 'i'}};
                break;
            case "phone":
                search = {phone: {$regex: '.*' + searchStr + '.*' , $options: 'i'}};
                break;
            default:
                search = null;
        }
    }
    let customers = await customerModel.find(search);
    return res.render('customer/index',{customers:customers});
});
router.get('/create',(req,res,next)=>{
    return res.render('customer/create');
});
router.post('/create',async (req,res,next)=>{
    let cus = new customerModel({
        name: req.body.name,
        email: req.body.email,
        phone: req.body.phone
    });
    await cus.save();
    return res.redirect('/customer');
});
router.get(`/update/:id`, async (req,res,next)=>{
    if (req.id!=null){
        if(req.customer){
            return res.render('customer/update',{customer:req.customer});
        }else{
            return res.render('customer/index',{error: "Data Not Found",customers: []});
        }
    }else{
        return res.render('customer/index',{error: "Data Not Found",customers: []});
    }
})  
router.post(`/update/:id`, async(req,res,next)=>{
    req.customer.name = req.body.name;
    req.customer.email = req.body.email;
    req.customer.phone = req.body.phone;
    await req.customer.save();
    return res.redirect('/customer');
})
router.delete('/delete', async(req,res,next)=>{
    let cus = await customerModel.findByIdAndDelete(req.body.id);
})
module.exports = router;