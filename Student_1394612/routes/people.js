var express = require('express');
var router = express.Router();
var session =require('express-session');
var peopleModel = require('../models/peopleModel');
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
    let peoples = await peopleModel.find();
    req.peoples = peoples;
    next();
})
router.use(['/detail/:id','/update/:id'],async(req,res,next)=>{
    let people = await peopleModel.findById(req.params.id);
    if(people){
        req.people = people;
        next();
    }else{
        req.session.regenerate(function(err){
            if(err) next(err);
            req.session.error = "Error: Not found Person";
            req.session.save(function(err){
                if (err) next(err);
                return res.redirect('/people');
            });
        })
    }
})
router.get('/',async (req,res,next)=>{
    let searchStr= req.query.searchInput;
    if(searchStr){
        searchStr = searchStr.trim();
        let search = {fullname: {$regex: '.*' + searchStr + '.*' , $options: 'i'}};
        let customers = await peopleModel.find(search);
        return res.render('People/index',{peoples:customers,error:req.session.error,message:req.session.message});
    }
    res.render('People/index',{peoples:req.peoples,error:req.session.error,message:req.session.message});
})
router.get('/create',(req,res,next)=>{
    res.render('people/create',{error:req.session.error,message:req.session.message});
})
router.post('/create',upload.single("image"),async (req,res,next)=>{
    if(req.body.name && req.file && req.body.dob && req.body.reputation){
        let dateO = new Date(req.body.dob);
        // if(dateO.getUTCFullYear()<1900 || dateO.getUTCFullYear()>1990){
        //     req.session.regenerate(function(err){
        //         if(err) next(err);
        //         req.session.error = "Error: Date of birthh is must >1900 and <1990.";
        //         req.session.save(function(err2){
        //             if(err2) next(err2);
        //             return res.redirect(`/people/create`);
        //         })
        //     });
        // }
        let people = await peopleModel.find();
        try {
            await peopleModel.create({
                id: people.length+1,
                fullname: req.body.name,
                dob: req.body.dob,
                reputation:req.body.reputation,
                photo: req.file? req.file.filename:null
            });
            req.session.message = "Create people successfully.";
        } catch (error) {
            req.session.error = "Create people unsucceff";
            return res.redirect('/people/create');
        }
        return res.redirect('/people');
    }else if(!req.body.name){
        req.session.regenerate(function(err){
            if(err) next(err);
            req.session.error = "Error: Name is required.";
            req.session.save(function(err2){
                if(err2) next(err2);
                return res.redirect(`/people/create`);
            })
        });
    }else if(!req.body.dob){
        req.session.regenerate(function(err){
            if(err) next(err);
            req.session.error = "Error: Date of birthh is required.";
            req.session.save(function(err2){
                if(err2) next(err2);
                return res.redirect(`/people/create`);
            })
        });
    }else if(! req.body.reputation){
        req.session.regenerate(function(err){
            if(err) next(err);
            req.session.error = "Error: Reputation is required.";
            req.session.save(function(err2){
                if(err2) next(err2);
                return res.redirect(`/people/create`);
            })
        });
    }else if(!req.file){
        req.session.regenerate(function(err){
            if(err) next(err);
            req.session.error = "Error: Photo is required.";
            req.session.save(function(err2){
                if(err2) next(err2);
                return res.redirect(`/people/create`);
            })
        });
    }else {
        req.session.regenerate(function(err){
            if(err) next(err);
            req.session.error = "Error: Try input again.";
            req.session.save(function(err2){
                if(err2) next(err2);
                return res.redirect(`/people/create`);
            })
        });
    }
})
router.get('/detail/:id',async (req,res,next)=>{
    res.render('people/detail',{people: req.people,error:req.session.error, message: req.session.message});
})
// router.post('/update/:id',upload.single('image'),async(req,res,next)=>{
//     let regexPhone = /(84|0[3|5|7|8|9])+([0-9]{8})\b/;
//     let checkPhone = regexPhone.test(req.body.phone);
//     let regexEmail = /[\w]*@*[a-z]*\.*[\w]{5,}(\.)*(com)*(@gmail\.com)/;
//     let checkEmail = regexEmail.test(req.body.email);
//     let cuss = await peopleModel.find({"email": req.body.email});//{ $regex: '.*' + title + '.*' }
//     if(cuss.length>1){
//         req.session.error = "Email has been signed.";
//         return res.redirect(`/people/update/${req.params.id}`);
//     }
//     if(req.body.name && checkPhone && checkEmail){
//         req.people.name  = req.body.name;
//         req.people.email = req.body.email;
//         req.people.image = req.file? req.file.filename:req.people.image;
//         await req.people.save().then(res=>console.log("Successfull")).catch(err=>{if(err)next(err);});
//         req.session.regenerate(err=>{
//             if(err) next(err);
//             req.session.message = "Update people successfully.";
//             req.session.save(function(err){
//                 if(err) next(err);
//                 return res.redirect('/people');
//             })
//         }) 
//     }else if(req.body.name && checkEmail){
//         req.session.regenerate(function(err){
//             if(err) next(err);
//             req.session.error = "Error: Phone invalid.";
//             req.session.save(function(err2){
//                 if(err2) next(err2);
//                 return res.redirect(`/people/update/${req.params.id}`);
//             })
//         });
//     }else if(req.body.name &&  checkPhone){
//         req.session.regenerate(function(err){
//             if(err) next(err);
//             req.session.error = "Error: Email invalid.";
//             req.session.save(function(err2){
//                 if(err2) next(err2);
//                 return res.redirect(`/people/update/${req.params.id}`);
//             })
//         });
//     }else{
//         req.session.regenerate(function(err){
//             if(err) next(err);
//             req.session.error = "Error: Name is required.";
//             req.session.save(function(err2){
//                 if(err2) next(err2);
//                 return res.redirect(`/people/update/${req.params.id}`);
//             })
//         });
//     }
// })
router.post('/delete',async(req,res,next)=>{
    let cus = await peopleModel.findById(req.body.id);
    if(cus instanceof peopleModel){
        try {
            await peopleModel.findByIdAndDelete(req.body.id);
            req.session.message = "Delete people successfully.";
        } catch (error) {
            console.log(error);

            req.session.error = "Delete people unsuccess.";    
        }
    }else{
        req.session.error = "Error: people not found.";           
    }
    return res.redirect('/people');
})
module.exports = router;