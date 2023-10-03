var express = require('express');
var router = express.Router();

router.use('/',(req,res,next)=>{
  console.log("Middelware");
  console.log(req.url);
  console.log(req.params);
  console.log(req.query);
  next();
})
/* GET home page. */
router.get('/', function(req, res, next) {
  res.send("INDEX PAGE");
  // res.render('index', { title: 'Express' });
});

module.exports = router;

