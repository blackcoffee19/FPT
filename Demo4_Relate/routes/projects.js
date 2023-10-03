var express = require('express');
var router = express.Router();
var session = require('express-session');
var ProjectModel = require("../Models/projectModel");
var StaffModel = require('../Models/staffModel');
router.use(session({
    secret: 'keyboard cat',
    resave:true,
    saveUninitialized:true,
    cookie: { maxAge: 60000 }
}))

router.get('/',async(req,res,next)=>{
    let projects = await ProjectModel.find().populate('projectstaffs');
    res.render('Project/index',{projects:projects,error:req.session.error,message: req.session.message});
});
router.get('/create',async (req,res,next)=>{
    let staffs = await StaffModel.find();
    res.render("Project/create",{staffs:staffs,error: req.session.error});
});
router.post('/create',async(req,res,next)=>{
    if(req.body.name && req.body.staffs){
        try {
            let staffs = req.body.staffs;
            let newPro = new ProjectModel({
                name:req.body.name,
                projectstaffs:staffs
            });
            newPro.save().then(pr=>{
                if(staffs.length>0){
                    staffs.forEach(async (el) => {
                        let staff = await StaffModel.findById(el);
                        staff.project.push(pr._id);
                        staff.save();
                    });
                }
            })
            req.session.regenerate(function(err){
                if(err) next(err);
                req.session.message = "Add new Project successfully."
                req.session.save(function(err){
                    if(err) next(err);
                    return res.redirect('/project');
                })
            })
        } catch (error) {
            console.log(error);
            req.session.regenerate(function(err){
                if(err) next(err);
                req.session.error = "Create Project get error";
                req.session.save(function(err){
                    if(err) next(err);
                    return res.redirect('/project/create');
                })
            })
        }
    }else if(req.body.name){
        req.session.regenerate(err=>{
            if(err) next(err);
            req.session.error = "Project require add at least 1 staff.";
            req.session.save(function(err){
                if(err) next(err);
                return res.redirect('/project/create');
            });
        })
    }else {
        req.session.regenerate(err=>{
            if(err) next(err);
            req.session.error = "Project require name.";
            req.session.save(function(err){
                if(err) next(err);
                return res.redirect('/project/create');
            });
        })
    }
})
router.post('/delete', async(req,res,next)=>{
    let project = await ProjectModel.findById(req.body.id);
    if(project){
        let projectName = project.name;
        try {
            project.projectstaffs.forEach(async pr=>{
                let staff = await StaffModel.findById(pr);
                let ind = staff.project.indexOf(req.body.id);
                staff.project.splice(ind,1);
                staff.save();
            })
            await ProjectModel.findByIdAndDelete(req.body.id);
            req.session.regenerate(function(err){
                if(err) next(err);
                req.session.message =`Delete Project ${projectName} Successfully`;
                req.session.save(function(err){
                    if(err) next(err);
                    return res.redirect('/project');
                })
            })
        } catch (error) {
            req.session.regenerate(function(err){
                if (err) next(err);
                req.session.error = "Error Delete Project unsuccess.";
                req.session.save(function(err){
                    if(err) next(err);
                    return res.redirect('/project');
                })
            })
        }   
    }
})
router.get('/update/:id',async (req,res,next)=>{
    let project = await ProjectModel.findById(req.params.id);
    let staffs = await StaffModel.find();
    if(!project){
        req.session.regenerate(function(err){
            if(err) next(err);
            req.session.error="Project Not Found";
            req.session.save(function(err){
                if(err) next(err);
                return res.redirect('/project/');
            })
        })
    }else{
        res.render('Project/update',{project:project,staffs:staffs,error:req.session.error,message: req.session.message});
    }
});
router.post('/update/:id',async (req,res,next)=>{
    let project = await ProjectModel.findById(req.params.id);
    if(!project){
        req.session.regenerate(function(err){
            if(err) next(err);
            req.session.error = "Error: Project not found";
            req.session.save(function(err){
                if(err) next(err);
                return res.redirect('/project');
            });
        });
    }else{
        let staffs = req.body.staffs;
        if(typeof(staffs)=="string"){
            staffs = [staffs];
        }
        if(staffs && staffs.length>0&& req.body.name){
            try {
                staffs.forEach(async (el)=>{
                    let staf = await StaffModel.findById(el);
                    if(!staf.project.includes(req.params.id)){
                        staf.project.push(req.params.id);
                    }
                    await staf.save();
                });
                let stafs = await StaffModel.find();
                stafs.map(el => {
                    if(!staffs.includes(el._id.toString())){
                        if(el.project.includes(req.params.id)){
                            let ind = el.project.indexOf(req.params.id);
                            el.project.splice(ind,1);
                            el.save();
                        }
                    }
                })
                project.name = req.body.name;
                project.projectstaffs = staffs;
                project.save();
                req.session.regenerate(function(err){
                    if(err) next(err);
                    req.session.message = "Update Project successful.";
                    req.session.save(function(err){
                        if(err) next(err);
                        return res.redirect('/project');
                    })
                })
            } catch (error) {
                console.log(error);
                req.session.regenerate(function(err){
                    if(err) next(err);
                    req.session.error = "Error: Update Project unsuccessful.";
                    req.session.save(function(err){
                        if(err) next(err);
                        return res.redirect(`/project/update/${req.params.id}`);
                    })
                });
            }
        }else if(staffs&& staffs.length>0){
            req.session.regenerate(err=>{
                if(err) next(err);
                req.session.error = "Project name is required."
                req.session.save(function(err){
                    if(err) next(err);
                    return res.redirect(`/project/update/${req.params.id}`);
                })
            });
        }else{
            req.session.regenerate(err=>{
                if(err) next(err);
                req.session.error = "Project name is required at least 1 staff."
                req.session.save(function(err){
                    if(err) next(err);
                    return res.redirect(`/project/update/${req.params.id}`);
                })
            });
        }
    }
})
module.exports = router;