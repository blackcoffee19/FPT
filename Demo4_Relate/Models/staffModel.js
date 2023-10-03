var mongoose = require('mongoose');

const staffSchema = mongoose.Schema({
    name: String,
    role: String,
    salary: {type: Number, require:true,min:0},
    project: [{
        ref: "Project",
        type: mongoose.Types.ObjectId,
        require: false
    }]
},{timestraps:true});
const Staff = mongoose.model("Staff",staffSchema);

module.exports =  Staff;
