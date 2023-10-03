const express = require("express");
const app = express();
const bodyParser = require("body-parser");
//Dang ky Middleware
app.use(bodyParser.urlencoded({extended:true}));
app.post("/user",function(req,res){
    const body = req.body;
    console.log("name= "+body.name+ ", email "+body.email);
    res.send("name= "+body.name+ ", email= "+body.email);
})
app.get("/",function(req,res){
    res.send("Welcome to class T1.2206.M1");
})
app.get("/hello/:name/:age",function(req,res){
    const routeParams = req.params;
    const name = routeParams.name;
    res.send("Welcome "+name);
});
app.get("hello/search",function(req,res){
    const queryParams = req.query;
    const searck= queryParams.k;
    res.send("Search: "+searck);
});
const server = app.listen(3100,function(){
    const host = server.address().address;
    const port = server.address().port;
    console.log(`Server is running at ${host} port ${port}`);
})