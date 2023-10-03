var createError = require('http-errors');
var express = require('express');
var path = require('path');
var cookieParser = require('cookie-parser');
var logger = require('morgan');

var indexRouter = require('./routes/index');
var usersRouter = require('./routes/users');
var projectRouter = require('./routes/projects');
var staffRouter = require('./routes/staffs');
var app = express();
var Staff = require('./Models/staffModel')
var Project = require('./Models/projectModel');
//MongoDB connect
var mongoose = require('mongoose');
mongoose.connect('mongodb://127.0.0.1:27017/demo',{useNewUrlParser:true});


// view engine setup
app.set('views', path.join(__dirname, 'views'));
app.set('view engine', 'pug');
app.use(logger('dev'));
app.use(express.json());
app.use(express.urlencoded({ extended: false }));
app.use(cookieParser());
app.use(express.static(path.join(__dirname, 'public')));

//connect Bootstrap 5
app.use('/bootstrap',express.static(__dirname+"/node_modules/bootstrap/dist/"));
//Migration data  
// app.use('/',async(res,req,next)=>{
//   let staffs = await Staff.find();
//   if(staffs.length!=4){
//     await Staff.create({
//         name: "Fu Xuan",
//         role: "Master Diviner",
//         salary: 99900000,
//         },
//         {
//             name: "Qingque",
//             role: "Diviner",
//             salary: 90000000
//         },
//         {
//             name: "Himeko",
//             role: "Engineer",
//             salary: 23203030
//         },{
//             name: "Kafka",
//             role: "Developer",
//             salary:10000000
//     });
//   }
//   next();  
// });
// app.use('/',async(req,res,next)=>{
//   let staffs = await Staff.find();
//   let projects = await Project.find();
//   if(projects.length==0){
//     await Project.create(
//       {
//           name: "Project Star rail",
//           projectstaffs: [staffs[2],staffs[3]]
//       },
//       {
//           name: "Project Loufu",
//           projectstaffs: [staffs[0],staffs[1]]
//       }
//     );
//   }
//   if(staffs[0].project.length==0){
//     staffs[0].project.push(projects[1]._id);
//     staffs[1].project.push(projects[1]._id);
//     staffs[2].project.push(projects[0]._id);
//     staffs[3].project.push(projects[0]._id);
//     await staffs[0].save();
//     await staffs[1].save();
//     await staffs[2].save();
//     await staffs[3].save();
//   }
//   next();
// })
app.use('/', indexRouter);
app.use('/users', usersRouter);
app.use('/project',projectRouter);
app.use('/staff',staffRouter);
// catch 404 and forward to error handler
app.use(function(req, res, next) {
  next(createError(404));
});

// error handler
app.use(function(err, req, res, next) {
  // set locals, only providing error in development
  res.locals.message = err.message;
  res.locals.error = req.app.get('env') === 'development' ? err : {};

  // render the error page
  res.status(err.status || 500);
  res.render('error');
});

module.exports = app;
