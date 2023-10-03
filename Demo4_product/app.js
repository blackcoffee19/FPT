var createError = require('http-errors');
var express = require('express');
var path = require('path');
var cookieParser = require('cookie-parser');
var logger = require('morgan');
var usersRouter = require('./routes/users');
var indexRouter = require('./routes/index');

// Route Product
var ProductRouter = require('./routes/product');

var app = express();

//connect Mongodb
var mongose = require('mongoose');
mongose.connect('mongodb://127.0.0.1:27017/demo',{useNewUrlParser:true});
mongose.set('strictQuery',false);
// 'mongodb://127.0.0.1:27017/demo',{useNewUrlParser:true}

// view engine setup
app.set('views', path.join(__dirname, 'views'));
app.set('view engine', 'pug');
// Bootstrap & JQuery
console.log(__dirname);
app.use('/bootstrap',express.static(path.join(__dirname,"node_modules/bootstrap/dist/")));
app.use('/jquery',express.static(path.join(__dirname,"node_modules/jquery/dist/")))

app.use(logger('dev'));
app.use(express.json());
app.use(express.urlencoded({ extended: false }));
app.use(cookieParser());
app.use(express.static(path.join(__dirname, 'public')));

app.use('/', indexRouter);
app.use('/users', usersRouter);
app.use('/product',ProductRouter);
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
