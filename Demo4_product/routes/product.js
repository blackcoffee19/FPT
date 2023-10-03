const express = require('express');
const router = express.Router();
const productModel = require('../models/productModel');
// const mongoose = require('mongoose');
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
router.get('/', async (req, res,next) => {
    const products = await productModel.find();
    return res.render('product/index',{products:products});
});
router.get('/create', (req, res,next) => {
  return res.render('product/create');
})
router.post('/create',upload.single('image'),async(req,res,next)=>{
    const file = req.file;
    let prod = new productModel({
        name: req.body.name,
        price: req.body.price,
        image: file.filename
    });
    try {
        await prod.save();
    } catch (error) {
        console.log(error);
        return res.redirect('/product/create');
    }
    return  res.redirect('/product');
})
router.get('/update/:id',async (req,res,next)=>{
    let product;
    try {
        product = await productModel.findById(req.params.id);
    } catch (error) {
        console.log(error);
        return res.redirect('/product');
    }
    return res.render('product/update',{product:product});
})
router.post('/update/:id',upload.single('image'),async(req,res,next)=>{
    let product = await productModel.findById(req.params.id);
    product.name = req.body.name;
    product.price = req.body.price;
    product.image = req.file?req.file.filename:product.image;
    await product.save();
    return res.redirect('/product');
})
router.delete('/delete', async (req,res,next)=>{
    try {
        await productModel.findByIdAndDelete(req.body.id);
    } catch (error) {
        console.log(error);
    }
})
module.exports = router;