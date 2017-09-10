/*
This file is the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. https://go.microsoft.com/fwlink/?LinkId=518007
*/

var gulp = require('gulp');
var inject = require('gulp-inject');
var print = require('gulp-print');

var rootPath = './wwwroot /';
var appPath = rootPath + 'app/';

var config = {
    rootPath: rootPath,
    index: rootPath + 'index.html',
    js: [
        appPath + '**/*.module.js',
        appPath + '**/*.config.js',
        appPath + '**/*.js'
    ]
};


gulp.task('inject', function () {    
    return gulp
        .src(config.index)
        .pipe(inject(gulp.src(config.js), { ignorePath: 'wwwroot' }))
        //.pipe(inject(gulp.src([config.cssOutputPath + 'style.css']), { ignorePath: 'wwwroot' }))
        .pipe(gulp.dest(config.rootPath));
});