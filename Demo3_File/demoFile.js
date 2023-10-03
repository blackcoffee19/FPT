const fs = require('fs');

function readFile1 (err,data){
    if(err){
        console.log(err);
    }else{
        console.log("Data 1");
        console.log(data.toString());
    }
}
console.log('\nReade File 1');
fs.readFile("file1.txt",readFile1);
console.log("Done");
console.log("\nRead File 2");
fs.readFile("file2.txt",(err,data)=>{
    if(err){
        console.log(err);
    }else{
        console.log("\nData File 2:");
        console.log(data.toString());
    }
})