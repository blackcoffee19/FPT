var mongoose = require('mongoose');
var StaffModel = require('./staffModel');
let projectSchema  = mongoose.Schema({
    name: String,
    projectstaffs: [{
        type: mongoose.Types.ObjectId,
        ref: 'Staff',
        require:true
    }]
},{timestraps:true});

const Project = mongoose.model("Project",projectSchema);

module.exports = Project;
