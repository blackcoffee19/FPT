var express = require('express');
var multer = require('multer');
var route = express.Router();
var bookModel = require('../models/bookModel'); 
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

route.get('/', async (req, res,next) => {
  let books = await bookModel.find();
  return res.render('book/index',{books:books});
})

route.get('/create', (req, res,next) => {
  return res.render('book/create');
})

route.post('/create', upload.single('image'), async (req, res,next) => {
    let book = new bookModel({
      title: req.body.title,
      price: req.body.price,
      image: req.file.filename
    });
    try {
      await book.save();
      res.redirect('/book/');
    } catch (error) {
      console.log(error);
      res.redirect('/book/create');
    }
})
route.get('/search',async (req,res,next)=>{
  let title = req.query.title;
  let books = await bookModel.find({'title': { $regex: '.*' + title + '.*' }})
  return res.render('book/index',{books,books});
})
route.get('/update/:id',async(req,res,next)=>{
  try {
    let book = await bookModel.findById(req.params.id);
    res.render('book/update',{book:book});
  } catch (error) {
    console.log(error);
    res.redirect('/book');
  }
});
route.post('/update/:id',upload.single("image"),async (req,res,next)=>{
  try {
    let book = await bookModel.findById(req.params.id);
    book.title = req.body.title;
    book.price = req.body.price;
    book.image = req.file?req.file.filename:book.image; 
    res.redirect('/book');
    await book.save();
  } catch (error) {
    console.log(error);
    res.redirect('/book');
  } 
})
module.exports= route;