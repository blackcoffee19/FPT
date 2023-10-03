var express = require('express');
var router = express.Router();
var session = require('express-session');
var StaffModel = require('../Models/staffModel');
var ProjectModel = require('../Models/projectModel');
router.use(session({
    secret: 'keyboard cat',
    resave:true,
    saveUninitialized:true,
    cookie: { maxAge: 60000 }
}))
router.get('/',async (req,res,next)=>{
    let staffs =await StaffModel.find().populate('project');
    for (let staff in staffs) {
        console.log(staffs[staff]);
    }
    res.render('Staff/index',{staffs:staffs,error:req.session.error,message:req.session.message});
})
router.get('/create',(req,res,next)=>{
    res.render('Staff/create',{error:req.session.error});
})
router.post('/create',async (req,res,next)=>{
    let check = isNaN(req.body.salary) || req.body.salary<=0;
    if(req.body.name&& !check && req.body.role){
        try {
            StaffModel.create({
                name:req.body.name,
                salary:req.body.salary,
                role: req.body.role
            });
            req.session.regenerate(function(err){
                if (err) next(err);
                req.session.message = "Create Staff succefully.";
                req.session.save(function(err){
                    if(err) next(err);
                    return res.redirect('/staff');
                })
            })
        } catch (error) {
            console.log(error);
            req.session.regenerate(function(err){
                if (err) next(err);
                req.session.error = error.message;
                req.session.save(function(err){
                    if(err) next(err);
                    return res.redirect('/staff/create');
                })
            })
        }
    } else if(req.body.name && !check){
        req.session.regenerate((err)=>{
            if(err) next(err);
            req.session.error = "Staff roll is required";
            req.session.save(function(err){
                if(err) next(err);
                return res.redirect('/staff/create');
            })
        })
    }
    else if(req.body.name&& req.body.role){
        req.session.regenerate((err)=>{
            if(err) next(err);
            req.session.error = "Staff salary need greater than 0";
            req.session.save(function(err){
                if(err) next(err);
                return res.redirect('/staff/create');
            })
        })
    } else if(req.body.role && !check){
        req.session.regenerate((err)=>{
            if(err) next(err);
            req.session.error = "Staff name is required";
            req.session.save(function(err){
                if(err) next(err);
                return res.redirect('/staff/create');
            })
        })
    }
    else{
        req.session.regenerate((err)=>{
            if(err) next(err);
            req.session.error = "Need fill all field";
            req.session.save(function(err){
                if(err) next(err);
                return res.redirect('/staff/create');
            })
        })
    }
})

router.get('/delete/:id',async (req,res,next)=>{
    let staff = await StaffModel.findById(req.params.id);
    if(staff){
        if(staff.project.length>0){
            staff.project.forEach(async (el)=>{
                let proj= await ProjectModel.findById(el);
                let ind = proj.projectstaffs.indexOf(req.params.id);
                proj.projectstaffs.splice(ind,1);
                await proj.save();
            })
        }
        await StaffModel.findByIdAndDelete(req.params.id);
        req.session.regenerate(function(err){
            if(err) next(err);
            req.session.message = "Delete Staff Successful."
            req.session.save(function(err){
                if(err) next(err);
                return res.redirect('/staff');
            })
        })
    }else{
        req.session.regenerate(function(err){
            if(err) next(err);
            req.session.error = "Delete Staff unsuccessful."
            req.session.save(function(err){
                if(err) next(err);
                return res.redirect('/staff');
            })
        })
    }
})
router.get('/update/:id',async (req,res,next)=>{
    let staff = await StaffModel.findById(req.params.id).populate('project');
    if(staff){
        res.render('Staff/update',{staff:staff,error: req.session.error,message:req.session.message});
    }else{
        res.session.regenerate(function(err){
            if(err) next(err);
            req.session.error = "Error: Cannot find Staff.";
            req.session.save(function(err){
                if (err) next(err);
                return res.redirect('/staff');
            });
        })
    }
});
router.post('/update/:id',async (req,res,next)=>{
    let staff = await StaffModel.findById(req.params.id);
    if(staff){
        let check =isNaN(req.body.salary) || req.body.salary<=0;
        if(req.body.name&& !check && req.body.role){
            staff.name =req.body.name;
            staff.salary =req.body.salary;
            staff.role= req.body.role;
            staff.save();
            req.session.regenerate(function(err){
                if(err) next(err);
                req.session.message = "Update staff successfully";
                req.session.save(function(err){
                    if(err) next(err);
                    return res.redirect('/staff');
                })
            })
        }else if(req.body.name && !check){
            req.session.regenerate(function(err){
                if(err) next(err);
                req.session.error = "Required Staff Role";
                req.session.save(function(err){
                    if(err) next(err);
                    return res.redirect(`/staff/update/${req.params.id}`);
                })
            });
        }else if(req.body.role && ! check){
            req.session.regenerate(function(err){
                if(err) next(err);
                req.session.error = "Required Staff's Name";
                req.session.save(function(err){
                    if(err) next(err);
                    return res.redirect(`/staff/update/${req.params.id}`);
                })
            });
        }else if(req.body.role && req.body.name){
            req.session.regenerate(function(err){
                if(err) next(err);
                req.session.error = "Staff salary is a number and greater than 0 make sure your input correct";
                req.session.save(function(err){
                    if(err) next(err);
                    return res.redirect(`/staff/update/${req.params.id}`);
                })
            });
        }else{
            req.session.regenerate(function(err){
                if(err) next(err);
                req.session.error = "Something wrong. Try again.";
                req.session.save(function(err){
                    if(err) next(err);
                    return res.redirect(`/staff/update/${req.params.id}`);
                })
            });
        }
    }else{
        res.session.regenerate(function(err){
            if(err) next(err);
            req.session.error = "Error: Cannot find Staff.";
            req.session.save(function(err){
                if (err) next(err);
                return res.redirect('/staff');
            });
        })
    }
})
module.exports = router;