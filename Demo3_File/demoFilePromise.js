const fs = require('fs');
const getFile = (file)=>{
    return new Promise((resole,reject)=>{
        fs.readFile(file,(err,data)=>{
            if (err){
                reject(err);
            }
            resole(data.toString());
        })
    });
}
getFile("file1.txt").then(data=>console.log(data)).catch(err=>console.log(err));